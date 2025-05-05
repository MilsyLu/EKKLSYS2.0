using System;
using System.IO;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class FrmCrearCurso : Form
    {
        private readonly CursoService cursoService;
        private string rutaImagen;

        public FrmCrearCurso()
        {
            InitializeComponent();
            cursoService = new CursoService();
            dtpFechaInicio.MinDate = DateTime.Today;
            dtpFechaFin.MinDate = DateTime.Today;
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                Title = "Seleccionar imagen"
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                string.IsNullOrWhiteSpace(txtHorario.Text) ||
                string.IsNullOrWhiteSpace(txtDuracion.Text) ||
                string.IsNullOrWhiteSpace(txtInstructor.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtpFechaFin.Value < dtpFechaInicio.Value)
            {
                MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear directorio para imágenes si no existe
            string directorioImagenes = Path.Combine(Archivos.RUTA_BASE, "Imagenes", "Cursos");
            if (!Directory.Exists(directorioImagenes))
            {
                Directory.CreateDirectory(directorioImagenes);
            }

            // Copiar imagen a directorio de la aplicación si se seleccionó una
            string rutaImagenFinal = null;
            if (!string.IsNullOrEmpty(rutaImagen))
            {
                string nombreArchivo = $"curso_{DateTime.Now.Ticks}{Path.GetExtension(rutaImagen)}";
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

            // Crear curso
            Curso curso = new Curso
            {
                Titulo = txtTitulo.Text,
                FechaInicio = dtpFechaInicio.Value,
                FechaFin = dtpFechaFin.Value,
                Horario = txtHorario.Text,
                Duracion = txtDuracion.Text,
                Instructor = txtInstructor.Text,
                Descripcion = txtDescripcion.Text,
                Ubicacion = txtUbicacion.Text,
                Requisitos = txtRequisitos.Text,
                ImagenPortada = rutaImagenFinal
            };

            string resultado = cursoService.Guardar(curso);
            MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (resultado.Contains("correctamente"))
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CursoCrearForm_Load(object sender, EventArgs e)
        {

        }
    }
}