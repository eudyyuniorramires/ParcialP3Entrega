using ParcialP3Entrega.Clases;
using ParcialP3Entrega.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PSC08.Metodos
{
    public class InmueblesMetodo
    {
        public List<InmueblesViewModels> Listar()
        {
            List<InmueblesViewModels> lista = new List<InmueblesViewModels>();
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                SqlCommand cmd = new SqlCommand("sp_inmuebles_listar", cxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cxn.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lista.Add(new InmueblesViewModels
                    {
                        IdInmueble = Convert.ToInt32(rdr["IdInmueble"]),
                        NombreInmueble = rdr["NombreInmueble"].ToString(),
                        Direccion = rdr["NombreInmueble"].ToString(),
                        TipoPropiedad = rdr["NombreInmueble"].ToString(),
                        Condicion = rdr["NombreInmueble"].ToString(),
                        Ciudad = rdr["NombreInmueble"].ToString(),
                        Precio = Convert.ToDouble(rdr["NombreInmueble"]),
                        Habitacion = Convert.ToInt32(rdr["NombreInmueble"]),
                        Bathroom = Convert.ToInt32(rdr["NombreInmueble"]),
                        Descripcion = rdr["NombreInmueble"].ToString(),
                        TipoNegocio = rdr["NombreInmueble"].ToString(),

                    });

                }
            }


            return lista;
        }



        public bool Insertar(InmueblesViewModels obj)
        {
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();

                SqlCommand cmd = new SqlCommand("", cxn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreInmueble", obj);
                cmd.Parameters.AddWithValue("@Direccion", obj);
                cmd.Parameters.AddWithValue("@TipoPropiedad", obj);
                cmd.Parameters.AddWithValue("@Condicion", obj);
                cmd.Parameters.AddWithValue("@Ciudad", obj);
                cmd.Parameters.AddWithValue("@Precio", obj);
                cmd.Parameters.AddWithValue("@Habitacion", obj);
                cmd.Parameters.AddWithValue("@Bathroom", obj);
                cmd.Parameters.AddWithValue("@Descripcion", obj);
                cmd.Parameters.AddWithValue("@TipoNegocio", obj);


                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}