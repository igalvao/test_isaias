using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface ILegalCaseRepository : IRepository<LegalCaseEntity>
    {
        Task<LegalCaseEntity> FindByCourtName(string CourtName);
    }
}
