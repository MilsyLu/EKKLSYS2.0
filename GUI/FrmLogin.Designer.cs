namespace GUI
{
    partial class FrmLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bllinkKeyForgot = new System.Windows.Forms.LinkLabel();
            this.btnLoginAdmin = new FontAwesome.Sharp.IconButton();
            this.btnLoginUser = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.lblinkRegistrarse = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 556);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::GUI.Properties.Resources.login;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(509, 556);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(715, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenid@";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(637, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese sus credenciales para ingresar al sistema";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(615, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Correo eléctronico:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(613, 190);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(357, 22);
            this.txtEmail.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(613, 278);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(357, 22);
            this.txtPassword.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(615, 239);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Contraseña:";
            // 
            // bllinkKeyForgot
            // 
            this.bllinkKeyForgot.AutoSize = true;
            this.bllinkKeyForgot.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bllinkKeyForgot.Location = new System.Drawing.Point(796, 242);
            this.bllinkKeyForgot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bllinkKeyForgot.Name = "bllinkKeyForgot";
            this.bllinkKeyForgot.Size = new System.Drawing.Size(161, 16);
            this.bllinkKeyForgot.TabIndex = 7;
            this.bllinkKeyForgot.TabStop = true;
            this.bllinkKeyForgot.Text = "¿Olvidaste tu contraseña?";
            // 
            // btnLoginAdmin
            // 
            this.btnLoginAdmin.BackColor = System.Drawing.Color.Green;
            this.btnLoginAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginAdmin.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginAdmin.ForeColor = System.Drawing.Color.Honeydew;
            this.btnLoginAdmin.IconChar = FontAwesome.Sharp.IconChar.SignIn;
            this.btnLoginAdmin.IconColor = System.Drawing.Color.White;
            this.btnLoginAdmin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLoginAdmin.IconSize = 30;
            this.btnLoginAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoginAdmin.Location = new System.Drawing.Point(617, 334);
            this.btnLoginAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoginAdmin.Name = "btnLoginAdmin";
            this.btnLoginAdmin.Size = new System.Drawing.Size(353, 43);
            this.btnLoginAdmin.TabIndex = 8;
            this.btnLoginAdmin.Text = "Iniciar sesión como admin";
            this.btnLoginAdmin.UseVisualStyleBackColor = false;
            this.btnLoginAdmin.Click += new System.EventHandler(this.btnLoginAdmin_Click);
            // 
            // btnLoginUser
            // 
            this.btnLoginUser.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoginUser.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginUser.ForeColor = System.Drawing.Color.Black;
            this.btnLoginUser.IconChar = FontAwesome.Sharp.IconChar.SignIn;
            this.btnLoginUser.IconColor = System.Drawing.Color.Black;
            this.btnLoginUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLoginUser.IconSize = 30;
            this.btnLoginUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoginUser.Location = new System.Drawing.Point(619, 384);
            this.btnLoginUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoginUser.Name = "btnLoginUser";
            this.btnLoginUser.Size = new System.Drawing.Size(353, 43);
            this.btnLoginUser.TabIndex = 9;
            this.btnLoginUser.Text = "Iniciar sesión como usuario";
            this.btnLoginUser.UseVisualStyleBackColor = false;
            this.btnLoginUser.Click += new System.EventHandler(this.btnLoginUser_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(615, 458);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "¿No tienes una cuenta?";
            // 
            // lblinkRegistrarse
            // 
            this.lblinkRegistrarse.AutoSize = true;
            this.lblinkRegistrarse.Location = new System.Drawing.Point(861, 458);
            this.lblinkRegistrarse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblinkRegistrarse.Name = "lblinkRegistrarse";
            this.lblinkRegistrarse.Size = new System.Drawing.Size(98, 16);
            this.lblinkRegistrarse.TabIndex = 11;
            this.lblinkRegistrarse.TabStop = true;
            this.lblinkRegistrarse.Text = "Regístrate aquí";
            this.lblinkRegistrarse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblinkRegistrarse_LinkClicked);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lblinkRegistrarse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLoginUser);
            this.Controls.Add(this.btnLoginAdmin);
            this.Controls.Add(this.bllinkKeyForgot);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel bllinkKeyForgot;
        private FontAwesome.Sharp.IconButton btnLoginAdmin;
        private FontAwesome.Sharp.IconButton btnLoginUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lblinkRegistrarse;
    }
}