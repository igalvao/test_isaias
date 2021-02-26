using System;

namespace Api.Domain.Dtos.LegalCase
{
    public class LegalCaseDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CourtName { get; set; }
    }
}
