using System.Threading.Tasks;
using Theatres.Domain;
using Theatres.Domain.Models;

namespace Theatres.BLL.Contracts
{
    public interface IPerfomanceCreateService
    {
        Task<Perfomance> CreateAsync(PerfomanceUpdateModel perfomanceUpdateModel);
    }
}