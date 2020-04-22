using System.Collections.Generic;
using System.Threading.Tasks;
using Theatres.Domain;
using Theatres.Domain.Contracts;
using Theatres.Domain.Models;

namespace Theatres.DataAccess.Contracts
{
    public interface IPerfomanceDataAccess
    {
        Task<Perfomance> InsertAsync(PerfomanceUpdateModel perfomanceUpdateModel);
        Task<IEnumerable<Perfomance>> GetAsync();
        Task<Perfomance> GetAsync(IPerfomanceIdentity perfomanceIdentity);
        Task<Perfomance> UpdateAsync(PerfomanceUpdateModel perfomanceUpdateModel);
        Task<Perfomance> GetByAsync(IPerfomanceContainer perfomanceContainer);

    }
}