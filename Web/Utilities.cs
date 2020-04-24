using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Reflection;
using System.ComponentModel;
using System.Data.SqlClient;
using Web.Common.Session;

namespace Web
{
    /// <summary>
    /// Clase utility
    /// </summary>
    public static class Utilities
    {
        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
        public static string GetDescription(Enum en)
        {
            return en.DescriptionAttr();
        }
        ///// <summary>
        ///// Reperimento della stringa di connessione SQL
        ///// </summary>
        ///// <returns>stringa di connessione</returns>
        //public static string GetConnectionStringSQL()
        //{
        //    string connectionString = "";
        //    try
        //    {
        //        connectionString = SessionScope.Instance.ConnectionStringSQL;
        //        if (string.IsNullOrWhiteSpace(connectionString))
        //            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    }
        //    catch (Exception e)
        //    {
        //        connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    }
        //    finally
        //    {
        //    }
        //    return connectionString;

        //}

    }
}
