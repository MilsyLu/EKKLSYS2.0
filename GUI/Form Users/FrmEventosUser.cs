using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI.Form_Users
{
    public partial class FrmEventosUser : Form
    {
        private readonly EventoService eventoService;
        private List<EventoDto> eventos;

        public FrmEventosUser()
        {
            InitializeComponent();
            eventoService = new EventoService();
            CargarEventos();
        }

        private void CargarEventos()
        {
            eventos = eventoService.ConsultarProximosEventosDTO();
            flpEventos.Controls.Clear();

            foreach (var evento in eventos)
            {
                // Panel principal para el evento
                Panel panel = new Panel
                {
                    Width = 250,
                    Height = 350,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };

                // Imagen del evento
                PictureBox pictureBox = new PictureBox
                {
                    Width = 250,
                    Height = 150,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Top
                };

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

                // Título del evento
                Label lblTitulo = new Label
                {
                    Text = evento.Titulo,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Width = 280,
                    Height = 30,
                    Location = new Point(10, 160)
                };

                // Fecha y hora
                Label lblFechaHora = new Label
                {
                    Text = $"{evento.Fecha:dd/MM/yyyy} - {evento.Hora}",
                    Width = 280,
                    Height = 20,
                    Location = new Point(10, 190)
                };

                // Descripción
                Label lblDescripcion = new Label
                {
                    Text = evento.Descripcion,
                    Width = 230,
                    Height = 60,
                    Location = new Point(10, 220),
                    AutoEllipsis = true
                };

                // Número de asistentes
                Label lblAsistentes = new Label
                {
                    Text = $"Asistentes: {evento.NumeroAsistentes}",
                    Width = 70,
                    Height = 20,
                    Location = new Point(10, 290)
                };

                // Botón para ver detalles
                Button btnVerDetalles = new Button
                {
                    Text = "Ver detalles",
                    Width = 140,
                    Height = 30,
                    Location = new Point(100, 285),
                    Tag = evento.Id
                };
                btnVerDetalles.Click += BtnVerDetalles_Click;

                // Agregar controles al panel
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(lblTitulo);
                panel.Controls.Add(lblFechaHora);
                panel.Controls.Add(lblDescripcion);
                panel.Controls.Add(lblAsistentes);
                panel.Controls.Add(btnVerDetalles);

                // Agregar panel al FlowLayoutPanel
                flpEventos.Controls.Add(panel);
            }
        }

        private void BtnVerDetalles_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int eventoId = (int)btn.Tag;

            FrmDetalleEventoAdmin detalleForm = new FrmDetalleEventoAdmin(eventoId);
            detalleForm.ShowDialog();

            // Recargar eventos al cerrar el formulario de detalles
            CargarEventos();
        }

        private void EventosForm_Load(object sender, EventArgs e)
        {

        }
    }
}
