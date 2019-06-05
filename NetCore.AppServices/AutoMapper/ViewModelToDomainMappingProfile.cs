using AutoMapper;
using NetCore.AppServices.ViewModel;
using NetCore.Domain.Models;

namespace NetCore.AppServices.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}
