using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Web.Common.Helpers
{
    public static class DBHelper
    {
        /// <summary>
        /// Trasforma un risultato di DB in una stringa
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string GetString(object o)
        {
            if (o == DBNull.Value)
                return "";

            return o.ToString();
        }

        public static int? ConvertDBStringToIntNullable(string numero)
        {
            if (String.IsNullOrEmpty(numero))
                return null;
            else return ConvertDBStringToInt(numero);
        }

        public static Int32 GetInt32(object o)
        {
            int retValue;

            if (o == DBNull.Value)
            {
                retValue = 0;
            }
            else
            {
                int.TryParse(o.ToString(), out retValue);
            }

            return retValue;
        }

        public static Double GetDouble(object o)
        {
            double retValue;

            if (o == DBNull.Value)
            {
                retValue = 0D;
            }
            else
            {
                double.TryParse(o.ToString(), out retValue);
            }

            return retValue;
        }

        public static Decimal GetDecimal(object o)
        {
            Decimal retValue;

            if (o == DBNull.Value)
            {
                retValue = 0;
            }
            else
            {
                Decimal.TryParse(o.ToString(), out retValue);
            }

            return retValue;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime? ConvertDBStringToDatetime(string data)
        {
            DateTime? dataCalcolata = new DateTime();
            try
            {
                DateTime dt = new DateTime();
                DateTime.TryParse(data, out dt);
                dataCalcolata = dt;
            }
            catch (Exception e)
            {
                dataCalcolata = null;
            }
            finally { }
            return dataCalcolata;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static int ConvertDBStringToInt(string numero)
        {
            int retValue = 0;
            try
            {
                int.TryParse(numero, out retValue);
            }
            catch (Exception e)
            {
            }
            finally { }
            return retValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static double ConvertDBStringToDouble(string numero)
        {
            double retValue = 0;
            try
            {
                double.TryParse(numero, out retValue);
            }
            catch (Exception e)
            {
            }
            finally { }
            return retValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static bool ConvertDBStringToBool(string valore)
        {
            bool retValue = false;
            try
            {
                bool.TryParse(valore, out retValue);
            }
            catch (Exception e)
            {

            }
            finally { }
            return retValue;
        }
        /// <summary>
        /// Converte una stringa in un datetime nullable
        /// </summary>
        /// <param name="inString"></param>
        /// <returns>Datetime o NULL</returns>
        public static DateTime? ToNullableDate(string inString)
        {
            inString = inString.Trim();
            if (String.IsNullOrEmpty(inString))
                return null;
            return DateTime.Parse(inString, CultureInfo.InvariantCulture);
            //if (inString.Length == 10)
            //    return DateTime.Parse(inString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //else
            //    return DateTime.Parse(inString, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Converte una stringa in un datetime nullable
        /// </summary>
        /// <param name="inString"></param>
        /// <returns>Datetime o NULL</returns>
        public static DateTime ToDate(string inString)
        {
            inString = inString.Trim();
            if (String.IsNullOrEmpty(inString))
                return DateTime.MinValue;

            if (inString.Length == 10)
                return DateTime.ParseExact(inString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            else
                return DateTime.ParseExact(inString, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }
    }
}
