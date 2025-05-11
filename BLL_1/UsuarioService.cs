using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using ENTITY;

namespace BLL
{
    public class UsuarioService : IService<Usuario>
    {
        private readonly UsuarioRepository repoUsuario;

        public UsuarioService()
        {
            repoUsuario = new UsuarioRepository(Archivos.ARC_USUARIO);
        }

        public List<Usuario> Consultar()
        {
            return repoUsuario.Consultar();
        }

        public List<UsuarioDto> ConsultarDTO()
        {
            return repoUsuario.ConsultarDTO();
        }

        public string Guardar(Usuario entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el usuario no puede ser nulo");
                }

                // Verificar si el email ya existe
                var existingUser = repoUsuario.ConsultarPorEmail(entity.Email);
                if (existingUser != null)
                {
                    throw new InvalidOperationException("El correo electrónico ya está registrado");
                }

                // Hashear la contraseña
                entity.PasswordHash = repoUsuario.HashPassword(entity.PasswordHash);

                // Asignar ID automático
                var usuarios = Consultar();
                entity.Id = usuarios.Count > 0 ? usuarios.Max(u => u.Id) + 1 : 1;

                return repoUsuario.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar usuario: {ex.Message}";
            }
        }

        public string Modificar(Usuario entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el usuario no puede ser nulo");
                }

                return repoUsuario.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar usuario: {ex.Message}";
            }
        }

        public string HashPassword(string password)
        {
            return repoUsuario.HashPassword(password);
        }


        public string Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Error... el id debe ser mayor a cero");
                }

                return repoUsuario.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar usuario: {ex.Message}";
            }
        }

        public Usuario BuscarId(int id)
        {
            var usuarioBuscado = Consultar().FirstOrDefault(x => x.Id == id);
            return usuarioBuscado;
        }

        public Usuario Login(string email, string password)
        {
            var usuario = repoUsuario.ConsultarPorEmail(email);
            if (usuario == null)
                return null;

            string passwordHash = repoUsuario.HashPassword(password);
            if (usuario.PasswordHash != passwordHash)
                return null;

            return usuario;
        }
    }
}