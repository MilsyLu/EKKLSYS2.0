using System;

namespace ENTITY
{
    public class Curso
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

        public override string ToString()
        {
            return $"{Id};{Titulo};{FechaInicio:yyyy-MM-dd};{FechaFin:yyyy-MM-dd};{Horario};{Duracion};{Instructor};{Descripcion};{Ubicacion};{Requisitos};{ImagenPortada}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Curso other = (Curso)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}