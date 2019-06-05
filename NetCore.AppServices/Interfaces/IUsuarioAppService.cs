using NetCore.AppServices.Commands.Usuario;
using NetCore.AppServices.ViewModel;
using NetCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.AppServices.Interfaces
{
    public interface IUsuarioAppService
    {
        Task<bool> RegisterUser(UsuarioPessoaCommand command);
        Task<List<UsuarioViewModel>> ListarUsuarios();
        Task<UsuarioViewModel> LoginUsuario(string email, string senha);
    }
}
