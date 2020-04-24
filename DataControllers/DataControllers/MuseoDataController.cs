using Web.Common.Entities;
using Web.Common.Helpers;
using Web.Common.IDataControllers;
using Web.Common.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Web.DataControllers.DataControllers
{
    public class MuseoDataController : IMuseoDataControllers
    {
        


        /// <summary>
        /// Ricerca musei
        /// </summary>
        /// <param name="filtro">Filtro di ricerca</param>
        /// <returns>Musei trovati</returns>
        public Museo GetMuseo(int id)
        {
            Museo museo = new Museo();
            try
            {
                using (SqlConnection con = new SqlConnection(UtilitiesDB.GetConnectionStringSQL()))
                {

                    using (SqlCommand cmd = new SqlCommand("GetListMusei", con))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@IdMacroArea", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@DataDa", SqlDbType.VarChar, 50).Value = "";
                        cmd.Parameters.Add("@DataAl", SqlDbType.VarChar, 50).Value = "";
                     

                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (reader.Read())
                            {


                            
                                museo.Id = DBHelper.ConvertDBStringToInt(reader["Id"].ToString());
                                museo.nome = DBHelper.GetString(reader["nome"].ToString());
                                museo.descrizione = DBHelper.GetString(reader["descrizione"].ToString());
                                museo.data_creazione = reader.GetDateTime(reader.GetOrdinal("data_creazione"));
                                museo.zona = reader.GetString(reader.GetOrdinal("zona"));



                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Si è verificato un errore nel GetMuseo: " + ex.Message);
            }
            return museo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<Museo> GetListMusei(RequestMuseoFilter request)
        {
            List<Museo> list = new List<Museo>();
            try
            {
                using (SqlConnection con = new SqlConnection(UtilitiesDB.GetConnectionStringSQL()))
                {
                    using (SqlCommand cmd = new SqlCommand("GetListMusei", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@IdMacroArea", SqlDbType.Int).Value = request.IdMacroArea;
                        cmd.Parameters.Add("@DataDa", SqlDbType.VarChar, 50).Value = request.DataDa.Value.ToString("yyyyMMdd");
                        cmd.Parameters.Add("@DataAl", SqlDbType.VarChar, 50).Value = request.DataAl.Value.ToString("yyyyMMdd");
                      
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (reader.Read())
                            {
                                list.Add(PopulateMuseo(reader));

                            }
                        }
                        con.Close();
                     
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Si è verificato un errore nel GetListMusei: " + ex.Message);
            }
            finally
            {

            }
            return list;
        }

        /// <summary>
        /// Popolo la lista degli eventi
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public Museo PopulateMuseo(SqlDataReader reader)
        {
            return new Museo
            {

              
                Id = DBHelper.ConvertDBStringToInt(reader["Id"].ToString()),
                nome = DBHelper.GetString(reader["nome"].ToString()),
                descrizione = DBHelper.GetString(reader["descrizione"].ToString()),
                data_creazione = reader.GetDateTime(reader.GetOrdinal("data_creazione")),
                zona = reader.GetString(reader.GetOrdinal("zona"))

            };
        }


        /// <summary>
        /// Elenco macro aree
        /// </summary>
        /// <returns>macro aree trovate</returns>
        public List<MacroArea> GetMacroAree()
        {
            List<MacroArea> macroaree = new List<MacroArea>();

            try
            {
                using (SqlConnection con = new SqlConnection(UtilitiesDB.GetConnectionStringSQL()))
                {

                    using (SqlCommand cmd = new SqlCommand("GetMacroAree", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (reader.Read())
                            {

                                MacroArea macroarea = new MacroArea();
                                macroarea.id = reader.GetInt64(reader.GetOrdinal("id"));

                                if (reader.GetValue(reader.GetOrdinal("data_cancellazione")).ToString() != "")
                                {
                                    macroarea.data_cancellazione = DBHelper.ConvertDBStringToDatetime(reader.GetValue(reader.GetOrdinal("data_cancellazione")).ToString()).Value;
                                }
                                macroarea.zona = reader.GetString(reader.GetOrdinal("zona"));
                                macroarea.data_creazione = reader.GetDateTime(reader.GetOrdinal("data_creazione"));
                                macroarea.data_modifica = reader.GetDateTime(reader.GetOrdinal("data_modifica"));


                                macroaree.Add(macroarea);
                            }
                        }
                        con.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Si è verificato un errore nel GetMacroAree: " + ex.Message);
            }
            return macroaree;
        }

        /// <summary>
        /// Salva
        /// </summary>
        /// <param name="museo"></param>
        /// <returns></returns>
        public Museo Save(Museo museo)
        {
            if (museo.Id > 0)
            {
                return this.UpdateMuseo(museo);
            }
            else
            {
                return this.AddMuseo(museo);
            }
        }


        /// <summary>
        /// Delete row
        /// </summary>
        /// <param name="id"></param>
        public void DeleteMuseo(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(UtilitiesDB.GetConnectionStringSQL()))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteMuseo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Si è verificato un errore nel UpdateMuseo: " + ex.Message);
            }

        }



        /// <summary>
        /// Update row
        /// </summary>
        /// <param name="museo"></param>
        /// <returns></returns>
        private Museo UpdateMuseo(Museo museo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(UtilitiesDB.GetConnectionStringSQL()))
                {
                    using (SqlCommand cmd = new SqlCommand("UpDataMuseo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                       
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = museo.Id;
                        cmd.Parameters.Add("@id_macroaree", SqlDbType.Int).Value = museo.id_macroaree;
                        cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = museo.nome;
                        cmd.Parameters.Add("@descrizione", SqlDbType.VarChar).Value = museo.descrizione;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Si è verificato un errore nel UpdateMuseo: " + ex.Message);
            }
            return museo;
        }

        /// <summary>
        /// Inserimento row
        /// </summary>
        /// <param name="museo"></param>
        /// <returns></returns>
        private Museo AddMuseo(Museo museo)
        {
            Int32 Id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(UtilitiesDB.GetConnectionStringSQL()))
                {
                    using (SqlCommand cmd = new SqlCommand("AddMuseo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_macroaree", SqlDbType.Int).Value = museo.id_macroaree;
                        cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = museo.nome;
                        cmd.Parameters.Add("@descrizione", SqlDbType.VarChar).Value = museo.descrizione;
                        cmd.Parameters.Add(new SqlParameter("@returnId", SqlDbType.Int));
                        cmd.Parameters["@returnId"].Direction = ParameterDirection.Output;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Id = Convert.ToInt32(cmd.Parameters["@returnId"].Value);

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Si è verificato un errore nel AddMuseo: " + ex.Message);
            }
            return GetMuseo(Id);
        }
       
       


    }
}
