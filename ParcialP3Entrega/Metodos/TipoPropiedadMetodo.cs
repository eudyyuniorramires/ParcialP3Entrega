using Antlr.Runtime.Misc;
using ParcialP3Entrega.Clases;
using ParcialP3Entrega.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ParcialP3Entrega.Metodos
{
    public class TipoPropiedadMetodo
    {

        private static TipoPropiedadMetodo _intancia = null;



        public TipoPropiedadMetodo()
        {
        }


        public static TipoPropiedadMetodo Instancia 
        {
            get 
            {

                if (_intancia == null) 
                {

                    _intancia = new TipoPropiedadMetodo();
                }

                return _intancia;

            }

        }



        public List<TipoPropiedad> Lista() 
        {

            List<TipoPropiedad> rptLista = new List<TipoPropiedad>();

            using (SqlConnection cxn = new SqlConnection(cnn.db)) 
            {

                using (SqlCommand cmd = new SqlCommand("sp_obtenerTipoPropiedad" , cxn)) 
                {
                
                
                    cmd.CommandType = CommandType.StoredProcedure;


                    try
                    {

                        cxn.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader()) 
                        {

                            while (rdr.Read()) 
                            {


                                rptLista.Add(new TipoPropiedad()
                                {

                                    IdTipoPropiedad = Convert.ToInt32(rdr["IDTIPOPROPIEDAD"]),
                                    Descripcion = rdr["Descripcion"].ToString(),
                                    Activo = Convert.ToBoolean(rdr["Activo"])


                                });
                            
                            
                            }
                        
                        }


                        return rptLista;


                    }
                    catch (Exception ex) 
                    {


                        return null;

                    
                    }

                }
            
            }

        
        }




        public bool Registrar(TipoPropiedad oTP) 
        {

            Boolean respuesta = true;


            using (SqlConnection cxn = new SqlConnection(cnn.db)) 
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarTipoPropiedad", cxn);
                    cmd.Parameters.AddWithValue("Descripcion", oTP.Descripcion);
                    cmd.Parameters.AddWithValue("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cxn.Open();
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
    }
}