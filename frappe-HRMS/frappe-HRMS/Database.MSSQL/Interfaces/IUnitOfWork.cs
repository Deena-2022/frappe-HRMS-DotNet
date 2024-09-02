using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.MSSQL.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IOpportunityRepository Opportunity { get; }
        IUserRepository User { get; }
        Task Save();
    }
}
