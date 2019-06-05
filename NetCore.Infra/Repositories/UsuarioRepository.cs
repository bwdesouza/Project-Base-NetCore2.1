using NetCore.Domain.Models;
using NetCore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using System.Data;
using System.Security.Claims;

namespace NetCore.Infra.Repositories
{
    public partial class UsuarioRepository : IUsuarioRepository
    {
        public async Task<Usuario> BuscarUsuario(string email)
        {
            Usuario usuario = null;

            using (var conn = new ConnectionFactory().GetOpenBDConnection())
            {
                try
                {
                    var users = conn.Query(BUSCAR_USUARIO, new { @Email = email }).FirstOrDefault();

                    if (users != null)
                    {
                        usuario = new Usuario();

                        usuario.Id = users.Id;
                        usuario.UserName = users.UserName;
                        usuario.PasswordHash = users.PasswordHash;
                        usuario.PasswordSalt = users.PasswordSalt;
                        usuario.Email = users.Email;
                        usuario.EmailConfirmed = users.EmailConfirmed;
                        usuario.IsEnabled = users.IsEnabled;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return usuario;
        }

        public async Task<List<Usuario>> ListarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (var conn = new ConnectionFactory().GetOpenBDConnection())
            {
                try
                {
                    var lstUsuarios = conn.Query(LISTAR_USUARIOS).ToList();

                    foreach (var users in lstUsuarios)
                    {
                        var usuario = new Usuario();

                        usuario.Id = users.Id;
                        usuario.UserName = users.UserName;
                        usuario.PasswordHash = users.PasswordHash;
                        usuario.PasswordSalt = users.PasswordSalt;
                        usuario.Email = users.Email;
                        usuario.EmailConfirmed = users.EmailConfirmed;
                        usuario.IsEnabled = users.IsEnabled;

                        usuarios.Add(usuario);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

            return usuarios;
        }

        public async Task<Usuario> RegisterUser(Usuario usuario)
        {
            Usuario user = new Usuario();

            using (var conn = new ConnectionFactory().GetOpenBDConnection())
            {
                IDbTransaction trans = conn.BeginTransaction();
                try
                {
                    conn.Execute(SALVAR_USUARIO, new { usuario.Id, usuario.UserName, usuario.PasswordHash, usuario.PasswordSalt, usuario.Email, usuario.EmailConfirmed, @IsEnabled = true }, trans);

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception(ex.Message);
                }
            }

            return user;
        }
    }
}
