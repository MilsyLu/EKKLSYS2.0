using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI.Form_Users
{
    public partial class FrmDetalleCursoUser : Form
    {
        private readonly CursoService cursoService;
        private readonly int cursoId;
        private Curso curso;
        private CursoDto cursoDto;

        public FrmDetalleCursoUser(int cursoId)
        {
            InitializeComponent();
            this.cursoId = cursoId;
            cursoService = new CursoService();
            CargarCurso();
        }

        private void CargarCurso()
        {
            curso = cursoService.BuscarId(cursoId);
            if (curso == null)
            {
                MessageBox.Show("El curso no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            var cursosDto = cursoService.ConsultarDTO();
            cursoDto = cursosDto.Find(c => c.Id == cursoId);

            lblTitulo.Text = curso.Titulo;
            lblFechas.Text = $"Del {curso.FechaInicio:dd/MM/yyyy} al {curso.FechaFin:dd/MM/yyyy}";
            lblHorario.Text = $"Horario: {curso.Horario}";
            lblDuracion.Text = $"Duración: {curso.Duracion}";
            lblInstructor.Text = $"Instructor: {curso.Instructor}";
            txtDescripcion.Text = curso.Descripcion;
            lblUbicacion.Text = $"Ubicación: {curso.Ubicacion}";
            txtRequisitos.Text = curso.Requisitos;
            lblInscritos.Text = $"Inscritos: {cursoDto?.NumeroInscritos ?? 0}";

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

            bool yaInscrito = false;
            if (Session.CurrentUser != null)
            {
                var estudiantes = cursoService.ConsultarEstudiantes(cursoId);
                yaInscrito = estudiantes.Exists(u => u.Id == Session.CurrentUser.Id);
            }

            btnInscribirse.Text = yaInscrito ? "Cancelar Inscripción" : "Inscribirse";
            btnInscribirse.Tag = yaInscrito;
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("Debe iniciar sesión para inscribirse", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool yaInscrito = (bool)btnInscribirse.Tag;
            string mensaje;

            if (yaInscrito)
            {
                mensaje = cursoService.CancelarInscripcion(Session.CurrentUser.Id, cursoId);
            }
            else
            {
                mensaje = cursoService.Inscribirse(Session.CurrentUser.Id, cursoId);
            }

            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarCurso();
        }

        private void FrmDetalleCursoUser_Load(object sender, EventArgs e)
        {
            // Si necesitas lógica adicional al cargar, la agregas aquí.
        }
    }
}
