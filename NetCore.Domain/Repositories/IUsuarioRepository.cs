using NetCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> RegisterUser(Usuario usuario);
        Task<bool> EditarUsuario(Usuario usuario);
        Task<Usuario> BuscarUsuario(string email);
        Task<List<Usuario>> ListarUsuarios();
        Task<bool> DeletarUsuario(Guid id);
    }
}
