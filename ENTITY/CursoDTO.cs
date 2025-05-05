using System;

namespace ENTITY
{
    public class CursoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Horario { get; set; }
        public string Duracion { get; set; }
        public string Instructor { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string Requisitos { get; set; }
        public string ImagenPortada { get; set; }
        public int NumeroInscritos { get; set; }
    }
}