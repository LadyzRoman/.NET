using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theatres.BLL.Contracts;
using Theatres.DataAccess.Contracts;
using Theatres.Domain;
using Theatres.Domain.Contracts;

namespace Theatres.BLL.Implementation
{
    public class PerfomanceGetService : IPerfomanceGetService
    {
        private IPerfomanceDataAccess PerfomanceDataAccess { get; }
        
        public PerfomanceGetService(IPerfomanceDataAccess perfomanceDataAccess)
        {
            this.PerfomanceDataAccess = perfomanceDataAccess;
        }
        public Task<IEnumerable<Perfomance>> GetAsync()
        {
            return this.PerfomanceDataAccess.GetAsync();
        }

        public Task<Perfomance> GetAsync(IPerfomanceIdentity perfomanceIdentity)
        {
            return this.PerfomanceDataAccess.GetAsync(perfomanceIdentity);
        }

        public async Task ValidateAsync(IPerfomanceContainer perfomanceContainer)
        {
            if (perfomanceContainer == null)
            {
                throw new ArgumentNullException(nameof(perfomanceContainer));
            }
            
            var perfomance = await this.GetBy(perfomanceContainer);

            if (perfomanceContainer.PerfomanceId.HasValue && perfomance == null)
            {
                throw new InvalidOperationException($"Perfomance not found by id {perfomanceContainer.PerfomanceId}");
            }
        }
        private Task<Perfomance> GetBy(IPerfomanceContainer perfomanceContainer)
        {
            return this.PerfomanceDataAccess.GetByAsync(perfomanceContainer);
        }
    }
}