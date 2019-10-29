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
            try
            {
                mt.ConectarBaseDatos();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                mt.DesconectarBaseDatos();
            }
        }
    }
}
