namespace GUI
{
    partial class CambiarPasswordFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textPasswordActual = new System.Windows.Forms.TextBox();
            this.textNuevaPassword = new System.Windows.Forms.TextBox();
            this.textConfirmarPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.brnCambiarPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cambiar contraseña";
            // 
            // textPasswordActual
            // 
            this.textPasswordActual.Location = new System.Drawing.Point(132, 173);
            this.textPasswordActual.Name = "textPasswordActual";
            this.textPasswordActual.Size = new System.Drawing.Size(331, 22);
            this.textPasswordActual.TabIndex = 1;
            this.textPasswordActual.UseSystemPasswordChar = true;
            this.textPasswordActual.TextChanged += new System.EventHandler(this.textCambioPassword_TextChanged);
            // 
            // textNuevaPassword
            // 
            this.textNuevaPassword.Location = new System.Drawing.Point(132, 251);
            this.textNuevaPassword.Name = "textNuevaPassword";
            this.textNuevaPassword.Size = new System.Drawing.Size(331, 22);
            this.textNuevaPassword.TabIndex = 2;
            this.textNuevaPassword.UseSystemPasswordChar = true;
            this.textNuevaPassword.TextChanged += new System.EventHandler(this.textCambioPassword1_TextChanged);
            // 
            // textConfirmarPassword
            // 
            this.textConfirmarPassword.Location = new System.Drawing.Point(132, 331);
            this.textConfirmarPassword.Name = "textConfirmarPassword";
            this.textConfirmarPassword.Size = new System.Drawing.Size(331, 22);
            this.textConfirmarPassword.TabIndex = 3;
            this.textConfirmarPassword.UseSystemPasswordChar = true;
            this.textConfirmarPassword.TextChanged += new System.EventHandler(this.textCambioPassword2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Lavender;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña actual";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Lavender;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(132, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nueva contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Lavender;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Confirmar nueva contraseña";
            // 
            // brnCambiarPassword
            // 
            this.brnCambiarPassword.Location = new System.Drawing.Point(132, 399);
            this.brnCambiarPassword.Name = "brnCambiarPassword";
            this.brnCambiarPassword.Size = new System.Drawing.Size(164, 38);
            this.brnCambiarPassword.TabIndex = 7;
            this.brnCambiarPassword.Text = "Confirmar";
            this.brnCambiarPassword.UseVisualStyleBackColor = true;
            this.brnCambiarPassword.Click += new System.EventHandler(this.brnCambiarPassword_Click);
            // 
            // CambiarPasswordFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(800, 522);
            this.Controls.Add(this.brnCambiarPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textConfirmarPassword);
            this.Controls.Add(this.textNuevaPassword);
            this.Controls.Add(this.textPasswordActual);
            this.Controls.Add(this.label1);
            this.Name = "CambiarPasswordFrm";
            this.Text = "CambiarPasswordFrm";
            this.Load += new System.EventHandler(this.CambiarPasswordFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPasswordActual;
        private System.Windows.Forms.TextBox textNuevaPassword;
        private System.Windows.Forms.TextBox textConfirmarPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button brnCambiarPassword;
    }
}