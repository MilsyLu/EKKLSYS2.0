using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ENTITY;

namespace DAL
{
    public class InscripcionRepository : FileRepository<Inscripcion>
    {
        public InscripcionRepository(string ruta) : base(ruta)
        {
        }

        public override List<Inscripcion> Consultar()
        {
            try
            {
                List<Inscripcion> lista = new List<Inscripcion>();

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

        public override Inscripcion Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            Inscripcion inscripcion = new Inscripcion();
            inscripcion.Id = int.Parse(campos[0]);
            inscripcion.UsuarioId = int.Parse(campos[1]);
            inscripcion.CursoId = int.Parse(campos[2]);
            inscripcion.FechaInscripcion = DateTime.Parse(campos[3]);
            return inscripcion;
        }

        public List<Inscripcion> ConsultarPorCurso(int cursoId)
        {
            return Consultar().Where(i => i.CursoId == cursoId).ToList();
        }

        public List<Inscripcion> ConsultarPorUsuario(int usuarioId)
        {
            return Consultar().Where(i => i.UsuarioId == usuarioId).ToList();
        }

        public bool ExisteInscripcion(int usuarioId, int cursoId)
        {
            return Consultar().Any(i => i.UsuarioId == usuarioId && i.CursoId == cursoId);
        }

        public string EliminarInscripcion(int usuarioId, int cursoId)
        {
            try
            {
                List<Inscripcion> lista = Consultar();
                File.Delete(ruta);
                foreach (var item in lista)
                {
                    if (!(item.UsuarioId == usuarioId && item.CursoId == cursoId))
                    {
                        Guardar(item);
                    }
                }
                return "Inscripción eliminada correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar inscripción: {ex.Message}";
            }
        }
    }
}