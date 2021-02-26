using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class LegalCaseImplementation : BaseRepository<LegalCaseEntity>, ILegalCaseRepository
    {
        private DbSet<LegalCaseEntity> _dataset;
        public LegalCaseImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<LegalCaseEntity>();
        }
        public async Task<LegalCaseEntity> FindByCourtName(string CourtName)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.CourtName.Equals(CourtName));
        }
    }
}
