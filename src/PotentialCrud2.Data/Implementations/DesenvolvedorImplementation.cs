using Microsoft.EntityFrameworkCore;
using PotentialCrud2.Data.Context;
using PotentialCrud2.Data.Repository;
using PotentialCrud2.Domain.Entities;
using PotentialCrud2.Domain.Repository;

namespace PotentialCrud2.Data.Implementations
{
    public class DesenvolvedorImplementation : BaseRepository<DesenvolvedorEntity>, IDesenvolvedorRepository
    {
        private DbSet<DesenvolvedorEntity> _dataSet;

        public DesenvolvedorImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<DesenvolvedorEntity>();
        }
    }
}
