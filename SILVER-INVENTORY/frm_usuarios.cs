using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;


namespace SILVER_INVENTORY
{
    public partial class frm_usuarios : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Metodos mt = new Metodos();
        public frm_usuarios()
        {
            InitializeComponent();
        }
        /*
        LLENAR GRIDCONTROL 
        */
        public void LlenarTabla()
        {
            //using (SqlConnection conexion=new SqlConnection(ConfigurationManager.ConnectionStrings["SILVER_INVENTORY.Properties.Settings.SILV_INVENTORYConnectionString"].ConnectionString.ToString()))
            
                try
                {
                    mt.ConectarBaseDatos();
                    mt.comando = new SqlCommand("SP_SILV_USUARIOS_VIEW", mt.conexion);
                    mt.comando.CommandType = CommandType.StoredProcedure;
                    /*parametros*/
                    mt.mensaje = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                    mt.mensaje.Direction = ParameterDirection.Output;
                    mt.comando.Parameters.Add(mt.mensaje);
                    int filas = mt.comando.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        LBL_RESULT.Visibility = BarItemVisibility.Always;
                        LBL_RESULT.Caption = Convert.ToString(mt.mensaje);
                    }
                    else
                    {
                        LBL_RESULT.Visibility = BarItemVisibility.Always;
                        LBL_RESULT.Caption = Convert.ToString(mt.mensaje);
                    }
                    mt.adaptador = new SqlDataAdapter(mt.comando);
                    mt.datatables = new DataTable();
                    mt.adaptador.Fill(mt.datatables);
                    DGV_DATA.DataSource = mt.datatables;
                    G_DATA.BestFitColumns();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                mt.DesconectarBaseDatos();
                }
                
            
        }
        public void LimpiarCampos()
        {
            TXT_ID.ResetText();
            TXT_NAME.ResetText();
            TXT_PASSWORD.ResetText();
            TXT_USERNAME.ResetText();
            C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked;
            LlenarTabla();
        }
        private void frm_usuarios_Load(object sender, EventArgs e)
        {
           
        }

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool validar = false;
            if (TXT_NAME.Text=="")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL USUARIO","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                validar = true;
                return;
            }
            if (TXT_USERNAME.Text=="")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL USUARIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                validar = true;
                return;
            }
            if (TXT_PASSWORD.Text=="")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA CONTRASEÑA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                validar = true;
                return;
            }
            if (validar==true)
            {
                XtraMessageBox.Show("FALTA INFORMACION POR ESPECIFICAR","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    mt.ConectarBaseDatos();
                    mt.comando = new SqlCommand("SP_SILV_USUARIOS_INSERT",mt.conexion);
                    mt.comando.CommandType = CommandType.StoredProcedure;
                    //parametros
                    mt.comando.Parameters.Add("@US_NOMBRE_USUARIO",SqlDbType.NVarChar,100);
                    mt.comando.Parameters.Add("@US_USUARIO",SqlDbType.NVarChar,50);
                    mt.comando.Parameters.Add("@US_CONTRASENA",SqlDbType.NVarChar,50);
                    mt.comando.Parameters.Add("@US_TIPO_USUARIO",SqlDbType.Int);

                    mt.mensaje = new SqlParameter("@MENSAJE",SqlDbType.NVarChar,200);
                    mt.mensaje.Direction = ParameterDirection.Output;
                    mt.comando.Parameters.Add(mt.mensaje);
                    int filas = mt.comando.ExecuteNonQuery();
                    if (filas>0)
                    {
                        XtraMessageBox.Show(Convert.ToString(mt.mensaje.Value),"SISTEMA",MessageBoxButtons.OK);
                    }
                    else
                    {
                        XtraMessageBox.Show(Convert.ToString(mt.mensaje.Value),"SISTEMA",MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    mt.DesconectarBaseDatos();
                    LimpiarCampos();
                }
            }
        }

        private void BTN_SHOW_ItemClick(object sender, ItemClickEventArgs e)
        {
            LlenarTabla();
        }

        private void BTN_EDIT_ItemClick(object sender, ItemClickEventArgs e)
        {
            /*
             * la logica siguiente indica que si no se encuentra un valor en el campo ID este no podra modificar el registro,
             * si no se encuntran los valores a modificar este mandara un mensaje de alerta
             * RETURN cancela la operacion actual del evento
             * */
            bool validarCampo = false;

            if (TXT_ID.Text=="")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL ID DEL REGISTRO A MODIFICAR","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                validarCampo = true;
                return;
            }
            if (TXT_NAME.Text=="")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL USUARIO","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                validarCampo = true;
                return;
            }
            if (TXT_USERNAME.Text=="")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL USERNAME DEL USUARIO","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                validarCampo = true;
                return;
            }
            if (TXT_PASSWORD.Text=="")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA CONTRASENA DEL USUARIO","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                validarCampo = true;
                return;
            }

            if (validarCampo==true)
            {
                XtraMessageBox.Show("FALTA INFORMACION POR ESPECIFICAR ANTES DE LA MODIFICACION DEL REGISTRO","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (XtraMessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DEL USUARIO?","SISTEMA",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        mt.ConectarBaseDatos();
                        mt.comando = new SqlCommand("",mt.conexion);
                        mt.comando.CommandType = CommandType.StoredProcedure;
                        //parametros
                    }
                    catch (Exception ex)
                    {

                        XtraMessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
                    }
                    finally
                    {
                        mt.DesconectarBaseDatos();
                        LimpiarCampos();
                    }
                }
            }
        }

        private void TXT_ID_TextChanged(object sender, EventArgs e)
        {
            //VERIFICAMOS QUE SE ENCUENTRE UN VALOR PARA PODER HABILITAR LOS BOTONES DE MODIFICAR Y ELIMINAR
            //YA QUE LOGICAMETE SOLO EL BOTON GUARDAR ESTA HABILITADO
            if (TXT_ID.Text=="")
            {
                BTN_EDIT.Enabled = false;
                BTN_DELETE.Enabled = false;
                BTN_SAVE.Enabled = true;
            }
            else
            {
                BTN_SAVE.Enabled = false;
                BTN_EDIT.Enabled = true;
                BTN_DELETE.Enabled = true;
            }
        }

        private void BTN_CLEAR_ItemClick(object sender, ItemClickEventArgs e)
        {
            LimpiarCampos();
        }

        private void BTN_PRINT_ItemClick(object sender, ItemClickEventArgs e)
        {
            DGV_DATA.PrintDialog();//solo muestra un cuadro de dialogo para imprimir
        }

        private void BTN_PREVIEW_ItemClick(object sender, ItemClickEventArgs e)
        {
            DGV_DATA.ShowRibbonPrintPreview();//muestra un cuadro de dialogo mas completo donde se puede imprimir y exportar
        }
    }
}