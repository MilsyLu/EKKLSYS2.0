using BLL;
using GUI.Form_Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmLogin: Form
    {
        private readonly UsuarioService usuarioService;
        public FrmLogin()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var usuario = usuarioService.Login(email, password);
            if (usuario != null)
            {
                // Guardar el usuario en sesión
                Session.CurrentUser = usuario;

                // Abrir el formulario principal
                FrmLobyAdmin mainForm = new FrmLobyAdmin();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistroForm registroForm = new RegistroForm();
            registroForm.Show();
            this.Hide();
        }

        private void btnLoginUser_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var usuario = usuarioService.Login(email, password);
            if (usuario != null)
            {
                // Guardar el usuario en sesión
                Session.CurrentUser = usuario;

                // Abrir el formulario principal
                FrmLobyUser mainForm = new FrmLobyUser();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lblinkRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistroForm registroForm = new RegistroForm();
            registroForm.Owner = this; // <-- Muy importante
            this.Hide();                // Opcional: oculta el login mientras se abre registro
            registroForm.ShowDialog();
            this.Show();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
