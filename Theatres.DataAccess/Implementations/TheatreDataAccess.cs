using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theatres.DataAccess.Context;
using Theatres.DataAccess.Contracts;
using Theatres.Domain;
using Theatres.Domain.Contracts;
using Theatres.Domain.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace Theatres.DataAccess.Implementations
{
    public class TheatreDataAccess : ITheatreDataAccess
    {
        private TheatreContext theatreContext { get; }
        private IMapper Mapper { get; }

        public TheatreDataAccess(TheatreContext context, IMapper mapper)
        {
            this.theatreContext = context;
            Mapper = mapper;
        }

        public async Task<Theatre> InsertAsync(TheatreUpdateModel theatreUpdateModel)
        {
            var result = await this.theatreContext.AddAsync(this.Mapper.Map<DataAccess.Entities.Theatre>(theatreUpdateModel));

            await this.theatreContext.SaveChangesAsync();

            return this.Mapper.Map<Theatre>(result.Entity);
        }

        public async Task<IEnumerable<Theatre>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Theatre>>(
                await this.theatreContext.Theatre.ToListAsync());

        }

        public async Task<Theatre> GetAsync(ITheatreIdentity theaterIdentity)
        {
            var result = await this.Get(theaterIdentity);

            return this.Mapper.Map<Theatre>(result);
        }

        public async Task<Theatre> UpdateAsync(TheatreUpdateModel theatreUpdateModel)
        {
            var existing = await this.Get(theatreUpdateModel);

            var result = this.Mapper.Map(theatreUpdateModel, existing);

            this.theatreContext.Update(result);

            await this.theatreContext.SaveChangesAsync();

            return this.Mapper.Map<Theatre>(result);
        }

        public async Task<Theatre> GetByAsync(ITheatreContainer theatreContainer)
        {
            return theatreContainer.TheatreId.HasValue 
                ? this.Mapper.Map<Theatre>(await this.theatreContext.Theatre.FirstOrDefaultAsync(x => x.Id == theatreContainer.TheatreId)) 
                : null;
        }

        private async Task<Theatres.DataAccess.Entities.Theatre> Get(ITheatreIdentity theatreIdentity)
        {
            //TODO
            if(theatreIdentity == null)
                throw new ArgumentNullException(nameof(theatreIdentity));
            return await this.theatreContext.Theatre.FirstOrDefaultAsync(x => x.Id == theatreIdentity.Id);
        }
    }
}