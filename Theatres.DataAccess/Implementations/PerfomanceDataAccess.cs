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
    public class PerfomanceDataAccess : IPerfomanceDataAccess
    {
        private TheatreContext theaterContext { get; }
        private IMapper Mapper { get; }

        public PerfomanceDataAccess(TheatreContext context, IMapper mapper)
        {
            this.theaterContext = context;
            Mapper = mapper;
        }

        public async Task<Perfomance> InsertAsync(PerfomanceUpdateModel perfomanceUpdateModel)
        {
            var result = await this.theaterContext.AddAsync(this.Mapper.Map<DataAccess.Entities.Perfomance>(perfomanceUpdateModel));

            await this.theaterContext.SaveChangesAsync();

            return this.Mapper.Map<Perfomance>(result.Entity);
        }

        public async Task<IEnumerable<Perfomance>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Perfomance>>(
                await this.theaterContext.Perfomance.ToListAsync());
        }

        public async Task<Perfomance> GetAsync(IPerfomanceIdentity perfomanceIdentity)
        {
            var result = await this.Get(perfomanceIdentity);

            return this.Mapper.Map<Perfomance>(result);
        }

        public async Task<Perfomance> UpdateAsync(PerfomanceUpdateModel theatreUpdateModel)
        {
            var existing = await this.Get(theatreUpdateModel);

            var result = this.Mapper.Map(theatreUpdateModel, existing);

            this.theaterContext.Update(result);

            await this.theaterContext.SaveChangesAsync();

            return this.Mapper.Map<Perfomance>(result);
        }

        public async Task<Perfomance> GetByAsync(IPerfomanceContainer perfomanceContainer)
        {
            return perfomanceContainer.PerfomanceId.HasValue 
                ? this.Mapper.Map<Perfomance>(await this.theaterContext.Perfomance.FirstOrDefaultAsync(x => x.Id == perfomanceContainer.PerfomanceId)) 
                : null;
        }

        private async Task<Theatres.DataAccess.Entities.Perfomance> Get(IPerfomanceIdentity perfomanceIdentity)
        {
            if(perfomanceIdentity == null)
                throw new ArgumentNullException(nameof(perfomanceIdentity));
            return await this.theaterContext.Perfomance.FirstOrDefaultAsync(x => x.Id == perfomanceIdentity.Id);
        }
    }
}