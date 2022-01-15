using System;
using System.Threading.Tasks;
using PotentialCrud2.Data.Context;
using PotentialCrud2.Data.Implementations;
using PotentialCrud2.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace PotentialCrud2.Data.Test
{
    public class DesenvolvedorCrudCompletoTeste : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public DesenvolvedorCrudCompletoTeste(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Teste Fluxo Completo do CRUD de Desenvolvedores")]
        [Trait("CRUD", "DesenvolvedorEntity")]
        public async Task Realizar_CRUD_Desenvolvedor()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                DesenvolvedorImplementation _repositorio = new DesenvolvedorImplementation(context);
                DesenvolvedorEntity _entity = new DesenvolvedorEntity
                {
                    Nome = Faker.Name.FullName(),
                    Sexo = 'M',
                    Idade = 26,
                    Hobby = "Dormir",
                    DataNascimento = Faker.DateOfBirth.Next()
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);

                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Nome, _registroCriado.Nome);
                Assert.Equal('M', _registroCriado.Sexo);
                Assert.Equal(26, _registroCriado.Idade);
                Assert.Equal("Dormir", _registroCriado.Hobby);
                Assert.Equal(_entity.DataNascimento, _registroCriado.DataNascimento);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entity.Nome = Faker.Name.Last();
                _entity.Sexo = 'F';
                _entity.Idade = 27;
                _entity.Hobby = "Pescar enquanto dorme";
                _entity.DataNascimento = Faker.DateOfBirth.Next().AddDays(1);
                var _registroAlterado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_registroAlterado);
                Assert.Equal(_entity.Nome, _registroAlterado.Nome);
                Assert.Equal(_entity.Sexo, _registroAlterado.Sexo);
                Assert.Equal(_entity.Idade, _registroAlterado.Idade);
                Assert.Equal(_entity.Hobby, _registroAlterado.Hobby);
                Assert.Equal(_entity.DataNascimento, _registroAlterado.DataNascimento);

                var _registroExiste = await _repositorio.ExistAsync(_registroAlterado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroAlterado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAlterado.Nome, _registroSelecionado.Nome);
                Assert.Equal(_registroAlterado.Sexo, _registroSelecionado.Sexo);
                Assert.Equal(_registroAlterado.Idade, _registroSelecionado.Idade);
                Assert.Equal(_registroAlterado.Hobby, _registroSelecionado.Hobby);
                Assert.Equal(_registroAlterado.DataNascimento, _registroSelecionado.DataNascimento);

                var _registroSelecionadoPorParametro = await _repositorio.SelectAsync(_registroAlterado.Nome, 0, 1);
                Assert.NotNull(_registroSelecionadoPorParametro);

                var _todosOsRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosOsRegistros);
                Assert.NotEmpty(_todosOsRegistros);

                var _removeuORegistro = await _repositorio.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeuORegistro);
            }
        }
    }
}
