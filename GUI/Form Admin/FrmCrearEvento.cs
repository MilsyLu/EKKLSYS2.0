using System;
using System.IO;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class FrmCrearEvento : Form
    {
        private readonly EventoService eventoService;
        private string rutaImagen;

        public FrmCrearEvento()
        {
            InitializeComponent();
            eventoService = new EventoService();
            dtpFecha.MinDate = DateTime.Today;
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
                string.IsNullOrWhiteSpace(txtHora.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear directorio para imágenes si no existe
            string directorioImagenes = Path.Combine(Archivos.RUTA_BASE, "Imagenes", "Eventos");
            if (!Directory.Exists(directorioImagenes))
            {
                Directory.CreateDirectory(directorioImagenes);
            }

            // Copiar imagen a directorio de la aplicación si se seleccionó una
            string rutaImagenFinal = null;
            if (!string.IsNullOrEmpty(rutaImagen))
            {
                string nombreArchivo = $"evento_{DateTime.Now.Ticks}{Path.GetExtension(rutaImagen)}";
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

            // Crear evento
            Evento evento = new Evento
            {
                Titulo = txtTitulo.Text,
                Fecha = dtpFecha.Value,
                Hora = txtHora.Text,
                Descripcion = txtDescripcion.Text,
                ImagenPortada = rutaImagenFinal,
                FechaCreacion = DateTime.Now
            };

            string resultado = eventoService.Guardar(evento);
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

        private void EventoCrearForm_Load(object sender, EventArgs e)
        {

        }
    }
}