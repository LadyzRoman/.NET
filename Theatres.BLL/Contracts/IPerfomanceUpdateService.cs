using System.Threading.Tasks;
using Theatres.Domain;
using Theatres.Domain.Models;

namespace Theatres.BLL.Contracts
{
    public interface IPerfomanceUpdateService
    {
        Task<Perfomance> UpdateAsync(PerfomanceUpdateModel perfomanceUpdateModel);
    }
}