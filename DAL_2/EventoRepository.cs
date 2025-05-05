using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ENTITY;

namespace DAL
{
    public class EventoRepository : FileRepository<Evento>
    {
        private AsistenciaRepository asistenciaRepository;

        public EventoRepository(string ruta) : base(ruta)
        {
            asistenciaRepository = new AsistenciaRepository(Archivos.ARC_ASISTENCIA);
        }

        public override List<Evento> Consultar()
        {
            try
            {
                List<Evento> lista = new List<Evento>();

                if (File.Exists(ruta))
                {
                    StreamReader sr = new StreamReader(ruta);
                    while (!sr.EndOfStream)
                    {
                        lista.Add(Mappear(sr.ReadLine()));
                    }
                    sr.Close();
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<EventoDto> ConsultarDTO()
        {
            try
            {
                List<EventoDto> lista = new List<EventoDto>();

                if (File.Exists(ruta))
                {
                    StreamReader sr = new StreamReader(ruta);
                    while (!sr.EndOfStream)
                    {
                        lista.Add(MappearDTO(sr.ReadLine()));
                    }
                    sr.Close();
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private EventoDto MappearDTO(string datos)
        {
            string[] campos = datos.Split(';');
            EventoDto evento = new EventoDto();
            evento.Id = int.Parse(campos[0]);
            evento.Titulo = campos[1];
            evento.Fecha = DateTime.Parse(campos[2]);
            evento.Hora = campos[3];
            evento.Descripcion = campos[4];
            evento.ImagenPortada = campos[5];

            // Contar asistentes
            int eventoId = evento.Id;
            evento.NumeroAsistentes = asistenciaRepository.Consultar().Count(a => a.EventoId == eventoId);

            return evento;
        }

        public override Evento Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            Evento evento = new Evento();
            evento.Id = int.Parse(campos[0]);
            evento.Titulo = campos[1];
            evento.Fecha = DateTime.Parse(campos[2]);
            evento.Hora = campos[3];
            evento.Descripcion = campos[4];
            evento.ImagenPortada = campos[5];
            evento.FechaCreacion = DateTime.Parse(campos[6]);
            return evento;
        }

        public List<Evento> ConsultarProximosEventos()
        {
            return Consultar().Where(e => e.Fecha >= DateTime.Today).OrderBy(e => e.Fecha).ToList();
        }

        public List<EventoDto> ConsultarProximosEventosDTO()
        {
            return ConsultarDTO().Where(e => e.Fecha >= DateTime.Today).OrderBy(e => e.Fecha).ToList();
        }
    }
}