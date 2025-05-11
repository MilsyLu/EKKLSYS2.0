using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ENTITY;

namespace DAL
{
    public class UsuarioRepository : FileRepository<Usuario>
    {
        public UsuarioRepository(string ruta) : base(ruta)
        {
        }

        public override List<Usuario> Consultar()
        {
            try
            {
                List<Usuario> lista = new List<Usuario>();

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

        public List<UsuarioDto> ConsultarDTO()
        {
            try
            {
                List<UsuarioDto> lista = new List<UsuarioDto>();

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

        private UsuarioDto MappearDTO(string datos)
        {
            string[] campos = datos.Split(';');
            UsuarioDto usuario = new UsuarioDto();
            usuario.Id = int.Parse(campos[0]);
            usuario.Nombre = campos[1];
            usuario.Apellido = campos[2];
            usuario.FechaNacimiento = DateTime.Parse(campos[3]);
            usuario.Direccion = campos[4];
            usuario.Telefono = campos[5];
            usuario.Email = campos[6];
            usuario.FotoPerfil = campos[8];
            usuario.EsCreyente = campos[9];
            return usuario;
        }

        public override Usuario Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            Usuario usuario = new Usuario();
            if (!int.TryParse(campos[0], out int id))
            {
                throw new FormatException($"El valor '{campos[0]}' no es un número entero válido.");
            }
            if (string.IsNullOrWhiteSpace(datos))
            {
                throw new FormatException("Se encontró una línea vacía o mal formateada en el archivo.");
            }
            usuario.Id = id;
            
            usuario.Id = int.Parse(campos[0]);
            usuario.Nombre = campos[1];
            usuario.Apellido = campos[2];
            usuario.FechaNacimiento = DateTime.Parse(campos[3]);
            usuario.Direccion = campos[4];
            usuario.Telefono = campos[5];
            usuario.Email = campos[6];
            usuario.FechaRegistro = DateTime.Parse(campos[7]);
            usuario.FotoPerfil = campos[8];
            usuario.EsCreyente = campos[9];
            usuario.PasswordHash = campos[10];
            return usuario;
        }

        public Usuario ConsultarPorEmail(string email)
        {
            return Consultar().FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}