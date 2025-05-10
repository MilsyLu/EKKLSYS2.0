using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class PerfilForm : Form
    {
        private readonly UsuarioService usuarioService;
        private readonly EventoService eventoService;
        private readonly CursoService cursoService;
        private Usuario usuario;
        private string rutaImagen;

        public PerfilForm()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
            eventoService = new EventoService();
            cursoService = new CursoService();
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("No hay usuario en sesión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            usuario = usuarioService.BuscarId(Session.CurrentUser.Id);
            if (usuario == null)
            {
                MessageBox.Show("No se pudo cargar la información del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Cargar datos en los controles
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            dtpFechaNacimiento.Value = usuario.FechaNacimiento;
            txtDireccion.Text = usuario.Direccion;
            txtTelefono.Text = usuario.Telefono;
            txtEmail.Text = usuario.Email;
            txtEmail.ReadOnly = true; // No permitir cambiar el email

            if (usuario.EsCreyente == "Sí")
                rbSi.Checked = true;
            else
                rbNo.Checked = true;

            // Cargar imagen si existe
            if (!string.IsNullOrEmpty(usuario.FotoPerfil) && File.Exists(usuario.FotoPerfil))
            {
                try
                {
                    pictureBox.Image = Image.FromFile(usuario.FotoPerfil);
                    txtRutaImagen.Text = usuario.FotoPerfil;
                }
                catch
                {
                    pictureBox.Image = null;
                }
            }

            // Cargar eventos a los que asiste
            var asistencias = eventoService.ConsultarProximosEventosDTO();
            dgvEventos.Rows.Clear();
            foreach (var evento in asistencias)
            {
                bool asiste = eventoService.ConsultarAsistentes(evento.Id).Exists(u => u.Id == usuario.Id);
                if (asiste)
                {
                    dgvEventos.Rows.Add(evento.Id, evento.Titulo, evento.Fecha.ToShortDateString(), evento.Hora);
                }
            }

            // Cargar cursos en los que está inscrito
            var cursosDisponibles = cursoService.ConsultarCursosDisponiblesDTO();
            dgvCursos.Rows.Clear();
            foreach (var curso in cursosDisponibles)
            {
                bool inscrito = cursoService.ConsultarEstudiantes(curso.Id).Exists(u => u.Id == usuario.Id);
                if (inscrito)
                {
                    dgvCursos.Rows.Add(curso.Id, curso.Titulo, curso.FechaInicio.ToShortDateString(), curso.FechaFin.ToShortDateString(), curso.Horario);
                }
            }
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
                    pictureBox.Image = Image.FromFile(rutaImagen);
                }
                catch
                {
                    MessageBox.Show("No se pudo cargar la imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear directorio para imágenes si no existe
            string directorioImagenes = Path.Combine(Archivos.RUTA_BASE, "Imagenes", "Perfiles");
            if (!Directory.Exists(directorioImagenes))
            {
                Directory.CreateDirectory(directorioImagenes);
            }

            // Copiar imagen a directorio de la aplicación si se seleccionó una nueva
            string rutaImagenFinal = usuario.FotoPerfil;
            if (!string.IsNullOrEmpty(rutaImagen) && rutaImagen != usuario.FotoPerfil)
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

            // Actualizar usuario
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.FechaNacimiento = dtpFechaNacimiento.Value;
            usuario.Direccion = txtDireccion.Text;
            usuario.Telefono = txtTelefono.Text;
            usuario.FotoPerfil = rutaImagenFinal;
            usuario.EsCreyente = rbSi.Checked ? "Sí" : "No";

            string resultado = usuarioService.Modificar(usuario);
            MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (resultado.Contains("correctamente"))
            {
                // Actualizar usuario en sesión
                Session.CurrentUser = usuario;
            }
        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            // Implementar cambio de contraseña
            MessageBox.Show("Funcionalidad no implementada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}