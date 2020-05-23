using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;

namespace PowerPack.Common.Helpers.Extensions
{
    public static class ConvertExtensions
    {
        #region ToInteger
        public static int ToInteger(this object value)
        {
            return ToInteger(Convert.ToString(value), 0);
        }

        public static int ToInteger(this object value, int defaultValue)
        {
            return ToInteger(Convert.ToString(value), defaultValue);
        }

        public static int ToInteger(this string value)
        {
            return ToInteger(value, 0);
        }

        public static int ToInteger(this string value, int defaultValue)
        {
            int result = defaultValue;
            int.TryParse(value, out result);
            return result;
        }

        #endregion

        #region ToShort
        public static short ToShort(this object value)
        {
            return ToShort(Convert.ToString(value), 0);
        }

        public static short ToShort(this object value, short defaultValue)
        {
            return ToShort(Convert.ToString(value), defaultValue);
        }

        public static short ToShort(this string value)
        {
            return ToShort(value, 0);
        }

        public static short ToShort(this string value, short defaultValue)
        {
            short result = defaultValue;
            short.TryParse(value, out result);
            return result;
        }

        #endregion

        #region ToLong
        public static long ToLong(this object value)
        {
            return ToLong(Convert.ToString(value), 0);
        }

        public static long ToLong(this object value, long defaultValue)
        {
            return ToLong(Convert.ToString(value), defaultValue);
        }

        public static long ToLong(this string value)
        {
            return ToLong(value, 0);
        }

        public static long ToLong(this string value, long defaultValue)
        {
            long result = defaultValue;
            long.TryParse(value, out result);
            return result;
        }

        #endregion

        #region ToDouble
        public static double ToDouble(this object value)
        {
            return ToDouble(Convert.ToString(value), 0);
        }

        public static double ToDouble(this object value, double defaultValue)
        {
            return ToDouble(Convert.ToString(value), defaultValue);
        }

        public static double ToDouble(this string value)
        {
            return ToDouble(value, 0);
        }

        public static double ToDouble(this string value, double defaultValue)
        {
            double result = defaultValue;
            double.TryParse(value, out result);
            return result;
        }

        #endregion

        #region ToBoolean
        public static bool ToBoolean(this object value)
        {
            return ToBoolean(Convert.ToString(value), false);
        }

        public static bool ToBoolean(this object value, bool defaultValue)
        {
            return ToBoolean(Convert.ToString(value), defaultValue);
        }

        public static bool ToBoolean(this string value)
        {
            return ToBoolean(value, false);
        }

        public static bool ToBoolean(this string value, bool defaultValue)
        {
            bool result = defaultValue;
            bool.TryParse(value, out result);
            return result;
        }

        #endregion

        #region ToTimeSpan
        public static TimeSpan ToTimeSpan(this object value)
        {
            return ToTimeSpan(Convert.ToString(value), TimeSpan.MinValue);
        }

        public static TimeSpan ToTimeSpan(this object value, TimeSpan defaultValue)
        {
            return ToTimeSpan(Convert.ToString(value), defaultValue);
        }

        public static TimeSpan ToTimeSpan(this string value)
        {
            return ToTimeSpan(value, TimeSpan.MinValue);
        }

        public static TimeSpan ToTimeSpan(this string value, TimeSpan defaultValue)
        {
            string[] timeArray = value.Split(' ');
            if (timeArray.Length > 1)
                value = timeArray[0];

            TimeSpan result = defaultValue;
            TimeSpan.TryParse(value, out result);
            return result;
        }

        #endregion

        #region DataType Checking Methods

        public static bool IsNumeric(this object value)
        {
            return IsNumeric(Convert.ToString(value));
        }

        public static bool IsNumeric(this string value)
        {
            double retVal;
            return double.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retVal);
        }
        public static bool IsNumeric(this string value, System.Globalization.NumberStyles numberStyle)
        {
            double retVal;
            return double.TryParse(value, numberStyle, System.Globalization.NumberFormatInfo.InvariantInfo, out retVal);
        }

        public static bool IsBoolean(this object value)
        {
            return IsBoolean(Convert.ToString(value));
        }

        public static bool IsBoolean(this string value)
        {
            bool retVal;
            return bool.TryParse(Convert.ToString(value), out retVal);
        }

        #endregion

        #region ToDateTime
        public static DateTime ToDateTime(this string value)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(value, out result);
            return result;
        }
        public static DateTime ToDateTime(this string value, DateTime defaultVal)
        {
            DateTime result = defaultVal;
            DateTime.TryParse(value, out result);
            return result;
        }
        public static DateTime ToDateTime(this object value)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(Convert.ToString(value), out result);
            return result;
        }
        public static DateTime ToDateTime(this object value, DateTime defaultVal)
        {
            DateTime result = defaultVal;
            DateTime.TryParse(Convert.ToString(value), out result);
            return result;
        }
        public static string FormatDate(this object value)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(Convert.ToString(value), out result);
            return result.ToString("dd-MMM-yyyy");
        }
        public static string ToFormatedDate(this object value, string format)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(Convert.ToString(value), out result);
            return result.ToString(format);
        }
        public static string ToFormatedDate(this object value)
        {
            return ToFormatedDate(value, "MMMM dd yyyy");
        }
        public static string FormatDate(this object value, DateTime defaultVal)
        {
            DateTime result = defaultVal;
            DateTime.TryParse(Convert.ToString(value), out result);
            return result.ToString("dd-MMM-yyyy");
        }
        #endregion

        #region test
        public static byte[] ToBytes(this System.Data.DataTable data)
        {
            System.Web.UI.WebControls.GridView grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = data;
            grid.DataBind();

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grid.RenderControl(htw);

            return Encoding.ASCII.GetBytes(sw.ToString());
        }
        #endregion

        #region ToEnum
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        #endregion

        #region Guid

        public static bool IsGuid(this object value)
        {
            return value.ToGuid() != Guid.Empty;
        }

        public static Guid ToGuid(this object value)
        {
            Guid returnValue = Guid.Empty;
            Guid.TryParse(Convert.ToString(value), out returnValue);
            return returnValue;
        }

        #endregion

        #region Datatable to Byte Array
        public static byte[] ToByteArray(this DataTable dt)
        {
            MemoryStream stream = new MemoryStream();
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            formatter.Serialize(stream, dt);
            return stream.GetBuffer();
        }

        #endregion

        #region To generic list

        public static T ToList<T>(this string value) where T : class
        {
            return ToList(value, default(T));
        }

        public static T ToList<T>(this string value, T defaultValue) where T : class
        {
            T result = defaultValue;
            try
            {
                return EntityMapper<string, T>.MapFromJson(value);
            }
            catch (Exception)
            {
                return result;
            }
        }
        #endregion

    }
}
