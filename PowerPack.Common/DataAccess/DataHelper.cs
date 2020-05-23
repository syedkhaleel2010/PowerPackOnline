using System;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

// Custom Namespaces//using Zeerarst.Framework.StaticClasses;

///Header Information 
///Properties : None
///Methods : 
///GeConnectionObject()
///GetConnectionObject() 
///GetCommandObject()
///GetSqlDataReader()
///GetDataSet()
///GetScalarValue
///ExecuteNonQuery()
///Modification History
///Modfied By		Modified Date		Reason
///Header Information


namespace PowerPack.Common.DataAccess
{
    public class DataHelper
    {
        #region Class Level variables
        private string _defaultConnectionString;
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private SqlDataAdapter _sqlDataAdapter;
        #endregion

        #region Public Property
        public SqlCommand ICommand
        {
            get
            {
                return _sqlCommand;
            }
        }

        public SqlConnection DefaultConnection
        {
            get
            {
                return _sqlConnection;
            }
        }
        #endregion

        #region Constructors (2 Overloads) & Destructor
        public DataHelper()
        {
            _defaultConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            _sqlConnection = GetConnectionObject();
        }

        public DataHelper(string connectionKeyOrString, bool isConnectionString = false)
        {
            if (isConnectionString)
                _sqlConnection = GetConnectionObject(connectionKeyOrString);
            else
                _sqlConnection = GetConnectionObject(ConfigurationManager.ConnectionStrings[connectionKeyOrString].ConnectionString);
        }

        ~DataHelper()
        {
            Dispose();
        }

        #endregion

        #region Public Methods

        #region GetConnectionObject (2 Overloads)
        public SqlConnection GetConnectionObject()
        {
            return (new SqlConnection(_defaultConnectionString)); 
        }

        public SqlConnection GetConnectionObject(string aConnectionString)
        {
            return (new SqlConnection(aConnectionString));
        }

        #region Dynamic Parameter Mapping

        public IList<DataParameter> PopulateStoredProcedureParameters<T>(string name, T valueEntity) where T : class
        {
            IList<DataParameter> dataParameters = new List<DataParameter>();
            Openconnection();
            SqlCommand cmd = GetCommandObject(name, CommandType.StoredProcedure);           
            SqlCommandBuilder.DeriveParameters(cmd);
            foreach (SqlParameter p in cmd.Parameters)
            {
                if (!p.ParameterName.Contains("RETURN_VALUE"))
                {
                    var property = valueEntity.GetType().GetProperty(p.ParameterName.Substring(1));
                    if (property != null)
                    {
                        dataParameters.Add(new DataParameter(p.ParameterName, p.SqlDbType, property.GetValue(valueEntity)));
                    }
                }
            }
            return dataParameters;
        }
        #endregion

        #endregion

        #region GetCommandObject (6 Overloads)

        #region GetCommandObject (Without Parameters - 2 Overloads)
        public SqlCommand GetCommandObject(string aCommandString)
        {
            return (new SqlCommand(aCommandString, _sqlConnection));

        }

        public SqlCommand GetCommandObject(string aCommandString, CommandType aCommandType)
        {
            _sqlCommand = new SqlCommand();
            _sqlCommand.CommandType = aCommandType;
            _sqlCommand.Connection = _sqlConnection;
            _sqlCommand.CommandText = aCommandString;
            _sqlCommand.CommandTimeout = 0;
            return _sqlCommand;
        }
        #endregion

        #region GetCommandObject (4 Overloads)

        public SqlCommand GetCommandObject(string aCommandString, DataParameter aSqlParameter)
        {
            return GetCommandObject(aCommandString, CommandType.Text, aSqlParameter);
        }

        public SqlCommand GetCommandObject(string aCommandString, CommandType aCommandType, DataParameter aSqlParameter)
        {
            List<DataParameter> sqlParam = new List<DataParameter>();
            sqlParam.Add(aSqlParameter);
            return GetCommandObject(aCommandString, aCommandType, sqlParam);
        }

        public SqlCommand GetCommandObject(string aCommandString, IList<DataParameter> aSqlParameters)
        {
            return GetCommandObject(aCommandString, CommandType.Text, aSqlParameters);
        }

        public SqlCommand GetCommandObject(string aCommandString, CommandType aCommandType, IList<DataParameter> aSqlParameters)
        {
            _sqlCommand = GetCommandObject(aCommandString, aCommandType);
            SqlParameter _sqlParameter;
            foreach (DataParameter _dataparameter in aSqlParameters)
            {
                _sqlParameter = new SqlParameter();
                _sqlParameter.ParameterName = _dataparameter.ParameterName;
                _sqlParameter.SqlDbType = _dataparameter.ParameterDataType;
                _sqlParameter.SqlValue = _dataparameter.ParameterInitialValue;
                _sqlParameter.Direction = _dataparameter.ParameterAction;

                _sqlCommand.Parameters.Add(_sqlParameter);
            }

            return _sqlCommand;
        }
        #endregion
        
        #endregion

        #region GetSqlDataReader (7 Overloads)
        
        public SqlDataReader GetSqlDataReader(SqlCommand aCommandObject)
        {
            Openconnection();
            return (aCommandObject.ExecuteReader(CommandBehavior.CloseConnection));
        }

        public SqlDataReader GetSqlDataReader(string aCommandString)
        {
            return GetSqlDataReader(aCommandString, CommandType.Text);
        }

        public SqlDataReader GetSqlDataReader(string aCommandString, CommandType aCommandType)
        {
            _sqlCommand = GetCommandObject(aCommandString, aCommandType);
            Openconnection();
            return (_sqlCommand.ExecuteReader(CommandBehavior.CloseConnection));
        }

        public SqlDataReader GetSqlDataReader(string aCommandString, DataParameter aSqlParameter)
        {
            return GetSqlDataReader(aCommandString, aSqlParameter, CommandType.Text);
        }

        public SqlDataReader GetSqlDataReader(string aCommandString, DataParameter aSqlParameter, CommandType aCommandType)
        {
            List<DataParameter> sqlParam = new List<DataParameter>();
            sqlParam.Add(aSqlParameter);
            return GetSqlDataReader(aCommandString, sqlParam, aCommandType);
        }

        public SqlDataReader GetSqlDataReader(string aCommandString, IList<DataParameter> aSqlParameters)
        {
            return GetSqlDataReader(aCommandString, aSqlParameters, CommandType.Text);
        }

        public SqlDataReader GetSqlDataReader(string aCommandString, IList<DataParameter> aSqlParameters, CommandType aCommandType)
        {
            Openconnection();
            _sqlCommand = GetCommandObject(aCommandString, aCommandType, aSqlParameters);
            return _sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }

        #endregion

        #region GetSqlDataAdapter (5 Overloads)

        public SqlDataAdapter GetSqlDataAdapter(string aCommandString)
        {
            return (new SqlDataAdapter(aCommandString, _sqlConnection));
        }

        public SqlDataAdapter GetSqlDataAdapter(string aCommandString, CommandType aCommandType)
        {
            _sqlCommand = GetCommandObject(aCommandString, aCommandType);
            return (new SqlDataAdapter(_sqlCommand));
        }

        public SqlDataAdapter GetSqlDataAdapter(string aCommandString, IList<DataParameter> aSqlParameters, CommandType aCommandType)
        {
            _sqlCommand = GetCommandObject(aCommandString, aCommandType, aSqlParameters);
            return (new SqlDataAdapter(_sqlCommand));
        }

        public SqlDataAdapter GetSqlDataAdapter(string aCommandString, DataParameter aSqlParameter, CommandType aCommandType)
        {
            _sqlCommand = GetCommandObject(aCommandString, aCommandType, aSqlParameter);
            return (new SqlDataAdapter(_sqlCommand));
        }

        public SqlDataAdapter GetSqlDataAdapter(SqlCommand aCommandObject)
        {
            aCommandObject.Connection = _sqlConnection;
            return (new SqlDataAdapter(aCommandObject));
        }
        #endregion

        #region GetDataSet (5 Overloads)

        public DataSet GetDataSet(SqlCommand aCommandObject)
        {
            Openconnection();
            _sqlDataAdapter = GetSqlDataAdapter(aCommandObject);
            DataSet _dataSet = new DataSet("genDataSet");
            _sqlDataAdapter.Fill(_dataSet);
            CloseConnection();

            return _dataSet;
        }

        public DataSet GetDataSet(string aCommandString)
        {
            return GetDataSet(aCommandString, CommandType.Text);
        }

        public DataSet GetDataSet(string aCommandString, CommandType aCommandType)
        {
            return GetDataSet(aCommandString, new List<DataParameter>(), aCommandType);
        }

        public DataSet GetDataSet(string aCommandString, DataParameter aSqlParameter, CommandType aCommandType)
        {
            IList<DataParameter> sqlParam = new List<DataParameter>();
            sqlParam.Add(aSqlParameter);
            return GetDataSet(aCommandString, sqlParam, aCommandType);
        }

        public DataSet GetDataSet(string aCommandString, IList<DataParameter> aSqlParameters, CommandType aCommandType)
        {
            Openconnection();
            _sqlDataAdapter = GetSqlDataAdapter(aCommandString, aSqlParameters, aCommandType);
            DataSet _dataSet = new DataSet("genDataSet");
            _sqlDataAdapter.Fill(_dataSet);
            CloseConnection();

            return _dataSet;
        }

        #endregion

        #region GetDataTable (3 Overloads)

        public DataTable GetDataTable(SqlCommand aCommandObject)
        {
            return GetDataSet(aCommandObject).Tables[0];
        }

        public DataTable GetDataTable(string aCommandString)
        {
            return GetDataSet(aCommandString).Tables[0];
        }

        public DataTable GetDataTable(string aCommandString, CommandType aCommandType)
        {
            return GetDataSet(aCommandString, aCommandType).Tables[0];
        }
        public DataTable GetDataTable(string aCommandString, IList<DataParameter> aSqlParameters, CommandType aCommandType)
        {
            return GetDataSet(aCommandString, aSqlParameters, aCommandType).Tables[0];
        }

        public DataTable GetDataTable(string aCommandString, DataParameter aSqlParameter, CommandType aCommandType)
        {
            return GetDataSet(aCommandString, aSqlParameter, aCommandType).Tables[0];
        }

        #endregion

        #region GetScalarValue (5 Overloads)

        public object GetScalarValue(string aCommandString)
        {
            _sqlCommand = GetCommandObject(aCommandString);
            Openconnection();

            var result = _sqlCommand.ExecuteScalar();
            CloseConnection();
            return result;
        }

        public object GetScalarValue(string aCommandString, CommandType aCommandType)
        {
            _sqlCommand = GetCommandObject(aCommandString, aCommandType);
            Openconnection();

            var result = _sqlCommand.ExecuteScalar();
            CloseConnection();
            return result;
        }

        public object GetScalarValue(string aCommandString, CommandType aCommandType, DataParameter aSqlParameter)
        {
            IList<DataParameter> sqlParam = new List<DataParameter>();
            sqlParam.Add(aSqlParameter);
            return GetScalarValue(aCommandString, sqlParam, aCommandType);
        }

        public object GetScalarValue(SqlCommand aCommandObject)
        {
            Openconnection();
            var result = _sqlCommand.ExecuteScalar();
            CloseConnection();
            return result;
        }

        public object GetScalarValue(string aCommandString, IList<DataParameter> aSqlParameters, CommandType aCommandType)
        {
            object _scalarObject = new object();
            _sqlCommand = GetCommandObject(aCommandString, aCommandType, aSqlParameters);
            Openconnection();
            var result = _sqlCommand.ExecuteScalar();
            CloseConnection();

            return result;
        }

        #endregion

        #region ExecuteNonQuery (4 Overloads)

        public int ExecuteNonQuery(string aCommandString)
        {
            return ExecuteNonQuery(aCommandString, CommandType.Text, new List<DataParameter>());
        }

        public int ExecuteNonQuery(string aCommandString, CommandType aCommandType)
        {
            return ExecuteNonQuery(aCommandString, aCommandType, new List<DataParameter>());
        }

        public int ExecuteNonQuery(string aCommandString, CommandType aCommandType, DataParameter aSqlParameter)
        {
            IList<DataParameter> sqlParameter = new List<DataParameter>();
            sqlParameter.Add(aSqlParameter);
            return ExecuteNonQuery(aCommandString, aCommandType, sqlParameter);
        }

        public int ExecuteNonQuery(string aCommandString, CommandType aCommandType, IList<DataParameter> aSqlParameters)
        {
            int _rowsAffected = 0;
            Openconnection();

            _sqlCommand = GetCommandObject(aCommandString, aCommandType, aSqlParameters);
            if (aCommandType == CommandType.StoredProcedure)
            {
                SqlParameter _sqlParameter = new SqlParameter("@output", SqlDbType.Int);
                _sqlParameter.Direction = ParameterDirection.Output;
                _sqlParameter.IsNullable = true;
                _sqlCommand.Parameters.Add(_sqlParameter);
            }
            _rowsAffected = _sqlCommand.ExecuteNonQuery();
            CloseConnection();

            if (aCommandType == CommandType.StoredProcedure)
            {
                return Convert.ToInt32(_sqlCommand.Parameters["@output"].Value);
            }
            else
            {
                return 1;
            }
        }

        #endregion

        #region GetDataList .. 4 Overloads

        public List<DataListItem> GetDataList(string aCommandString)
        {
            SqlDataReader _dataReader = GetSqlDataReader(aCommandString);
            return GetDataList(_dataReader);
        }

        public List<DataListItem> GetDataList(string aCommandString, CommandType aCommandType)
        {
            SqlDataReader _dataReader = GetSqlDataReader(aCommandString, aCommandType);
            return GetDataList(_dataReader);
        }

        public List<DataListItem> GetDataList(string aCommandString, DataParameter aDataparameter, CommandType aCommandType)
        {
            SqlDataReader _dataReader = GetSqlDataReader(aCommandString, aDataparameter, aCommandType);
            return GetDataList(_dataReader);
        }

        public List<DataListItem> GetDataList(string aCommandString, IList<DataParameter> aDataparameters, CommandType aCommandType)
        {
            SqlDataReader _dataReader = GetSqlDataReader(aCommandString, aDataparameters, aCommandType);
            return GetDataList(_dataReader);
        }
        #endregion

        #region Misc

        #region GetDataItemSinglerow ... (4 Overloads)

        public DataListItem GetDataListItemSingleRow(string aCommandString)
        {
            SqlDataReader _dataReader = GetSqlDataReader(aCommandString);
            return GetDataListItemSingleRow(_dataReader);
        }

        public DataListItem GetDataListItemSingleRow(string aCommandString, CommandType aCommandType)
        {
            SqlDataReader _dataReader = GetSqlDataReader(aCommandString, aCommandType);
            return GetDataListItemSingleRow(_dataReader);
        }

        public DataListItem GetDataListItemSingleRow(string aCommandString, DataParameter aDataparameter, CommandType aCommandType)
        {
            SqlDataReader _dataReader = GetSqlDataReader(aCommandString, aDataparameter, aCommandType);
            return GetDataListItemSingleRow(_dataReader);
        }

        public DataListItem GetDataListItemSingleRow(string aCommandString, IList<DataParameter> aDataparameters, CommandType aCommandType)
        {
            SqlDataReader _dataReader = GetSqlDataReader(aCommandString, aDataparameters, aCommandType);
            return GetDataListItemSingleRow(_dataReader);
        }

        #endregion

        public Hashtable GetDBCharFieldMaxLengths(string TableName)
        {
            DataHelper _dataHelper = new DataHelper();
            DataParameter _aDataParameter = new DataParameter("@Table_Name", SqlDbType.VarChar, TableName);
            SqlDataReader _drMaxLength = GetSqlDataReader("GEN_uspGetMaxLength", _aDataParameter, CommandType.StoredProcedure);
            Hashtable ht = new Hashtable();

            while (_drMaxLength.Read())
            {
                ht.Add(_drMaxLength["Column_Name"].ToString().ToLower(),
                       _drMaxLength["Character_Maximum_Length"].ToString());
            }

            return ht;
        }

        #region CopyDataReaderToObject ... (2 Overloads)

        public T CopyDataReaderToObject<T>(SqlDataReader DataReader, bool doNotCloseDataReader = false)
        {
            return CopyDataReaderToObject<T>(DataReader, true, doNotCloseDataReader);
        }

        public T CopyDataReaderToObject<T>(SqlDataReader DataReader, bool invokeDataReaderReadMethod, bool doNotCloseDataReader = false)
        {
            // Create a new Object
            T newObjectToReturn = Activator.CreateInstance<T>();
            bool canReadData = true;

            if (invokeDataReaderReadMethod)
            {
                canReadData = DataReader.Read();
            }

            if (canReadData)
            {
                // Get all the properties in our Object
                PropertyInfo[] props = typeof(T).GetProperties();

                BindingFlags flags = BindingFlags.DeclaredOnly |
                                        BindingFlags.Public | BindingFlags.NonPublic |
                                        BindingFlags.Instance | BindingFlags.SetProperty;

                // For each property get the data from the reader to the object
                for (int i = 0; i < props.Length; i++)
                {
                    if (ColumnExists(DataReader, props[i].Name) && DataReader[props[i].Name] != DBNull.Value)
                        typeof(T).InvokeMember(props[i].Name, flags, null, newObjectToReturn, new Object[] { DataReader[props[i].Name] });
                }
            }

            if (!doNotCloseDataReader && !DataReader.IsClosed)
            {
                DataReader.Close();
            }

            return newObjectToReturn;
        }

        #endregion

        #region CopyDataReaderToObjectList ... (5 Overloads)

        public List<T> CopyDataReaderToObjectList<T>(string aCommandString, DataParameter aSqlParameter, bool doNotCloseDataReader = false)
        {
            return CopyDataReaderToObjectList<T>(GetSqlDataReader(aCommandString, aSqlParameter), doNotCloseDataReader);
        }

        public List<T> CopyDataReaderToObjectList<T>(string aCommandString, IList<DataParameter> aSqlParameters, bool doNotCloseDataReader = false)
        {
            return CopyDataReaderToObjectList<T>(GetSqlDataReader(aCommandString, aSqlParameters), doNotCloseDataReader);
        }

        public List<T> CopyDataReaderToObjectList<T>(string aCommandString, DataParameter aSqlParameter, CommandType aCommandType, bool doNotCloseDataReader = false)
        {
            return CopyDataReaderToObjectList<T>(GetSqlDataReader(aCommandString, aSqlParameter, aCommandType), doNotCloseDataReader);
        }

        public List<T> CopyDataReaderToObjectList<T>(string aCommandString, IList<DataParameter> aSqlParameters, CommandType aCommandType, bool doNotCloseDataReader = false)
        {
            return CopyDataReaderToObjectList<T>(GetSqlDataReader(aCommandString, aSqlParameters, aCommandType), doNotCloseDataReader);
        }

        public List<T> CopyDataReaderToObjectList<T>(SqlDataReader DataReader, bool doNotCloseDataReader = false)
        {
            List<T> newList = new List<T>();
            while (DataReader.Read())
            {
                newList.Add(CopyDataReaderToObject<T>(DataReader, false, true));
            }
            if (!doNotCloseDataReader && !DataReader.IsClosed)
            {
                DataReader.Close();
            }
            
            return newList;
        }
        #endregion

        #endregion

        #endregion

        #region Handling Database Connection .. Opening/Closing
        public bool CloseConnection()
        {
            if (_sqlConnection == null)
            {
                return true;
            }
            bool _connectionState = false;
            if (_sqlConnection.State == ConnectionState.Open)
            {
                try
                {
                    _sqlConnection.Close();
                }
                catch(Exception ex)
                {
                }
            }

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _connectionState = true;
            }

            return _connectionState;
        }

        public bool Openconnection()
        {
            bool _connectionState = false;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            if (_sqlConnection.State == ConnectionState.Open)
            {
                _connectionState = true;
            }

            return _connectionState;
        }

        #endregion

        public void Dispose()
        {
            if (_sqlDataAdapter != null)
            {
                _sqlDataAdapter.Dispose();
            }
            if (_sqlCommand != null)
            {
                _sqlCommand.Dispose();
            }
            CloseConnection();
            _sqlConnection.Dispose();
        }

        #region Private Methods
        /// <summary>
        /// Check if an SqlDataReader contains a field
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="columnName">The column name</param>
        /// <returns></returns>

        private DataListItem GetDataListItemSingleRow(SqlDataReader aSqlDataReader)
        {
            DataListItem _dataListItem = new DataListItem();
            if (aSqlDataReader.HasRows == true)
            {
                while (aSqlDataReader.Read())
                {
                    _dataListItem = new DataListItem(Convert.ToInt32(aSqlDataReader[0]), aSqlDataReader[1].ToString());
                }
            }
            return _dataListItem;
        }

        private bool ColumnExists(SqlDataReader reader, string columnName)
        {
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName= '" + columnName + "'";

            return (reader.GetSchemaTable().DefaultView.Count > 0);
        }

        private List<DataListItem> GetDataList(SqlDataReader aDataReader)
        {
            List<DataListItem> _dataListItem = new List<DataListItem>();
            if (aDataReader.HasRows == true)
            {
                while (aDataReader.Read())
                {
                    _dataListItem.Add(new DataListItem(Convert.ToInt32(aDataReader[0]), aDataReader[1].ToString()));
                }

                aDataReader.Close();
            }
            return _dataListItem;
        }

        #endregion
    }

    public class DataParameter
    {
        #region Class Level Variables
        public string ParameterName { get; set; }
        public SqlDbType ParameterDataType { get; set; }
        public object ParameterInitialValue { get; set; }
        public ParameterDirection ParameterAction { get; set; }
        #endregion

        #region Constructor (4 Overloads)

        public DataParameter(string aParameterName, SqlDbType aParameterDataType, ParameterDirection aParameterAction,
            object aParameterInitialValue)
        {
            this.ParameterName = aParameterName;
            this.ParameterDataType = aParameterDataType;
            this.ParameterInitialValue = aParameterInitialValue;
            this.ParameterAction = aParameterAction;
        }

        public DataParameter(string aParameterName, SqlDbType aParameterDataType,
            object aParameterInitialValue)
        {
            this.ParameterName = aParameterName;
            this.ParameterDataType = aParameterDataType;
            this.ParameterInitialValue = aParameterInitialValue;
            this.ParameterAction = ParameterDirection.Input;
        }

        public DataParameter(string aParameterName, SqlDbType aParameterDataType, int aParameterSize, ParameterDirection aParameterAction,
            object aParameterInitialValue)
        {
            this.ParameterName = aParameterName;
            this.ParameterDataType = aParameterDataType;
            this.ParameterInitialValue = aParameterInitialValue;
            this.ParameterAction = aParameterAction;
        }

        public DataParameter(string aParameterName, SqlDbType aParameterDataType, int aParameterSize,
            object aParameterInitialValue)
        {
            this.ParameterName = aParameterName;
            this.ParameterDataType = aParameterDataType;
            this.ParameterInitialValue = aParameterInitialValue;
            this.ParameterAction = ParameterDirection.Input;
        }

        #endregion
    }

    public class DataListItem
    {
        public int KeyID { get; set; }
        public string KeyText { get; set; }

        public DataListItem()
        {
        }

        public DataListItem(int aKeyID, string aKeytext)
        {
            this.KeyID = aKeyID;
            this.KeyText = aKeytext;
        }
    }
}