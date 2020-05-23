using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SIMS.API.Helpers
{
    public static class CommonHelper
    {
        public static DataTable ToCustomDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            List<PropertyAndName> propertyAndName = new List<PropertyAndName>();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];

                DataTableFieldAttribute attributes = prop.Attributes.OfType<DataTableFieldAttribute>().Any() ? prop.Attributes.OfType<DataTableFieldAttribute>().FirstOrDefault() : null;
                if (attributes != null)
                {
                    table.Columns.Add(attributes.FieldName, attributes.DbType == null ? prop.PropertyType : attributes.DbType);
                    propertyAndName.Add(new PropertyAndName
                    {
                        ColumnName = attributes.FieldName,
                        PropertyName = prop.Name,
                        ColumnOrder = attributes.Order
                    });
                }
            }
            foreach (T item in data)
            {
                DataRow dr = table.NewRow();
                foreach (var name in propertyAndName)
                {
                    dr[name.ColumnName] = props[name.PropertyName].GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(dr);
            }
            if (propertyAndName.Any(x => x.ColumnOrder > 0))
            {
                propertyAndName = propertyAndName.OrderBy(x => x.ColumnOrder).ToList();
                for (int i = 0; i < propertyAndName.Count(); i++)
                {
                    table.Columns[propertyAndName[i].ColumnName].SetOrdinal(i);
                }
            }            
            return table;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class DataTableFieldAttribute : Attribute
    {
        public DataTableFieldAttribute(string FieldName)
        {
            this.FieldName = FieldName;
        }
        public DataTableFieldAttribute(string FieldName, int order)
        {
            this.FieldName = FieldName;
            Order = order;
            DbType = typeof(object);
        }
        public DataTableFieldAttribute(string FieldName, int order, Type DbType)
        {
            this.FieldName = FieldName;
            Order = order;
            this.DbType = DbType;
        }
        public string FieldName { get; private set; }
        public int Order { get; set; }
        public Type DbType { get; private set; }
    }
    public class PropertyAndName
    {
        public string ColumnName { get; set; }
        public string PropertyName { get; set; }
        public int ColumnOrder { get; set; }
    }
}
