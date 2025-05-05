using System;

namespace ENTITY
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CursoId { get; set; }
        public DateTime FechaInscripcion { get; set; }

        public Inscripcion()
        {
            FechaInscripcion = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Id};{UsuarioId};{CursoId};{FechaInscripcion:yyyy-MM-dd}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Inscripcion other = (Inscripcion)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}