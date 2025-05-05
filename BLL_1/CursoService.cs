using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using ENTITY;

namespace BLL
{
    public class CursoService : IService<Curso>
    {
        private readonly CursoRepository repoCurso;
        private readonly InscripcionRepository repoInscripcion;
        private readonly UsuarioRepository repoUsuario;

        public CursoService()
        {
            repoCurso = new CursoRepository(Archivos.ARC_CURSO);
            repoInscripcion = new InscripcionRepository(Archivos.ARC_INSCRIPCION);
            repoUsuario = new UsuarioRepository(Archivos.ARC_USUARIO);
        }

        public List<Curso> Consultar()
        {
            return repoCurso.Consultar();
        }

        public List<CursoDto> ConsultarDTO()
        {
            return repoCurso.ConsultarDTO();
        }

        public string Guardar(Curso entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el curso no puede ser nulo");
                }

                // Asignar ID automático
                var cursos = Consultar();
                entity.Id = cursos.Count > 0 ? cursos.Max(c => c.Id) + 1 : 1;

                return repoCurso.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar curso: {ex.Message}";
            }
        }

        public string Modificar(Curso entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el curso no puede ser nulo");
                }

                return repoCurso.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar curso: {ex.Message}";
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Error... el id debe ser mayor a cero");
                }

                // Eliminar inscripciones asociadas
                var inscripciones = repoInscripcion.ConsultarPorCurso(id);
                foreach (var inscripcion in inscripciones)
                {
                    repoInscripcion.Eliminar(inscripcion.Id);
                }

                return repoCurso.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar curso: {ex.Message}";
            }
        }

        public Curso BuscarId(int id)
        {
            var cursoBuscado = Consultar().FirstOrDefault(x => x.Id == id);
            return cursoBuscado;
        }

        public List<Curso> ConsultarCursosDisponibles()
        {
            return repoCurso.ConsultarCursosDisponibles();
        }

        public List<CursoDto> ConsultarCursosDisponiblesDTO()
        {
            return repoCurso.ConsultarCursosDisponiblesDTO();
        }

        public string Inscribirse(int usuarioId, int cursoId)
        {
            try
            {
                // Verificar si ya existe la inscripción
                bool existeInscripcion = repoInscripcion.ExisteInscripcion(usuarioId, cursoId);
                if (existeInscripcion)
                    throw new InvalidOperationException("El usuario ya está inscrito en este curso");

                // Verificar si existe el usuario
                var usuario = repoUsuario.Consultar().FirstOrDefault(u => u.Id == usuarioId);
                if (usuario == null)
                    throw new InvalidOperationException("El usuario no existe");

                // Verificar si existe el curso
                var curso = repoCurso.Consultar().FirstOrDefault(c => c.Id == cursoId);
                if (curso == null)
                    throw new InvalidOperationException("El curso no existe");

                var inscripcion = new Inscripcion
                {
                    UsuarioId = usuarioId,
                    CursoId = cursoId,
                    FechaInscripcion = DateTime.Now
                };

                // Asignar ID automático
                var inscripciones = repoInscripcion.Consultar();
                inscripcion.Id = inscripciones.Count > 0 ? inscripciones.Max(i => i.Id) + 1 : 1;

                return repoInscripcion.Guardar(inscripcion);
            }
            catch (Exception ex)
            {
                return $"Error al inscribirse: {ex.Message}";
            }
        }

        public string CancelarInscripcion(int usuarioId, int cursoId)
        {
            try
            {
                return repoInscripcion.EliminarInscripcion(usuarioId, cursoId);
            }
            catch (Exception ex)
            {
                return $"Error al cancelar inscripción: {ex.Message}";
            }
        }

        public List<UsuarioDto> ConsultarEstudiantes(int cursoId)
        {
            var inscripciones = repoInscripcion.ConsultarPorCurso(cursoId);
            var usuarios = repoUsuario.ConsultarDTO();

            return usuarios.Where(u => inscripciones.Any(i => i.UsuarioId == u.Id)).ToList();
        }
    }
}