
using Antlr.Runtime.Misc;
using ParcialP3Entrega.Clases;
using ParcialP3Entrega.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static System.Net.WebRequestMethods;

namespace ParcialP3Entrega.Metodos
{
    public class CondicionPropiedadMetodo
    {

        private static CondicionPropiedadMetodo _intancia = null;



        public CondicionPropiedadMetodo()
        {
        }


        public static CondicionPropiedadMetodo Instancia
        {
            get
            {

                if (_intancia == null)
                {

                    _intancia = new CondicionPropiedadMetodo();
                }

                return _intancia;

            }

        }



        public List<CondicionPropiedad> Consulta()
        {

            List<CondicionPropiedad> oQuery = new List<CondicionPropiedad>();

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {

                using (SqlCommand cmd = new SqlCommand("sp_ObtenerCondicionPropiedad", cxn))
                {


                    cmd.CommandType = CommandType.StoredProcedure;


                    try
                    {

                        cxn.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {

                            while (rdr.Read())
                            {


                                oQuery.Add(new CondicionPropiedad()
                                {

                                    IdCondicion = Convert.ToInt32(rdr["IdCondicion"]),
                                    Descripcion = rdr["Descripcion"].ToString(),
                                    Activo = Convert.ToBoolean(rdr["Activo"])


                                });


                            }

                        }


                        return oQuery;


                    }
                    catch (Exception ex)
                    {


                        return null;


                    }

                }

            }


        }




        public bool Registrar(CondicionPropiedad oQuery)
        {

            bool respuesta = true;


            using (SqlConnection oConection = new SqlConnection(cnn.db))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarCondicionPropiedad", oConection);
                    cmd.Parameters.AddWithValue("Descripcion", oQuery.Descripcion);
                    cmd.Parameters.AddWithValue("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConection.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }


            }

            return true;

        }




        public bool Modificar(CondicionPropiedad oQuery)
        {

            bool respuesta = true;
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ModificarTipoPropiedad", cxn);
                    cmd.Parameters.AddWithValue("IdTipoPropiedad", oQuery.IdCondicion);
                    cmd.Parameters.AddWithValue("Descripcion", oQuery.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oQuery.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cxn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    respuesta |= false;
                }

            }

            return respuesta;

        }


        public bool Eliminar(int id)
        {

            bool respuesta = true;
            {

       

                try
                {
                    using (SqlConnection oConection = new SqlConnection(cnn.db))
                    {


                        SqlCommand cmd = new SqlCommand("DELETE FROM CondicionPropiedad WHERE IdCondion = @ID");
                        cmd.Parameters.AddWithValue("IdCondion", id);
                        oConection.Open();
                        cmd.ExecuteNonQuery();

                        respuesta = true;

                    }
                }
                catch (Exception ex)
                {

                    respuesta = false;

                }

                 return respuesta;

            }


        }


    }
}