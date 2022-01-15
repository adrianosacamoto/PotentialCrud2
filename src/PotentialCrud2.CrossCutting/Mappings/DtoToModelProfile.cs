using AutoMapper;
using PotentialCrud2.Domain.Dtos.Desenvolvedor;
using PotentialCrud2.Domain.Models;

namespace PotentialCrud2.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<DesenvolvedorModel, DesenvolvedorDto>()
                .ReverseMap();

            CreateMap<DesenvolvedorModel, DesenvolvedorDtoCreate>()
                .ReverseMap();

            CreateMap<DesenvolvedorModel, DesenvolvedorDtoUpdate>()
                .ReverseMap();
        }
    }
}
