using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI.Form_Users
{
    public partial class FrmCursosUser : Form
    {
        private readonly CursoService cursoService;
        private List<CursoDto> cursos;

        public FrmCursosUser()
        {
            InitializeComponent();
            cursoService = new CursoService();
            CargarCursos();
        }

        private void CargarCursos()
        {
            cursos = cursoService.ConsultarCursosDisponiblesDTO();
            flpCursos.Controls.Clear();

            foreach (var curso in cursos)
            {
                Panel panel = new Panel
                {
                    Width = 250,
                    Height = 355,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };

                PictureBox pictureBox = new PictureBox
                {
                    Width = 250,
                    Height = 150,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Top
                };

                if (!string.IsNullOrEmpty(curso.ImagenPortada) && File.Exists(curso.ImagenPortada))
                {
                    try
                    {
                        pictureBox.Image = Image.FromFile(curso.ImagenPortada);
                    }
                    catch
                    {
                        pictureBox.Image = null;
                    }
                }

                Label lblTitulo = new Label
                {
                    Text = curso.Titulo,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Width = 230,
                    Height = 30,
                    Location = new Point(10, 160)
                };

                Label lblFechas = new Label
                {
                    Text = $"Del {curso.FechaInicio:dd/MM/yyyy} al {curso.FechaFin:dd/MM/yyyy}",
                    Width = 230,
                    Height = 20,
                    Location = new Point(10, 190)
                };

                Label lblHorario = new Label
                {
                    Text = $"Horario: {curso.Horario} - Duración: {curso.Duracion}",
                    Width = 230,
                    Height = 20,
                    Location = new Point(10, 210)
                };

                Label lblInstructor = new Label
                {
                    Text = $"Instructor: {curso.Instructor}",
                    Width = 230,
                    Height = 20,
                    Location = new Point(10, 230)
                };

                Label lblDescripcion = new Label
                {
                    Text = curso.Descripcion,
                    Width = 230,
                    Height = 60,
                    Location = new Point(10, 250),
                    AutoEllipsis = true
                };

                Label lblInscritos = new Label
                {
                    Text = $"Inscritos: {curso.NumeroInscritos}",
                    Width = 80,
                    Height = 20,
                    Location = new Point(10, 320)
                };

                Button btnVerDetalles = new Button
                {
                    Text = "Ver detalles",
                    Width = 140,
                    Height = 30,
                    Location = new Point(100, 314),
                    Tag = curso.Id
                };
                btnVerDetalles.Click += BtnVerDetalles_Click;

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(lblTitulo);
                panel.Controls.Add(lblFechas);
                panel.Controls.Add(lblHorario);
                panel.Controls.Add(lblInstructor);
                panel.Controls.Add(lblDescripcion);
                panel.Controls.Add(lblInscritos);
                panel.Controls.Add(btnVerDetalles);

                flpCursos.Controls.Add(panel);
            }
        }

        private void BtnVerDetalles_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int cursoId = (int)btn.Tag;

            FrmDetalleCursoUser detalleForm = new FrmDetalleCursoUser(cursoId);
            detalleForm.ShowDialog();
        }

        private void FrmCursosUser_Load(object sender, EventArgs e)
        {
            // Puedes incluir acciones al cargar si son necesarias
        }
    }
}
