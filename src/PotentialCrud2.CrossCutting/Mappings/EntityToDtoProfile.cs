using AutoMapper;
using PotentialCrud2.Domain.Dtos.Desenvolvedor;
using PotentialCrud2.Domain.Entities;

namespace PotentialCrud2.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<DesenvolvedorDto, DesenvolvedorEntity>()
                .ReverseMap();

            CreateMap<DesenvolvedorDtoCreateResult, DesenvolvedorEntity>()
                .ReverseMap();

            CreateMap<DesenvolvedorDtoUpdateResult, DesenvolvedorEntity>()
                .ReverseMap();
        }
    }
}
