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
                Senha = "@BR.souz@2"
            };

            var result = await _controller.Login(credencial);

            Assert.IsNotNull(result);
            Assert.IsTrue(true);
        }

    }
}
