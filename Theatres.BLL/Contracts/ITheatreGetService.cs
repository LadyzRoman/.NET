using System.Collections.Generic;
using System.Threading.Tasks;
using Theatres.Domain;
using Theatres.Domain.Contracts;

namespace Theatres.BLL.Contracts
{
    public interface ITheatreGetService
    {
        Task<IEnumerable<Theatre>> GetAsync();
        Task<Theatre> GetAsync(ITheatreIdentity theatreIdentity);
        Task ValidateAsync(ITheatreContainer theatreContainer);
    }
}