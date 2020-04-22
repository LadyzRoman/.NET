using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theatres.BLL.Contracts;
using Theatres.DataAccess.Contracts;
using Theatres.Domain;
using Theatres.Domain.Contracts;

namespace Theatres.BLL.Implementation
{
    
    public class TheatreGetService : ITheatreGetService
    {
        private ITheatreDataAccess TheaterDataAccess { get; }
        
        public TheatreGetService(ITheatreDataAccess theaterDataAccess)
        {
            this.TheaterDataAccess = theaterDataAccess;
        }
        public Task<IEnumerable<Theatre>> GetAsync()
        {
            return this.TheaterDataAccess.GetAsync();
        }

        public Task<Theatre> GetAsync(ITheatreIdentity theatreIdentity)
        {
            return this.TheaterDataAccess.GetAsync(theatreIdentity);
        }

        public async Task ValidateAsync(ITheatreContainer theatreContainer)
        {
            if (theatreContainer == null)
            {
                throw new ArgumentNullException(nameof(theatreContainer));
            }
            
            var theatre = await this.GetBy(theatreContainer);

            if (theatreContainer.TheatreId.HasValue && theatre == null)
            {
                throw new InvalidOperationException($"Theatre not found by id {theatreContainer.TheatreId}");
            }
        }
        private Task<Theatre> GetBy(ITheatreContainer theatreContainer)
        {
            return this.TheaterDataAccess.GetByAsync(theatreContainer);
        }
    }
}