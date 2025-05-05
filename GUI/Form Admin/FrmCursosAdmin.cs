using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class FrmCursosAdmin : Form
    {
        private readonly CursoService cursoService;
        private List<CursoDto> cursos;

        public FrmCursosAdmin()
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
                // Panel principal para el curso
                Panel panel = new Panel
                {
                    Width = 250,
                    Height = 355,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };

                // Imagen del curso
                PictureBox pictureBox = new PictureBox
                {
                    Width = 250,
                    Height = 150,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Top
                };

                // Cargar imagen si existe
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

                // Título del curso
                Label lblTitulo = new Label
                {
                    Text = curso.Titulo,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Width = 230,
                    Height = 30,
                    Location = new Point(10, 160)
                };

                // Fechas
                Label lblFechas = new Label
                {
                    Text = $"Del {curso.FechaInicio:dd/MM/yyyy} al {curso.FechaFin:dd/MM/yyyy}",
                    Width = 230,
                    Height = 20,
                    Location = new Point(10, 190)
                };

                // Horario y duración
                Label lblHorario = new Label
                {
                    Text = $"Horario: {curso.Horario} - Duración: {curso.Duracion}",
                    Width = 230,
                    Height = 20,
                    Location = new Point(10, 210)
                };

                // Instructor
                Label lblInstructor = new Label
                {
                    Text = $"Instructor: {curso.Instructor}",
                    Width = 230,
                    Height = 20,
                    Location = new Point(10, 230)
                };

                // Descripción
                Label lblDescripcion = new Label
                {
                    Text = curso.Descripcion,
                    Width = 230,
                    Height = 60,
                    Location = new Point(10, 250),
                    AutoEllipsis = true
                };

                // Número de inscritos
                Label lblInscritos = new Label
                {
                    Text = $"Inscritos: {curso.NumeroInscritos}",
                    Width = 80,
                    Height = 20,
                    Location = new Point(10, 320)
                };

                // Botón para ver detalles
                Button btnVerDetalles = new Button
                {
                    Text = "Ver detalles",
                    Width = 140,
                    Height = 30,
                    Location = new Point(100, 314),
                    Tag = curso.Id
                };
                btnVerDetalles.Click += BtnVerDetalles_Click;

                // Agregar controles al panel
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(lblTitulo);
                panel.Controls.Add(lblFechas);
                panel.Controls.Add(lblHorario);
                panel.Controls.Add(lblInstructor);
                panel.Controls.Add(lblDescripcion);
                panel.Controls.Add(lblInscritos);
                panel.Controls.Add(btnVerDetalles);

                // Agregar panel al FlowLayoutPanel
                flpCursos.Controls.Add(panel);
            }
        }

        private void BtnVerDetalles_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int cursoId = (int)btn.Tag;

            FrmDetalleCursoAdmin detalleForm = new FrmDetalleCursoAdmin(cursoId);
            detalleForm.ShowDialog();

            // Recargar cursos al cerrar el formulario de detalles
            CargarCursos();
        }

        private void btnNuevoCurso_Click(object sender, EventArgs e)
        {
            FrmCrearCurso crearForm = new FrmCrearCurso();
            if (crearForm.ShowDialog() == DialogResult.OK)
            {
                CargarCursos();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarCursos();
        }

        private void CursosForm_Load(object sender, EventArgs e)
        {

        }
    }
}