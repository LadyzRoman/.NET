using System.Threading.Tasks;
using Theatres.BLL.Contracts;
using Theatres.DataAccess.Contracts;
using Theatres.DataAccess.Implementations;
using Theatres.Domain;
using Theatres.Domain.Models;

namespace Theatres.BLL.Implementation
{
    public class PerfomanceCreateService : IPerfomanceCreateService
    {
        private IPerfomanceDataAccess PerfomanceDataAccess { get; }

        public PerfomanceCreateService(IPerfomanceDataAccess perfomanceDataAccess)
        {
            this.PerfomanceDataAccess = perfomanceDataAccess;
        }

        public Task<Perfomance> CreateAsync(PerfomanceUpdateModel perfomanceUpdateModel)
        {
            return PerfomanceDataAccess.InsertAsync(perfomanceUpdateModel);
        }
    }
}