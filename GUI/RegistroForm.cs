using System;
using System.IO;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class RegistroForm : Form
    {
        private readonly UsuarioService usuarioService;
        private string rutaImagen;

        public RegistroForm()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
            dtpFechaNacimiento.MaxDate = DateTime.Today.AddYears(-10); // Mínimo 10 años
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                Title = "Seleccionar imagen de perfil"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = openFileDialog.FileName;
                txtRutaImagen.Text = rutaImagen;

                try
                {
                    pictureBox.ImageLocation = rutaImagen;
                }
                catch
                {
                    MessageBox.Show("No se pudo cargar la imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear directorio para imágenes si no existe
            string directorioImagenes = Path.Combine(Archivos.RUTA_BASE, "Imagenes", "Perfiles");
            if (!Directory.Exists(directorioImagenes))
            {
                Directory.CreateDirectory(directorioImagenes);
            }

            // Copiar imagen a directorio de la aplicación si se seleccionó una
            string rutaImagenFinal = null;
            if (!string.IsNullOrEmpty(rutaImagen))
            {
                string nombreArchivo = $"perfil_{DateTime.Now.Ticks}{Path.GetExtension(rutaImagen)}";
                rutaImagenFinal = Path.Combine(directorioImagenes, nombreArchivo);

                try
                {
                    File.Copy(rutaImagen, rutaImagenFinal, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al copiar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Crear usuario
            Usuario usuario = new Usuario
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                FotoPerfil = rutaImagenFinal,
                EsCreyente = rbSi.Checked ? "Sí" : "No",
                PasswordHash = txtPassword.Text, // Se hasheará en el servicio
                FechaRegistro = DateTime.Now
            };

            string resultado = usuarioService.Guardar(usuario);
            MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (resultado.Contains("correctamente"))
            {
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra solo el formulario de registro
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // RegistroForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Name = "RegistroForm";
        //    this.Load += new System.EventHandler(this.RegistroForm_Load);
        //    this.ResumeLayout(false);

        //}

        private void RegistroForm_Load(object sender, EventArgs e)
        {

        }

        private void RegistroForm_Load_1(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}