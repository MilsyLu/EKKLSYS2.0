using BLL;
using ENTITY;
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
    public partial class CambiarPasswordFrm : Form
    {
        private Usuario usuario;
        private UsuarioService usuarioService;

        public CambiarPasswordFrm(Usuario usuarioActual)
        {
            InitializeComponent();
            usuario = usuarioActual;
            usuarioService = new UsuarioService();

            // Vincular el evento FormClosed
            this.FormClosed += CambiarPassword_FormClosed;

        }

        private void textCambioPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void CambiarPasswordFrm_Load(object sender, EventArgs e)
        {

        }

        private void CambiarPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            PerfilForm perfilForm = Application.OpenForms.OfType<PerfilForm>().FirstOrDefault();
            if (perfilForm != null)
            {
                perfilForm.Show(); // Mostrar el formulario PerfilForm si ya está abierto
            }
            else
            {
                perfilForm = new PerfilForm(); // Crear una nueva instancia si no está abierta
                perfilForm.Show();
            }
            
        }

        private void textCambioPassword1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textCambioPassword2_TextChanged(object sender, EventArgs e)
        {

        }

        private void brnCambiarPassword_Click(object sender, EventArgs e)
        {
            if (usuario == null)
            {
                MessageBox.Show("No se encontró al usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            CambiarPasswordFrm cambiarPassword = new CambiarPasswordFrm(usuario);
            //cambiarPassword.FormClosed += CambiarPassword_FormClosed;
            //cambiarPassword.Show();
            //this.Hide();

            if (string.IsNullOrWhiteSpace(textPasswordActual.Text) ||
                string.IsNullOrWhiteSpace(textNuevaPassword.Text) ||
                string.IsNullOrWhiteSpace(textConfirmarPassword.Text))
            {

                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            //validar la contraseña actual
            if (usuarioService.Login(usuario.Email, textPasswordActual.Text) == null)
            {
                MessageBox.Show("La contraseña actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //validar que la nueva contraseña y la confirmación sean iguales    
            if (textNuevaPassword.Text != textConfirmarPassword.Text)
            {
                MessageBox.Show("La nueva contraseña y la confirmación no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //validar que la nueva contraseña sea diferente a la actual
            if (textNuevaPassword.Text == textPasswordActual.Text)
            {
                MessageBox.Show("La nueva contraseña no puede ser igual a la actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Actualizar contraseña
            usuario.PasswordHash = textNuevaPassword.Text;
            usuario.PasswordHash = usuarioService.HashPassword(textNuevaPassword.Text);
            string resultado = usuarioService.Modificar(usuario);

            MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (resultado == "Contraseña actualizada correctamente")
            {
                // Cerrar el formulario
                this.Close();
            }
            //else
            //{
            //    // Mostrar mensaje de error
            //    MessageBox.Show("Error al cambiar la contraseña. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
