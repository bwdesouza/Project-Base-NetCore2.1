using AutoMapper;
using NetCore.AppServices.ViewModel;
using NetCore.Domain.Models;

namespace NetCore.AppServices.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Usuario, UsuarioLoginViewModel>();
        }
    }
}
