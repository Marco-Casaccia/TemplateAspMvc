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
    public static class UtilitiesDB
    {
        /// <summary>
        /// Reperimento della stringa di connessione SQL
        /// </summary>
        /// <returns>stringa di connessione</returns>
        public static string GetConnectionStringSQL()
        {
            string connectionString = "";
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; 
       
            }
            catch (Exception e)
            {
                throw new Exception("Si è verificato un errore nel GetConnectionStringSQL: " + e.Message);
            }
            finally
            {
            }
            return connectionString;

        }

    }
}
