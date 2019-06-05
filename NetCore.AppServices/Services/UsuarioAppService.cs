using AutoMapper;
using NetCore.AppServices.Commands.Usuario;
using NetCore.AppServices.Interfaces;
using NetCore.AppServices.ViewModel;
using NetCore.Domain.Interfaces;
using NetCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
namespace NetCore.AppServices.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _Mapper;
        private IUsuarioService _usuarioService { get; set; }
        private IJwtService _jwtService { get; set; }

        public UsuarioAppService(IMapper mapper, IUsuarioService usuarioService, IJwtService jwtService)
        {
            _Mapper = mapper;
            _usuarioService = usuarioService;
            _jwtService = jwtService;
        }

        public async Task<bool> RegisterUser(UsuarioPessoaCommand command)
        {
            var usuario = await _usuarioService.BuscarUsuario(command.Email);

            if (usuario != null)
            {
                throw new Exception("Email já existe em nossa base. Por favor, informe outro Email ou contate a equipe tecnica!");
            }

            var register = new Usuario()
            {
                Id = Guid.NewGuid(),
                UserName = command.Nome,
                Email = command.Email,
                EmailConfirmed = false,
                IsEnabled = true,
            };

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(command.Senha, out passwordHash, out passwordSalt);

            register.PasswordHash = Convert.ToBase64String(passwordHash);
            register.PasswordSalt = Convert.ToBase64String(passwordSalt);

            var model = _Mapper.Map<Usuario, UsuarioViewModel>(await _usuarioService.RegisterUser(register));

            return true;
        }

        public async Task<List<UsuarioViewModel>> ListarUsuarios()
        {
            return _Mapper.Map<List<Usuario>, List<UsuarioViewModel>>(await _usuarioService.ListarUsuarios());
        }        

        public async Task<UsuarioViewModel> LoginUsuario(string email, string senha)
        {
            var usuario = await _usuarioService.BuscarUsuario(email);

            if (usuario == null)
            {
                throw new Exception("Email não está cadastrado. Por favor, informe outro Email!");
            }
            else if (!usuario.IsEnabled)
            {
                throw new Exception("Usuário se encontra desativado em nosso sistema. Por favor, contate seu supervisor ou a equipe tecnica!");
            }

            if (!VerifyPasswordHash(senha, Convert.FromBase64String(usuario.PasswordHash), Convert.FromBase64String(usuario.PasswordSalt)))
            {
                throw new Exception("Senha inválida, por favor, informe a senha correta!");
            }

            var token = await _jwtService.CreateJsonWebToken(usuario);

            var model = _Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            model.Token = token;

            return model;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Valor não pode ser nullo ou espaço em branco.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Valor não pode ser nullo ou espaço em branco.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Comprimento inválido do hash da senha (64 bytes esperados).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Comprimento inválido do salt da senha (128 bytes esperados).", "passwordSalt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
