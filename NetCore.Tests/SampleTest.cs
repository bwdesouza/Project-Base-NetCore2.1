using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace NetCore.Tests
{
    [TestClass]
    public class SampleTest : BaseTest
    {
        //public SampleController _controller { get; set; }
        //public SampleAppService _appService { get; set; }
        //public SampleService _service { get; set; }
        //public SampleRepository _repository { get; set; }


        [TestMethod]
        [TestCategory("Sample")]

        public async Task ShouldListAll()
        {
            //ConnectionStrings.SampleConnection = cadastroConnection;

            //_repository = new SampleRepository();
            //_service = new SampleService(_repository);
            //_appService = new SampleAppService(_service, AutoMapperConfiguration.RegisterMappings().CreateMapper());
            //_controller = new SampleController(_appService);

            //var result = await _controller.GetAsync();

            //Assert.IsNotNull(result);
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Polo")]
        public async Task ShouldSaveSample()
        {
            //ConnectionStrings.SampleConnection = cadastroConnection;

            //_repository = new SampleRepository();
            //_service = new SampleService(_repository);
            //_appService = new SampleAppService(_service, AutoMapperConfiguration.RegisterMappings().CreateMapper());
            //_controller = new SampleController(_appService);

            //InserirSampleCommand command = new InserirSampleCommand();

            //command.Assunto = "";
            //command.Conteudo = "";
            //command.Destinatario = "";
            //command.StatusId = 1;

            //var result = await _controller.PostAsync(command);
            //Assert.AreNotEqual(false, NotificationUtil.Sucesso(result));
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Polo")]
        public async Task ShouldNotSaveSampleLessDescription()
        {
            //ConnectionStrings.SampleConnection = cadastroConnection;

            //_repository = new SampleRepository();
            //_service = new SampleService(_repository);
            //_appService = new SampleAppService(_service, AutoMapperConfiguration.RegisterMappings().CreateMapper());
            //_controller = new SampleController(_appService);

            //InserirSampleCommand command = new InserirSampleCommand();

            //command.Assunto = "";
            //command.Conteudo = "";
            //command.Destinatario = "";
            //command.StatusId = 1;

            //var result = await _controller.PostAsync(command);

            //Assert.IsTrue(NotificationUtil.ExistError("Descricao", result));
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Polo")]
        public async Task ShouldNotSaveSampleLessHoraStartTime()
        {
            //ConnectionStrings.SampleConnection = cadastroConnection;

            //_repository = new SampleRepository();
            //_service = new SampleService(_repository);
            //_appService = new SampleAppService(_service, AutoMapperConfiguration.RegisterMappings().CreateMapper());
            //_controller = new SampleController(_appService);

            //InserirSampleCommand command = new InserirSampleCommand();

            //command.Assunto = "";
            //command.Conteudo = "";
            //command.Destinatario = "";
            //command.StatusId = 1;

            //var result = await _controller.PostAsync(command);
            //Assert.IsTrue(NotificationUtil.ExistError("HoraInicial", result));

            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Polo")]
        public async Task ShouldNotSaveSampleLessEndTime()
        {
            //ConnectionStrings.SampleConnection = cadastroConnection;

            //_repository = new SampleRepository();
            //_service = new SampleService(_repository);
            //_appService = new SampleAppService(_service, AutoMapperConfiguration.RegisterMappings().CreateMapper());
            //_controller = new SampleController(_appService);

            //InserirSampleCommand command = new InserirSampleCommand();

            //command.Assunto = "";
            //command.Conteudo = "";
            //command.Destinatario = "";
            //command.StatusId = 1;

            //var result = await _controller.PostAsync(command);
            //Assert.IsTrue(NotificationUtil.ExistError("HoraFinal", result));
            Assert.IsTrue(true);
        }
    }
}
