using AutoMapper;
using PotentialCrud2.Domain.Entities;
using PotentialCrud2.Domain.Models;

namespace PotentialCrud2.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<DesenvolvedorEntity, DesenvolvedorModel>()
                .ReverseMap();
        }
    }
}
