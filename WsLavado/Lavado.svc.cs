using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace WsLavado
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WsLavador : ILavado//la clase deberia llamarse lavado, es para confundirse al momento de leer el codigo porque aqui van todas las funciones de todos los servicios
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["lavadocon"].ConnectionString;
        public DatosLavador BuscarLavador(int IdLavador)
        {
            DatosLavador nuevoLavador = new DatosLavador();
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("pLavador", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operacion", "B");
                cmd.Parameters.AddWithValue("@IdLavador", IdLavador);

                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)//termina esta parte
                {
                    if (rd.Read())
                    {
                        nuevoLavador.IdLavador = rd.GetInt32(0);
                        nuevoLavador.NombreLavador = rd.GetString(1);
                        nuevoLavador.TelefonoLavador = rd.GetInt32(2);
                        nuevoLavador.NumeroDocumento = rd.GetInt32(3);
                    }
                    else
                    {
                        //throw new Exception("No hay registros");
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                //throw new Exception("Error al eliminar", ex);
            }
            return nuevoLavador;
        }

        public int EditarLavador(DatosLavador Lavador)
        {
            int res = 0;
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("pLavador", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operacion", "A");
                cmd.Parameters.AddWithValue("@IdLavador", Lavador.IdLavador);
                cmd.Parameters.AddWithValue("@NombreLavador", Lavador.NombreLavador);
                cmd.Parameters.AddWithValue("@TelefonoLavador", Lavador.TelefonoLavador);
                cmd.Parameters.AddWithValue("@NumeroDocumento", Lavador.NumeroDocumento);
                res = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar", ex);
            }
            return res;
        }

        public int EliminarLavador(int IdLavador)
        {
            int res = 0;
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("pLavador", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operacion", "E");
                cmd.Parameters.AddWithValue("@IdLavador", IdLavador);
                res = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar", ex);
            }
            return res;
        }

        public List<DatosLavador> MostrarLavador()
        {
            List<DatosLavador> lista = new List<DatosLavador>();
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("pLavador", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operacion", "L");
                cmd.Parameters.AddWithValue("@IdLavador", "");

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lista.Add(new DatosLavador
                    {
                        IdLavador=rd.GetInt32(0),
                        NombreLavador=rd.GetString(1),
                        TelefonoLavador=rd.GetInt32(2),
                        NumeroDocumento=rd.GetInt32(3)
                    });
                }


                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listarr", ex);
            }
            return lista;
        }

        public int NuevoLavador(DatosLavador Lavador)
        {
            int res = 0;
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("pLavador", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operacion", "I");
                cmd.Parameters.AddWithValue("@IdLavador", Lavador.IdLavador);
                cmd.Parameters.AddWithValue("@NombreLavador", Lavador.NombreLavador);
                cmd.Parameters.AddWithValue("@TelefonoLavador", Lavador.TelefonoLavador);
                cmd.Parameters.AddWithValue("@NumeroDocumento", Lavador.NumeroDocumento);
                res = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar", ex);
            }
            return res;
        }
        //Servicio

        


        public DatosServicio BuscarServicio(int IdServicio)
        {
            DatosServicio nuevoServicio = new DatosServicio();
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("pServicio", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operacion", "B");
                cmd.Parameters.AddWithValue("@IdServicio", IdServicio);

                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)//termina esta parte
                {
                    if (rd.Read())
                    {
                        nuevoServicio.IdServicio = rd.GetInt32(0);
                        nuevoServicio.Servicio = rd.GetString(1);
                        nuevoServicio.CostoServicio = rd.GetFloat(2);
                    }
                    else
                    {
                        //throw new Exception("No hay registros");
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                //throw new Exception("Error al eliminar", ex);
            }
            return nuevoServicio;
        }
        public int EditarServicio(DatosServicio Servicio)
        {
            int res = 0;
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("pServicio", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operacion", "A");
                cmd.Parameters.AddWithValue("@IdServicio", Servicio.IdServicio);
                cmd.Parameters.AddWithValue("@Servicio", Servicio.Servicio);
                cmd.Parameters.AddWithValue("@CostoServicio", Servicio.CostoServicio);
                res = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar", ex);
            }
            return res;
        }

        public int EliminarServicio(int IdServicio)
        {
            int res = 0;
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("pServicio", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operacion", "E");
                cmd.Parameters.AddWithValue("@IdServicio", IdServicio);
                res = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar", ex);
            }
            return res;
        }

        public List<DatosServicio> MostrarServicio()
        {
            List<DatosServicio> lista = new List<DatosServicio>();
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("pServicio", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operacion", "L");
                cmd.Parameters.AddWithValue("@IdServicio", "");

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lista.Add(new DatosServicio
                    {
                        IdServicio = rd.GetInt32(0),
                        Servicio = rd.GetString(1),
                        CostoServicio = rd.GetFloat(2)
                    });
                }


                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listarr", ex);
            }
            return lista;
        }

        public int NuevoServicio(DatosServicio Servicio)
        {
            int res = 0;
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("pServicio", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operacion", "I");
                cmd.Parameters.AddWithValue("@IdServicio", Servicio.IdServicio);
                cmd.Parameters.AddWithValue("@Servicio", Servicio.Servicio);
                cmd.Parameters.AddWithValue("@CostoServicio", Servicio.CostoServicio);
                res = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar", ex);
            }
            return res;

        }
         
         //





    }
}
