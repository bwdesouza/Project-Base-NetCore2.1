using NetCore.Domain.Interfaces;
using NetCore.Domain.Models;
using NetCore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _repository { get; set; }

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Usuario> RegisterUser(Usuario usuario)
        {
            return await _repository.RegisterUser(usuario);
        }

        public async Task<Usuario> BuscarUsuario(string email)
        {
            return await _repository.BuscarUsuario(email);
        }

        public async Task<List<Usuario>> ListarUsuarios()
        {
            return await _repository.ListarUsuarios();
        }
    }
}
