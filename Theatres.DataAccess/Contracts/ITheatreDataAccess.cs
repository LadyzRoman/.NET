using System.Collections.Generic;
using System.Threading.Tasks;
using Theatres.Domain;
using Theatres.Domain.Contracts;
using Theatres.Domain.Models;
namespace Theatres.DataAccess.Contracts
{
    public interface ITheatreDataAccess
    {
        Task<Theatre> InsertAsync(TheatreUpdateModel theatreUpdateModel);
        Task<IEnumerable<Theatre>> GetAsync();
        Task<Theatre> GetAsync(ITheatreIdentity theatreIdentity);
        Task<Theatre> UpdateAsync(TheatreUpdateModel theatreUpdateModel);
        Task<Theatre> GetByAsync(ITheatreContainer theatreContainer);

    }
}