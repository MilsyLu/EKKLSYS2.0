using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class FrmDetalleCursoAdmin : Form
    {
        private readonly CursoService cursoService;
        private readonly int cursoId;
        private Curso curso;
        private CursoDto cursoDto;

        public FrmDetalleCursoAdmin(int cursoId)
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

            // Obtener el DTO para tener el número de inscritos
            var cursosDto = cursoService.ConsultarDTO();
            cursoDto = cursosDto.Find(c => c.Id == cursoId);

            // Cargar datos en los controles
            lblTitulo.Text = curso.Titulo;
            lblFechas.Text = $"Del {curso.FechaInicio:dd/MM/yyyy} al {curso.FechaFin:dd/MM/yyyy}";
            lblHorario.Text = $"Horario: {curso.Horario}";
            lblDuracion.Text = $"Duración: {curso.Duracion}";
            lblInstructor.Text = $"Instructor: {curso.Instructor}";
            txtDescripcion.Text = curso.Descripcion;
            lblUbicacion.Text = $"Ubicación: {curso.Ubicacion}";
            txtRequisitos.Text = curso.Requisitos;
            lblInscritos.Text = $"Inscritos: {cursoDto?.NumeroInscritos ?? 0}";

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

            // Verificar si el usuario actual ya está inscrito
            bool yaInscrito = false;
            if (Session.CurrentUser != null)
            {
                var estudiantes = cursoService.ConsultarEstudiantes(cursoId);
                yaInscrito = estudiantes.Exists(u => u.Id == Session.CurrentUser.Id);
            }

            // Configurar botón de inscripción
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
            CargarCurso(); // Recargar para actualizar el estado
        }

        private void btnVerEstudiantes_Click(object sender, EventArgs e)
        {
            var estudiantes = cursoService.ConsultarEstudiantes(cursoId);
            if (estudiantes.Count == 0)
            {
                MessageBox.Show("No hay estudiantes inscritos en este curso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Mostrar lista de estudiantes
            string listaEstudiantes = "Lista de Estudiantes:\n\n";
            foreach (var estudiante in estudiantes)
            {
                listaEstudiantes += $"- {estudiante.Nombre} {estudiante.Apellido}\n";
            }

            MessageBox.Show(listaEstudiantes, "Estudiantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // CursoDetalleForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Name = "CursoDetalleForm";
        //    this.Load += new System.EventHandler(this.CursoDetalleForm_Load);
        //    this.ResumeLayout(false);

        //}

        private void CursoDetalleForm_Load(object sender, EventArgs e)
        {

        }

        private void FrmDetalleCursoAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}