using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI.Form_Users
{
    public partial class FrmDetalleEventoUser : Form
    {
        private readonly EventoService eventoService;
        private readonly int eventoId;
        private Evento evento;
        private EventoDto eventoDto;

        public FrmDetalleEventoUser(int eventoId)
        {
            InitializeComponent();
            this.eventoId = eventoId;
            eventoService = new EventoService();
            CargarEvento();
        }

        private void CargarEvento()
        {
            evento = eventoService.BuscarId(eventoId);
            if (evento == null)
            {
                MessageBox.Show("El evento no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Obtener el DTO para tener el número de asistentes
            var eventosDto = eventoService.ConsultarDTO();
            eventoDto = eventosDto.Find(e => e.Id == eventoId);

            // Cargar datos en los controles
            lblTitulo.Text = evento.Titulo;
            lblFecha.Text = $"Fecha: {evento.Fecha:dd/MM/yyyy}";
            lblHora.Text = $"Hora: {evento.Hora}";
            txtDescripcion.Text = evento.Descripcion;
            lblAsistentes.Text = $"Asistentes: {eventoDto?.NumeroAsistentes ?? 0}";

            // Cargar imagen si existe
            if (!string.IsNullOrEmpty(evento.ImagenPortada) && File.Exists(evento.ImagenPortada))
            {
                try
                {
                    pictureBox.Image = Image.FromFile(evento.ImagenPortada);
                }
                catch
                {
                    pictureBox.Image = null;
                }
            }

            // Verificar si el usuario actual ya está registrado
            bool yaRegistrado = false;
            if (Session.CurrentUser != null)
            {
                var asistencias = eventoService.ConsultarAsistentes(eventoId);
                yaRegistrado = asistencias.Exists(u => u.Id == Session.CurrentUser.Id);
            }

            // Configurar botón de asistencia
            btnAsistir.Text = yaRegistrado ? "Cancelar Asistencia" : "Registrar Asistencia";
            btnAsistir.Tag = yaRegistrado;
        }

        private void btnAsistir_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("Debe iniciar sesión para registrar asistencia", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool yaRegistrado = (bool)btnAsistir.Tag;
            string mensaje;

            if (yaRegistrado)
            {
                mensaje = eventoService.CancelarAsistencia(Session.CurrentUser.Id, eventoId);
            }
            else
            {
                mensaje = eventoService.RegistrarAsistencia(Session.CurrentUser.Id, eventoId);
            }

            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarEvento(); // Recargar para actualizar el estado
        }

        private void EventoDetalleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
