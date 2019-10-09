using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCore.Api.Controllers;
using NetCore.AppServices.AutoMapper;
using NetCore.AppServices.Commands.Usuario;
using NetCore.AppServices.Services;
using NetCore.CrossCutting;
using NetCore.Domain.Services;
using NetCore.Infra.Repositories;
using System.Threading.Tasks;

namespace NetCore.Tests
{
    [TestClass]
    public class NetCoreTest : BaseTest
    {
        public UsuarioController _controller { get; set; }
        public UsuarioAppService _appService { get; set; }
        public UsuarioService _service { get; set; }
        public JwtService _jswtService { get; set; }
        public UsuarioRepository _repository { get; set; }

        
        [TestMethod]
        public async Task CriarNovoUsuario()
        {
            ConnectionStrings.BancoDadosConnection = bancoDadosConnection;

            _repository = new UsuarioRepository();
            _service = new UsuarioService(_repository);
            _appService = new UsuarioAppService(AutoMapperConfiguration.RegisterMappings().CreateMapper(), _service, _jswtService);
            _controller = new UsuarioController(_appService);

            var pessoa = new UsuarioPessoaCommand()
            {
                Nome = "Bruno Willian de Souza",
                Email = "bwdesouza@gmail.com",
                Senha = "bwdesouza",
                ConfirmacaoSenha = "bwdesouza"
            };

            var result = await _controller.RegistrarUsuario(pessoa);

            Assert.IsNotNull(result);
            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public async Task TestLogin()
        {
            ConnectionStrings.BancoDadosConnection = bancoDadosConnection;

            _repository = new UsuarioRepository();
            _service = new UsuarioService(_repository);
            _appService = new UsuarioAppService(AutoMapperConfiguration.RegisterMappings().CreateMapper(), _service, _jswtService);
            _controller = new UsuarioController(_appService);

            var credencial = new CredencialCommand()
            {
                Email = "bwdesouza@gmail.com",
                Senha = "bwdesouza"
            };

            var result = await _controller.Login(credencial);

            Assert.IsNotNull(result);
            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public async Task EditarUsuario()
        {
            ConnectionStrings.BancoDadosConnection = bancoDadosConnection;

            _repository = new UsuarioRepository();
            _service = new UsuarioService(_repository);
            _appService = new UsuarioAppService(AutoMapperConfiguration.RegisterMappings().CreateMapper(), _service, _jswtService);
            _controller = new UsuarioController(_appService);

            var editarPessoa = new UsuarioPessoaCommand()
            {
                Nome = "Bruno Souza",
                Email = "bwdesouza@gmail.com",
                Senha = "bwdesouza@2",
                ConfirmacaoSenha = "bwdesouza@2"
            };

            var result = await _controller.EditarUsuario(editarPessoa);

            Assert.IsNotNull(result);
            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public async Task ListarUsuarios()
        {
            ConnectionStrings.BancoDadosConnection = bancoDadosConnection;

            _repository = new UsuarioRepository();
            _service = new UsuarioService(_repository);
            _appService = new UsuarioAppService(AutoMapperConfiguration.RegisterMappings().CreateMapper(), _service, _jswtService);
            _controller = new UsuarioController(_appService);

            var result = await _controller.ListarUsuarios();

            Assert.IsNotNull(result);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task DeletarUsuario()
        {
            ConnectionStrings.BancoDadosConnection = bancoDadosConnection;

            _repository = new UsuarioRepository();
            _service = new UsuarioService(_repository);
            _appService = new UsuarioAppService(AutoMapperConfiguration.RegisterMappings().CreateMapper(), _service, _jswtService);
            _controller = new UsuarioController(_appService);

            var id = "e67cb45c-03ec-44b4-8eaa-779150d09aed";
            
            var result = await _controller.DeletarUsuario(id);

            Assert.IsNotNull(result);
            Assert.IsTrue(true);
        }
    }
}
