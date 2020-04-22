using System.Threading.Tasks;
using Theatres.BLL.Contracts;
using Theatres.DataAccess.Contracts;
using Theatres.Domain;
using Theatres.Domain.Models;

namespace Theatres.BLL.Implementation
{
    public class TheatreCreateService : ITheatreCreateService
    {
        private ITheatreDataAccess TheatreDataAccess { get; }

        public TheatreCreateService(ITheatreDataAccess theatreDataAccess)
        {
            this.TheatreDataAccess = theatreDataAccess;
        }

        public  Task<Theatre> CreateAsync(TheatreUpdateModel theatreUpdateModel)
        {
            return TheatreDataAccess.InsertAsync(theatreUpdateModel);
        }
    }
}