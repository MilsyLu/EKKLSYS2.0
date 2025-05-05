using System;

namespace ENTITY
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Descripcion { get; set; }
        public string ImagenPortada { get; set; }
        public int NumeroAsistentes { get; set; }
    }
}