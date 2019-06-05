using AutoMapper;
using NetCore.Domain.Models;
using NetCore.AppServices.Commands.Usuario;

namespace NetCore.AppServices.AutoMapper
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
		{
            //Exemplos
            //CreateMap<SampleCommand, Email>().ConstructUsing(c => new SampleCommand(c.Remetente, c.Assunto));
            //CreateMap<GraficoCommand, Grafico>()
            //    .ForMember(dest => dest.Id,
            //                opt => opt.MapFrom(src => src.IdObj));
            //.ForMember(dest => dest.Id,
            //                opt => opt.MapFrom(src => src.IdObj));

            CreateMap<UsuarioPessoaCommand, Usuario>();
        }
    }
}
