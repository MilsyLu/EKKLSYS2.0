using System;

namespace ENTITY
{
    public class Asistencia
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Asistencia()
        {
            FechaRegistro = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Id};{UsuarioId};{EventoId};{FechaRegistro:yyyy-MM-dd}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Asistencia other = (Asistencia)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}