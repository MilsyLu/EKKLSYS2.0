using System;

namespace ENTITY
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string FotoPerfil { get; set; }
        public string EsCreyente { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}