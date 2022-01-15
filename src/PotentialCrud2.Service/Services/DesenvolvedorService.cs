using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PotentialCrud2.Domain.Dtos.Desenvolvedor;
using PotentialCrud2.Domain.Entities;
using PotentialCrud2.Domain.Interfaces;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using PotentialCrud2.Domain.Models;

namespace PotentialCrud2.Service.Services
{
    public class DesenvolvedorService : IDesenvolvedorService
    {
        private IRepository<DesenvolvedorEntity> _repository;
        private readonly IMapper _mapper;

        public DesenvolvedorService(IRepository<DesenvolvedorEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<DesenvolvedorDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<DesenvolvedorDto>(entity) ?? new DesenvolvedorDto();
        }

        public async Task<IEnumerable<DesenvolvedorDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<DesenvolvedorDto>>(listEntity);
        }

        public async Task<IEnumerable<DesenvolvedorDto>> GetAllByParamName(string nome, int skip, int take)
        {
            var listEntity = await _repository.SelectAsync(nome, skip, take);
            return _mapper.Map<IEnumerable<DesenvolvedorDto>>(listEntity);
        }

        public async Task<DesenvolvedorDtoCreateResult> Post(DesenvolvedorDtoCreate desenvolvedor)
        {
            var model = _mapper.Map<DesenvolvedorModel>(desenvolvedor);
            var entity = _mapper.Map<DesenvolvedorEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<DesenvolvedorDtoCreateResult>(result);
        }

        public async Task<DesenvolvedorDtoUpdateResult> Put(DesenvolvedorDtoUpdate desenvolvedor)
        {
            var model = _mapper.Map<DesenvolvedorModel>(desenvolvedor);
            var entity = _mapper.Map<DesenvolvedorEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<DesenvolvedorDtoUpdateResult>(result);
        }
    }
}
