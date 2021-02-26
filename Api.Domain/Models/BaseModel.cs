using System;

namespace Api.Domain.Models
{
    public class BaseModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _RegistrationDate;
        public DateTime RegistrationDate
        {
            get { return _RegistrationDate; }
            set
            {
                _RegistrationDate = value == null ? DateTime.UtcNow : value;
            }
        }

    }
}
