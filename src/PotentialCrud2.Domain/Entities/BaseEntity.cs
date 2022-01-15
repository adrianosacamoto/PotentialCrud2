using System;
using System.ComponentModel.DataAnnotations;

namespace PotentialCrud2.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        private DateTime? dataHoraInclusao;
        public DateTime? DataHoraInclusao
        {
            get { return dataHoraInclusao; }
            set { dataHoraInclusao = value ?? DateTime.UtcNow; }
        }
        public DateTime? DataHoraAlteracao { get; set; }
    }
}
