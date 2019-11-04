using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//LIBRERIAS PARA USAR SQL
using System.Data;
using System.Data.SqlClient;
//LIBRERIAS DEVEXPRESS
using DevExpress.XtraEditors;
//
using System.Configuration;


namespace SILVER_INVENTORY
{
    public class Metodos
    {
        public SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SILVER_INVENTORY.Properties.Settings.SILV_INVENTORYConnectionString"].ConnectionString.ToString());
        public SqlDataAdapter adaptador;
        public DataTable datatables;
        public SqlCommand comando;
        public SqlParameter mensaje;
        #region Basedatos
        public void ConectarBaseDatos()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

        public void DesconectarBaseDatos()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
        #endregion


        #region MetodosUsuario
        public  Boolean UsuarioRegistrado(string nombre_usuario)
        {
            Boolean resultado = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SILVER_INVENTORY.Properties.Settings.SILV_INVENTORYConnectionString"].ConnectionString.ToString()))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT* FROM SILV_USUARIOS WHERE US_USUARIO='" + nombre_usuario + "' AND US_ACTIVO_INACTIVO=1",conexion);
                    SqlDataReader lector;
                    lector = comando.ExecuteReader();

                    if (lector.Read())
                    {
                        resultado = true;
                    }
                    lector.Close();
                }
                
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message,"ERROR USUARIO REGISTRADO");
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        public String ExisteContrasena(string nombre_usuario)
        {
            string resultado = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SILVER_INVENTORY.Properties.Settings.SILV_INVENTORYConnectionString"].ConnectionString.ToString()))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT US_CONTRASENA FROM SILV_USUARIOS where US_USUARIO='"+nombre_usuario+ "' AND US_ACTIVO_INACTIVO=1",conexion);
                    SqlDataReader lector;
                    lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        {
                            resultado = Convert.ToString(lector["US_CONTRASENA"]);
                        }
                        lector.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message,"ERROR EXISTE CONTRASENA");
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        public int ConsultaTipoUsuario(string nombre_usuario)
        {
            int resultado=0;
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SILVER_INVENTORY.Properties.Settings.SILV_INVENTORYConnectionString"].ConnectionString.ToString()))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT US_TIPO_USUARIO FROM SILV_USUARIOS WHERE US_USUARIO='"+nombre_usuario+"' AND US_ACTIVO_INACTIVO=1",conexion);
                    SqlDataReader lector;
                    lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        resultado = Convert.ToInt32(lector["US_TIPO_USUARIO"]);
                    }
                    lector.Close();
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message,"ERROR CONSULTA TIPO USUARIO");
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }
        #endregion

    }
}
