using System.Threading.Tasks;
using Theatres.BLL.Contracts;
using Theatres.DataAccess.Contracts;
using Theatres.Domain;
using Theatres.Domain.Models;

namespace Theatres.BLL.Implementation
{
    public class PerfomanceUpdateService : IPerfomanceUpdateService
    {
        private IPerfomanceDataAccess PerfomanceDataAccess { get; }

        public PerfomanceUpdateService(IPerfomanceDataAccess perfomanceDataAccess)
        {
            this.PerfomanceDataAccess = perfomanceDataAccess;
        }

        public Task<Perfomance> UpdateAsync(PerfomanceUpdateModel perfomanceUpdateModel)
        {
            return PerfomanceDataAccess.UpdateAsync(perfomanceUpdateModel);
        }
    }
}