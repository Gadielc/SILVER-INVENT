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

namespace SILVER_INVENTORY
{
    public partial class frm_administrador : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frm_administrador()
        {
            InitializeComponent();
        }

        private void frm_administrador_Load(object sender, EventArgs e)
        {

        }

        private void BTN_CERRAR_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("¿DESEA SALIR DEL SISTEMA?","SISTEMA",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
            {
                return;
            }
            else
            {
                this.Close();
                Form1 frm_login = new Form1();
                frm_login.Show();
            }
        }

        private void BTN_USUARIOS_Click(object sender, EventArgs e)
        {
            frm_usuarios usuarios = new frm_usuarios();
            usuarios.MdiParent = this;
            usuarios.Show();
        }
    }
}