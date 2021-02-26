using System;

namespace Api.Domain.Dtos.LegalCase
{
    public class LegalCaseDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CourtName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
