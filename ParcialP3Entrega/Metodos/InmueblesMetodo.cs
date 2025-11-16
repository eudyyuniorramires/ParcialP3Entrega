using ParcialP3Entrega.Clases;
using ParcialP3Entrega.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

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



        public bool Actualizar(InmueblesViewModels obj)
        {
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();

                SqlCommand cmd = new SqlCommand("sp_Inmueble_Inserar", cxn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreInmueble", obj.NombreInmueble);
                cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                cmd.Parameters.AddWithValue("@TipoPropiedad", obj.TipoPropiedad);
                cmd.Parameters.AddWithValue("@Condicion", obj.Condicion);
                cmd.Parameters.AddWithValue("@Ciudad", obj.Ciudad);
                cmd.Parameters.AddWithValue("@Precio", obj.Precio);
                cmd.Parameters.AddWithValue("@Habitacion", obj.Habitacion);
                cmd.Parameters.AddWithValue("@Bathroom", obj.Bathroom);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("@TipoNegocio", obj.TipoNegocio);
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public List<SelectListItem> ListarTipoPropiedad()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                SqlCommand cmd = new SqlCommand("sp_Listar_TipoPropiedad", cxn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rcd = cmd.ExecuteReader();
                while (rcd.Read())
                {
                    lista.Add(new SelectListItem
                    {
                        Value = rcd["ID"].ToString(),
                        Text = rcd["DESCRIPCION"].ToString()
                    });
                }
            }

            return lista;
        }


        public bool Eliminar(int id)
        {

            bool respuesta = true;
            {



                try
                {
                    using (SqlConnection oConection = new SqlConnection(cnn.db))
                    {


                        SqlCommand cmd = new SqlCommand("DELETE FROM CondicionPropiedad WHERE IdCondicion = @ID");
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


        public List<SelectListItem> ListarCondiciones()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                SqlCommand cmd = new SqlCommand("sp_Listar_Condiciones", cxn);
                cmd.CommandType = CommandType.StoredProcedure;
                ;
                SqlDataReader rcd = cmd.ExecuteReader();
                while (rcd.Read())
                {
                    lista.Add(new SelectListItem
                    {
                        Value = rcd["ID"].ToString(),
                        Text = rcd["DESCRIPCION"].ToString()
                    });
                }
            }

            return lista;
        }



        public List<SelectListItem> ListarCiudades()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                SqlCommand cmd = new SqlCommand("sp_Listar_Ciudades", cxn);
                cmd.CommandType = CommandType.StoredProcedure;
                ;
                SqlDataReader rcd = cmd.ExecuteReader();
                while (rcd.Read())
                {
                    lista.Add(new SelectListItem
                    {
                        Value = rcd["ID"].ToString(),
                        Text = rcd["NOMBRECIUDAD"].ToString()
                    });
                }
            }

            return lista;
        }

        public bool InsertarImagen(int idInmueble, byte[] imagen)
        {
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                SqlCommand cmd = new SqlCommand("sp_InmueblesImagen_Insertar", cxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdInmueble", idInmueble);
                cmd.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value = imagen;
                cxn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }



        public List<InmuebleImagenes> ListarImagenes(int idInmueble)
        {
            List<InmuebleImagenes> lista = new List<InmuebleImagenes>();
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                SqlCommand cmd = new SqlCommand("sp_Inmuebles_ListarImagenes", cxn);
                cmd.CommandType = CommandType.StoredProcedure;

                cxn.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lista.Add(new InmuebleImagenes
                    {
                        IdInmueble = Convert.ToInt32(rdr["IdInmueble"]),
                        IdFoto = Convert.ToInt32(rdr["IdFoto"]),
                        Imagen = (byte[])rdr["Imagen"]
                    });
                }
            }

            return lista;
        }


        public InmueblesViewModels ObtenerPorId(int id)
        {
            InmueblesViewModels model = null;

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerInmueblesPorId", cxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdInmueble", id);

                cxn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    model = new InmueblesViewModels()
                    {
                        IdInmueble = Convert.ToInt32(rdr["IdInmueble"]),
                        NombreInmueble = rdr["NombreInmueble"].ToString(),
                        Direccion = rdr["Direccion"].ToString(),
                        IdTipoPropiedad = Convert.ToInt32(rdr["IdTipoPropiedad"]),
                        IdCondicion = Convert.ToInt32(rdr["IdCondicion"].ToString()),
                        IdCiudad = Convert.ToInt32(rdr["IdCiudad"].ToString()),
                        Precio = Convert.ToDouble(rdr["Precio"]),
                        Habitacion = Convert.ToInt32(rdr["Habitacion"]),
                        Bathroom = Convert.ToInt32(rdr["Bathroom"]),
                        Descripcion = rdr["Descripcion"].ToString(),
                        TipoNegocio = rdr["TipoNegocio"].ToString(),
                    };
                }
            }

            return model;
        }

    }
}