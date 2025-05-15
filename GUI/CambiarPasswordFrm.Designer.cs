namespace GUI
{
    partial class CambiarPasswordFrm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textPasswordActual = new System.Windows.Forms.TextBox();
            this.textNuevaPassword = new System.Windows.Forms.TextBox();
            this.textConfirmarPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.brnCambiarPassword = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(84)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 64);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "CAMBIAR CONTRASEÑA";
            // 
            // textPasswordActual
            // 
            this.textPasswordActual.BackColor = System.Drawing.Color.White;
            this.textPasswordActual.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.textPasswordActual.Location = new System.Drawing.Point(26, 133);
            this.textPasswordActual.Name = "textPasswordActual";
            this.textPasswordActual.Size = new System.Drawing.Size(331, 26);
            this.textPasswordActual.TabIndex = 1;
            this.textPasswordActual.UseSystemPasswordChar = true;
            // 
            // textNuevaPassword
            // 
            this.textNuevaPassword.BackColor = System.Drawing.Color.White;
            this.textNuevaPassword.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.textNuevaPassword.Location = new System.Drawing.Point(26, 213);
            this.textNuevaPassword.Name = "textNuevaPassword";
            this.textNuevaPassword.Size = new System.Drawing.Size(331, 26);
            this.textNuevaPassword.TabIndex = 2;
            this.textNuevaPassword.UseSystemPasswordChar = true;
            // 
            // textConfirmarPassword
            // 
            this.textConfirmarPassword.BackColor = System.Drawing.Color.White;
            this.textConfirmarPassword.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.textConfirmarPassword.Location = new System.Drawing.Point(26, 293);
            this.textConfirmarPassword.Name = "textConfirmarPassword";
            this.textConfirmarPassword.Size = new System.Drawing.Size(331, 26);
            this.textConfirmarPassword.TabIndex = 3;
            this.textConfirmarPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña actual:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(23, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nueva contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(23, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Confirmar nueva contraseña:";
            // 
            // brnCambiarPassword
            // 
            this.brnCambiarPassword.BackColor = System.Drawing.Color.DarkOrchid;
            this.brnCambiarPassword.FlatAppearance.BorderSize = 0;
            this.brnCambiarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnCambiarPassword.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.brnCambiarPassword.ForeColor = System.Drawing.Color.White;
            this.brnCambiarPassword.Location = new System.Drawing.Point(242, 350);
            this.brnCambiarPassword.Name = "brnCambiarPassword";
            this.brnCambiarPassword.Size = new System.Drawing.Size(164, 38);
            this.brnCambiarPassword.TabIndex = 7;
            this.brnCambiarPassword.Text = "Confirmar";
            this.brnCambiarPassword.UseVisualStyleBackColor = false;
            // 
            // CambiarPasswordFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.brnCambiarPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textConfirmarPassword);
            this.Controls.Add(this.textNuevaPassword);
            this.Controls.Add(this.textPasswordActual);
            this.Controls.Add(this.panel1);
            this.Name = "CambiarPasswordFrm";
            this.Text = "Cambiar Contraseña";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
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