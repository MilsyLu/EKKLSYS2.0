using System;

namespace ENTITY
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string FotoPerfil { get; set; }
        public string EsCreyente { get; set; }
        public string PasswordHash { get; set; }

        public Usuario()
        {
            FechaRegistro = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Apellido};{FechaNacimiento:yyyy-MM-dd};{Direccion};{Telefono};{Email};{FechaRegistro:yyyy-MM-dd};{FotoPerfil};{EsCreyente};{PasswordHash}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Usuario other = (Usuario)obj;
            Console.WriteLine($"Comparando Usuario: {Id} con Usuario: {other.Id}");
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}