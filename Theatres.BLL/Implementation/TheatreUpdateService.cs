using System.Threading.Tasks;
using Theatres.BLL.Contracts;
using Theatres.DataAccess.Contracts;
using Theatres.Domain;
using Theatres.Domain.Models;

namespace Theatres.BLL.Implementation
{
    public class TheatreUpdateService : ITheatreUpdateService
    {
        private ITheatreDataAccess TheatreDataAccess { get; }

        public TheatreUpdateService(ITheatreDataAccess theatreDataAccess)
        {
            this.TheatreDataAccess = theatreDataAccess;
        }

        public Task<Theatre> UpdateAsync(TheatreUpdateModel theatreUpdateModel)
        {
            return TheatreDataAccess.UpdateAsync(theatreUpdateModel);
        }
    }
}