using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ENTITY;

namespace DAL
{
    public class AsistenciaRepository : FileRepository<Asistencia>
    {
        public AsistenciaRepository(string ruta) : base(ruta)
        {
        }

        public override List<Asistencia> Consultar()
        {
            try
            {
                List<Asistencia> lista = new List<Asistencia>();

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

        public override Asistencia Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            Asistencia asistencia = new Asistencia();
            asistencia.Id = int.Parse(campos[0]);
            asistencia.UsuarioId = int.Parse(campos[1]);
            asistencia.EventoId = int.Parse(campos[2]);
            asistencia.FechaRegistro = DateTime.Parse(campos[3]);
            return asistencia;
        }

        public List<Asistencia> ConsultarPorEvento(int eventoId)
        {
            return Consultar().Where(a => a.EventoId == eventoId).ToList();
        }

        public List<Asistencia> ConsultarPorUsuario(int usuarioId)
        {
            return Consultar().Where(a => a.UsuarioId == usuarioId).ToList();
        }

        public bool ExisteAsistencia(int usuarioId, int eventoId)
        {
            return Consultar().Any(a => a.UsuarioId == usuarioId && a.EventoId == eventoId);
        }

        public string EliminarAsistencia(int usuarioId, int eventoId)
        {
            try
            {
                List<Asistencia> lista = Consultar();
                File.Delete(ruta);
                foreach (var item in lista)
                {
                    if (!(item.UsuarioId == usuarioId && item.EventoId == eventoId))
                    {
                        Guardar(item);
                    }
                }
                return "Asistencia eliminada correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar asistencia: {ex.Message}";
            }
        }
    }
}