using BOC.Domain.DataEntity;
using Database.MSSQL.Context;
using Database.MSSQL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database.MSSQL.Repositories
{
    public class OpportunityRepository : GenericRepository<Opportunity>, IOpportunityRepository
    {
        public OpportunityRepository(BOCContext context) : base(context)
        {

        }
        public override async Task<List<Opportunity>> GetAll()
        {
            return await context.Opportunities.Include(o => o.Customer)
                .Include(o => o.SalesPerson).Where(o => !o.IsDeleted).ToListAsync();
        }
        public override Opportunity GetById(int id)
        {
            return   GetAll().Result.Where(o => o.Id == id).First();
        }
    }
}
