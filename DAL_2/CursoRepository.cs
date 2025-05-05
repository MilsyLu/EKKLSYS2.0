using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ENTITY;

namespace DAL
{
    public class CursoRepository : FileRepository<Curso>
    {
        private InscripcionRepository inscripcionRepository;

        public CursoRepository(string ruta) : base(ruta)
        {
            inscripcionRepository = new InscripcionRepository(Archivos.ARC_INSCRIPCION);
        }

        public override List<Curso> Consultar()
        {
            try
            {
                List<Curso> lista = new List<Curso>();

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

        public List<CursoDto> ConsultarDTO()
        {
            try
            {
                List<CursoDto> lista = new List<CursoDto>();

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

        private CursoDto MappearDTO(string datos)
        {
            string[] campos = datos.Split(';');
            CursoDto curso = new CursoDto();
            curso.Id = int.Parse(campos[0]);
            curso.Titulo = campos[1];
            curso.FechaInicio = DateTime.Parse(campos[2]);
            curso.FechaFin = DateTime.Parse(campos[3]);
            curso.Horario = campos[4];
            curso.Duracion = campos[5];
            curso.Instructor = campos[6];
            curso.Descripcion = campos[7];
            curso.Ubicacion = campos[8];
            curso.Requisitos = campos[9];
            curso.ImagenPortada = campos[10];

            // Contar inscritos
            int cursoId = curso.Id;
            curso.NumeroInscritos = inscripcionRepository.Consultar().Count(i => i.CursoId == cursoId);

            return curso;
        }

        public override Curso Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            Curso curso = new Curso();
            curso.Id = int.Parse(campos[0]);
            curso.Titulo = campos[1];
            curso.FechaInicio = DateTime.Parse(campos[2]);
            curso.FechaFin = DateTime.Parse(campos[3]);
            curso.Horario = campos[4];
            curso.Duracion = campos[5];
            curso.Instructor = campos[6];
            curso.Descripcion = campos[7];
            curso.Ubicacion = campos[8];
            curso.Requisitos = campos[9];
            curso.ImagenPortada = campos[10];
            return curso;
        }

        public List<Curso> ConsultarCursosDisponibles()
        {
            return Consultar().Where(c => c.FechaFin >= DateTime.Today).OrderBy(c => c.FechaInicio).ToList();
        }

        public List<CursoDto> ConsultarCursosDisponiblesDTO()
        {
            return ConsultarDTO().Where(c => c.FechaFin >= DateTime.Today).OrderBy(c => c.FechaInicio).ToList();
        }
    }
}