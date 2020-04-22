using System.Collections.Generic;
using System.Threading.Tasks;
using Theatres.Domain;
using Theatres.Domain.Contracts;

namespace Theatres.BLL.Contracts
{
    public interface IPerfomanceGetService
    {
        Task<IEnumerable<Perfomance>> GetAsync();
        Task<Perfomance> GetAsync(IPerfomanceIdentity perfomanceIdentity);
        Task ValidateAsync(IPerfomanceContainer perfomanceContainer);
    }
}