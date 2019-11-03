namespace SILVER_INVENTORY
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TXT_USUARIO = new DevExpress.XtraEditors.TextEdit();
            this.TXT_PASSWORD = new DevExpress.XtraEditors.TextEdit();
            this.BTN_SALIR = new DevExpress.XtraEditors.SimpleButton();
            this.BTN_ENTRAR = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_USUARIO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_PASSWORD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 60);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "USUARIO:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 107);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(85, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "CONTRASEÑA:";
            // 
            // TXT_USUARIO
            // 
            this.TXT_USUARIO.Location = new System.Drawing.Point(106, 52);
            this.TXT_USUARIO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TXT_USUARIO.Name = "TXT_USUARIO";
            this.TXT_USUARIO.Size = new System.Drawing.Size(215, 22);
            this.TXT_USUARIO.TabIndex = 2;
            // 
            // TXT_PASSWORD
            // 
            this.TXT_PASSWORD.Location = new System.Drawing.Point(106, 98);
            this.TXT_PASSWORD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TXT_PASSWORD.Name = "TXT_PASSWORD";
            this.TXT_PASSWORD.Properties.UseSystemPasswordChar = true;
            this.TXT_PASSWORD.Size = new System.Drawing.Size(215, 22);
            this.TXT_PASSWORD.TabIndex = 3;
            // 
            // BTN_SALIR
            // 
            this.BTN_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_SALIR.ImageOptions.Image = global::SILVER_INVENTORY.Properties.Resources.cancel_32x32;
            this.BTN_SALIR.Location = new System.Drawing.Point(217, 144);
            this.BTN_SALIR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_SALIR.Name = "BTN_SALIR";
            this.BTN_SALIR.Size = new System.Drawing.Size(104, 44);
            this.BTN_SALIR.TabIndex = 5;
            this.BTN_SALIR.Text = "&SALIR";
            this.BTN_SALIR.Click += new System.EventHandler(this.BTN_SALIR_Click);
            // 
            // BTN_ENTRAR
            // 
            this.BTN_ENTRAR.ImageOptions.Image = global::SILVER_INVENTORY.Properties.Resources.apply_32x32;
            this.BTN_ENTRAR.Location = new System.Drawing.Point(106, 144);
            this.BTN_ENTRAR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_ENTRAR.Name = "BTN_ENTRAR";
            this.BTN_ENTRAR.Size = new System.Drawing.Size(104, 44);
            this.BTN_ENTRAR.TabIndex = 4;
            this.BTN_ENTRAR.Text = "&ENTRAR";
            this.BTN_ENTRAR.Click += new System.EventHandler(this.BTN_ENTRAR_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.BTN_ENTRAR;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_SALIR;
            this.ClientSize = new System.Drawing.Size(383, 234);
            this.Controls.Add(this.BTN_SALIR);
            this.Controls.Add(this.BTN_ENTRAR);
            this.Controls.Add(this.TXT_PASSWORD);
            this.Controls.Add(this.TXT_USUARIO);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACCESO AL SISTEMA";
            ((System.ComponentModel.ISupportInitialize)(this.TXT_USUARIO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_PASSWORD.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TXT_USUARIO;
        private DevExpress.XtraEditors.TextEdit TXT_PASSWORD;
        private DevExpress.XtraEditors.SimpleButton BTN_ENTRAR;
        private DevExpress.XtraEditors.SimpleButton BTN_SALIR;
    }
}

