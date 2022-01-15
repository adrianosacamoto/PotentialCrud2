using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PotentialCrud2.Domain.Dtos.Desenvolvedor;

namespace PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor
{
    public interface IDesenvolvedorService
    {
        Task<DesenvolvedorDto> Get(Guid id);
        Task<IEnumerable<DesenvolvedorDto>> GetAll();
        Task<IEnumerable<DesenvolvedorDto>> GetAllByParamName(string nome, int skip, int take);
        Task<DesenvolvedorDtoCreateResult> Post(DesenvolvedorDtoCreate desenvolvedor);
        Task<DesenvolvedorDtoUpdateResult> Put(DesenvolvedorDtoUpdate desenvolvedor);
        Task<bool> Delete(Guid id);
    }
}
