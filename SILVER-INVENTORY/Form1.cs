using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//LIBRERIA DEVEXPRESS PARA EL FORMATO DEL MESSAGEBOX
using DevExpress.XtraEditors;
//LIBRERIRAS SQL
using System.Data.SqlClient;
//LIBRERIAS CONFIG
using System.Configuration;

namespace SILVER_INVENTORY
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        Metodos mt = new Metodos();
        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_SALIR_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("¿DESEA SALIR DEL SISTEMA COMPLETAMENTE?","SISTEMA",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
            {
                return;
            }
            else
            {
                this.Close();
                Application.ExitThread();
                Application.Exit();
            }
        }

        private void BTN_ENTRAR_Click(object sender, EventArgs e)
        {
            bool valida = false;
            if (TXT_USUARIO.Text=="")
            {
                XtraMessageBox.Show("DEBES ESPECIFICAR EL NOMBRE DEL USUARIO","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                valida = true;
                return;
            }

            if (TXT_PASSWORD.Text=="")
            {
                XtraMessageBox.Show("","",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                valida = true;
                return;
            }

            if (valida==true)
            {
                XtraMessageBox.Show("FALTA INFORMACION POR ESPECIFICAR","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    mt.ConectarBaseDatos();
                    using (SqlConnection conexion=new SqlConnection(ConfigurationManager.ConnectionStrings["SILVER_INVENTORY.Properties.Settings.SILV_INVENTORYConnectionString"].ConnectionString.ToString()))
                    {
                        if (mt.UsuarioRegistrado(TXT_USUARIO.Text)==true)
                        {
                            string contrasena = mt.ExisteContrasena(TXT_USUARIO.Text);
                            if (contrasena.Equals(TXT_PASSWORD.Text)==true)
                            {
                                this.Hide();
                                if (mt.ConsultaTipoUsuario(TXT_USUARIO.Text)==1)
                                {
                                    frm_administrador frm_admin = new frm_administrador();
                                    frm_admin.Show();
                                }
                                else if (mt.ConsultaTipoUsuario(TXT_USUARIO.Text)==2)
                                {

                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message,"ERROR LOGIN",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    mt.DesconectarBaseDatos();
                }
            }

            
        }
    }
}
