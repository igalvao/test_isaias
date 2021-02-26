using System;

namespace Api.Domain.Dtos.LegalCase
{
    public class LegalCaseDto
    {
        public Guid Id { get; set; }
        public string CaseNumber { get; set; }
        public string CourtName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
