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
        //SE CREA UNA INSTANCIA A LA CLASE METODOS PARA PODER UTILIZAR SUS VARIABLES, METODOS
        Metodos mt = new Metodos();
        public frm_usuarios()
        {
            InitializeComponent();
        }
        /*
        LIMPIAR CAMPOS 
        */
        public void LimpiarCampos()
        {
            TXT_ID.ResetText();
            TXT_NAME.ResetText();
            TXT_PASSWORD.ResetText();
            TXT_USERNAME.ResetText();
        }
        /*
        LLENAR GRIDCONTROL 
        */
        public void LlenarTabla()
        {
            using (SqlConnection conexion=new SqlConnection(ConfigurationManager.ConnectionStrings["PVGLASSESS.Properties.Settings.NuevaImagenConnectionString"].ConnectionString.ToString()))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SP_SILV_USUARIOS_VIEW", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    /*parametros*/
                    SqlParameter mensaje = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                    mensaje.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(mensaje);
                    int filas = comando.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        LBL_RESULT.Visibility = BarItemVisibility.Always;
                        LBL_RESULT.Caption = Convert.ToString(mensaje);
                    }
                    else
                    {
                        LBL_RESULT.Visibility = BarItemVisibility.Always;
                        LBL_RESULT.Caption = Convert.ToString(mensaje);
                    }
                    mt.adaptador = new SqlDataAdapter(comando);
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
                    conexion.Close();
                }
                
            }
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
                    using (SqlConnection conexion =new SqlConnection(ConfigurationManager.ConnectionStrings["SILVER_INVENTORY.Properties.Settings.SILV_INVENTORYConnectionString"].ConnectionString.ToString()))
                    {
                        conexion.Open();
                        mt.comando = new SqlCommand("SP_GLASS_ARTICULOS_INSERT", conexion);
                        mt.comando.CommandType = CommandType.StoredProcedure;
                        //Parametros del command SP
                        
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void BTN_SHOW_ItemClick(object sender, ItemClickEventArgs e)
        {
            LlenarTabla();
        }

        private void BTN_PRINT_ItemClick(object sender, ItemClickEventArgs e)
        {
            DGV_DATA.PrintDialog();
        }

        private void BTN_PREVIEW_ItemClick(object sender, ItemClickEventArgs e)
        {
            DGV_DATA.ShowRibbonPrintPreview();
        }

        private void SHOW_PANEL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.G_DATA.OptionsFind.AlwaysVisible = true;
            SHOW_PANEL.Enabled = false;
            HIDE_PANEL.Enabled = true;
        }

        private void HIDE_PANEL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.G_DATA.OptionsFind.AlwaysVisible = false;
            SHOW_PANEL.Enabled = true;
            HIDE_PANEL.Enabled = false;
        }

        private void VIEW_AUTOFILTER_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.G_DATA.OptionsView.ShowAutoFilterRow = true;
            VIEW_AUTOFILTER.Enabled = false;
            HIDE_PANEL.Enabled = false;
        }

        private void BTN_CLEAR_ItemClick(object sender, ItemClickEventArgs e)
        {
            LimpiarCampos();
        }

        private void BTN_EDIT_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TXT_ID.Text=="")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    finally
                    {

                    }
                }
            }
        }
    }
}