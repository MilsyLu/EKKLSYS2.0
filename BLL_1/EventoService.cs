using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using ENTITY;

namespace BLL
{
    public class EventoService : IService<Evento>
    {
        private readonly EventoRepository repoEvento;
        private readonly AsistenciaRepository repoAsistencia;
        private readonly UsuarioRepository repoUsuario;

        public EventoService()
        {
            repoEvento = new EventoRepository(Archivos.ARC_EVENTO);
            repoAsistencia = new AsistenciaRepository(Archivos.ARC_ASISTENCIA);
            repoUsuario = new UsuarioRepository(Archivos.ARC_USUARIO);
        }

        public List<Evento> Consultar()
        {
            return repoEvento.Consultar();
        }

        public List<EventoDto> ConsultarDTO()
        {
            return repoEvento.ConsultarDTO();
        }

        public string Guardar(Evento entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el evento no puede ser nulo");
                }

                // Asignar ID automático
                var eventos = Consultar();
                entity.Id = eventos.Count > 0 ? eventos.Max(e => e.Id) + 1 : 1;

                return repoEvento.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar evento: {ex.Message}";
            }
        }

        public string Modificar(Evento entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el evento no puede ser nulo");
                }

                return repoEvento.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar evento: {ex.Message}";
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

                // Eliminar asistencias asociadas
                var asistencias = repoAsistencia.ConsultarPorEvento(id);
                foreach (var asistencia in asistencias)
                {
                    repoAsistencia.Eliminar(asistencia.Id);
                }

                return repoEvento.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar evento: {ex.Message}";
            }
        }

        public Evento BuscarId(int id)
        {
            var eventoBuscado = Consultar().FirstOrDefault(x => x.Id == id);
            return eventoBuscado;
        }

        public List<Evento> ConsultarProximosEventos()
        {
            return repoEvento.ConsultarProximosEventos();
        }

        public List<EventoDto> ConsultarProximosEventosDTO()
        {
            return repoEvento.ConsultarProximosEventosDTO();
        }

        public string RegistrarAsistencia(int usuarioId, int eventoId)
        {
            try
            {
                // Verificar si ya existe la asistencia
                bool existeAsistencia = repoAsistencia.ExisteAsistencia(usuarioId, eventoId);
                if (existeAsistencia)
                    throw new InvalidOperationException("El usuario ya está registrado para este evento");

                // Verificar si existe el usuario
                var usuario = repoUsuario.Consultar().FirstOrDefault(u => u.Id == usuarioId);
                if (usuario == null)
                    throw new InvalidOperationException("El usuario no existe");

                // Verificar si existe el evento
                var evento = repoEvento.Consultar().FirstOrDefault(e => e.Id == eventoId);
                if (evento == null)
                    throw new InvalidOperationException("El evento no existe");

                var asistencia = new Asistencia
                {
                    UsuarioId = usuarioId,
                    EventoId = eventoId,
                    FechaRegistro = DateTime.Now
                };

                // Asignar ID automático
                var asistencias = repoAsistencia.Consultar();
                asistencia.Id = asistencias.Count > 0 ? asistencias.Max(a => a.Id) + 1 : 1;

                return repoAsistencia.Guardar(asistencia);
            }
            catch (Exception ex)
            {
                return $"Error al registrar asistencia: {ex.Message}";
            }
        }

        public string CancelarAsistencia(int usuarioId, int eventoId)
        {
            try
            {
                return repoAsistencia.EliminarAsistencia(usuarioId, eventoId);
            }
            catch (Exception ex)
            {
                return $"Error al cancelar asistencia: {ex.Message}";
            }
        }

        public List<UsuarioDto> ConsultarAsistentes(int eventoId)
        {
            var asistencias = repoAsistencia.ConsultarPorEvento(eventoId);
            var usuarios = repoUsuario.ConsultarDTO();

            return usuarios.Where(u => asistencias.Any(a => a.UsuarioId == u.Id)).ToList();
        }
    }
}