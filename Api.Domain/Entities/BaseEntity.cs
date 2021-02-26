using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        private DateTime? _RegistrationDate;
        public DateTime? RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = (value == null ? DateTime.UtcNow : value); }
        }


    }
}
