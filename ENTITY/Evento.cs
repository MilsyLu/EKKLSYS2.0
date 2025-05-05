using System;
using System.Collections.Generic;

namespace ENTITY
{
    public class Evento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Descripcion { get; set; }
        public string ImagenPortada { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Evento()
        {
            FechaCreacion = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Id};{Titulo};{Fecha:yyyy-MM-dd};{Hora};{Descripcion};{ImagenPortada};{FechaCreacion:yyyy-MM-dd}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Evento other = (Evento)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}