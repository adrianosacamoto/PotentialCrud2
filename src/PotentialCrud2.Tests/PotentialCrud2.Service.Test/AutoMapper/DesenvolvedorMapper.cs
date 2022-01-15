using System;
using System.Collections.Generic;
using System.Linq;
using PotentialCrud2.Domain.Dtos.Desenvolvedor;
using PotentialCrud2.Domain.Entities;
using PotentialCrud2.Domain.Models;
using Xunit;

namespace PotentialCrud2.Service.Test.AutoMapper
{
    public class DesenvolvedorMapper : BaseTestService
    {
        [Fact(DisplayName = "Executar o mapeamento dos modelos.")]
        public void Executar_Mapeamento_Modelos()
        {
            var model = new DesenvolvedorModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Name.FullName(),
                Sexo = 'M',
                Idade = 50,
                Hobby = "Pescar",
                DataNascimento = Faker.DateOfBirth.Next(),
                DataHoraInclusao = DateTime.UtcNow,
                DataHoraAlteracao = DateTime.UtcNow
            };

            var listaEntity = new List<DesenvolvedorEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new DesenvolvedorEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    Sexo = 'F',
                    Idade = 35,
                    Hobby = "Fazer compras",
                    DataNascimento = Faker.DateOfBirth.Next(),
                    DataHoraInclusao = DateTime.UtcNow,
                    DataHoraAlteracao = DateTime.UtcNow
                };
            }

            var entity = Mapper.Map<DesenvolvedorEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.Sexo, model.Sexo);
            Assert.Equal(entity.Idade, model.Idade);
            Assert.Equal(entity.Hobby, model.Hobby);
            Assert.Equal(entity.DataNascimento, model.DataNascimento);
            Assert.Equal(entity.DataHoraInclusao, model.DataHoraInclusao);
            Assert.Equal(entity.DataHoraAlteracao, model.DataHoraAlteracao);

            var dto = Mapper.Map<DesenvolvedorDto>(entity);
            Assert.Equal(dto.Id, model.Id);
            Assert.Equal(dto.Nome, model.Nome);
            Assert.Equal(dto.Sexo, model.Sexo);
            Assert.Equal(dto.Idade, model.Idade);
            Assert.Equal(dto.Hobby, model.Hobby);
            Assert.Equal(dto.DataNascimento, model.DataNascimento);
            Assert.Equal(dto.DataHoraInclusao, model.DataHoraInclusao);

            var listaDto = Mapper.Map<List<DesenvolvedorDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listaDto[i].Sexo, listaEntity[i].Sexo);
                Assert.Equal(listaDto[i].Idade, listaEntity[i].Idade);
                Assert.Equal(listaDto[i].Hobby, listaEntity[i].Hobby);
                Assert.Equal(listaDto[i].DataNascimento, listaEntity[i].DataNascimento);
                Assert.Equal(listaDto[i].DataHoraInclusao, listaEntity[i].DataHoraInclusao);
            }

            var desenvolvedorDtoCreateResult = Mapper.Map<DesenvolvedorDtoCreateResult>(entity);
            Assert.Equal(desenvolvedorDtoCreateResult.Id, entity.Id);
            Assert.Equal(desenvolvedorDtoCreateResult.Nome, entity.Nome);
            Assert.Equal(desenvolvedorDtoCreateResult.Sexo, entity.Sexo);
            Assert.Equal(desenvolvedorDtoCreateResult.Idade, entity.Idade);
            Assert.Equal(desenvolvedorDtoCreateResult.Hobby, entity.Hobby);
            Assert.Equal(desenvolvedorDtoCreateResult.DataNascimento, entity.DataNascimento);
            Assert.Equal(desenvolvedorDtoCreateResult.DataHoraInclusao, entity.DataHoraInclusao);

            var desenvolvedorDtoUpdateResult = Mapper.Map<DesenvolvedorDtoUpdateResult>(entity);
            Assert.Equal(desenvolvedorDtoUpdateResult.Id, entity.Id);
            Assert.Equal(desenvolvedorDtoUpdateResult.Nome, entity.Nome);
            Assert.Equal(desenvolvedorDtoUpdateResult.Sexo, entity.Sexo);
            Assert.Equal(desenvolvedorDtoUpdateResult.Idade, entity.Idade);
            Assert.Equal(desenvolvedorDtoUpdateResult.Hobby, entity.Hobby);
            Assert.Equal(desenvolvedorDtoUpdateResult.DataNascimento, entity.DataNascimento);
            Assert.Equal(desenvolvedorDtoUpdateResult.DataHoraAlteracao, entity.DataHoraAlteracao);

            var desenvolvedorModel = Mapper.Map<DesenvolvedorModel>(dto);
            Assert.Equal(desenvolvedorModel.Id, dto.Id);
            Assert.Equal(desenvolvedorModel.Nome, dto.Nome);
            Assert.Equal(desenvolvedorModel.Sexo, dto.Sexo);
            Assert.Equal(desenvolvedorModel.Idade, dto.Idade);
            Assert.Equal(desenvolvedorModel.Hobby, dto.Hobby);
            Assert.Equal(desenvolvedorModel.DataNascimento, dto.DataNascimento);
            Assert.Equal(desenvolvedorModel.DataHoraInclusao, dto.DataHoraInclusao);

            var desenvolvedorDtoCreate = Mapper.Map<DesenvolvedorDtoCreate>(model);
            Assert.Equal(desenvolvedorDtoCreate.Id, model.Id);
            Assert.Equal(desenvolvedorDtoCreate.Nome, model.Nome);
            Assert.Equal(desenvolvedorDtoCreate.Sexo, model.Sexo);
            Assert.Equal(desenvolvedorDtoCreate.Idade, model.Idade);
            Assert.Equal(desenvolvedorDtoCreate.Hobby, model.Hobby);
            Assert.Equal(desenvolvedorDtoCreate.DataNascimento, model.DataNascimento);

            var desenvolvedorDtoUpdate = Mapper.Map<DesenvolvedorDtoUpdate>(model);
            Assert.Equal(desenvolvedorDtoUpdate.Id, model.Id);
            Assert.Equal(desenvolvedorDtoUpdate.Nome, model.Nome);
            Assert.Equal(desenvolvedorDtoUpdate.Sexo, model.Sexo);
            Assert.Equal(desenvolvedorDtoUpdate.Idade, model.Idade);
            Assert.Equal(desenvolvedorDtoUpdate.Hobby, model.Hobby);
            Assert.Equal(desenvolvedorDtoUpdate.DataNascimento, model.DataNascimento);
        }
    }
}
