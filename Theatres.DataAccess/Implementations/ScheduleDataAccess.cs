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
    public class ScheduleDataAccess : IScheduleDataAccess
    {
        private TheatreContext theaterContext { get; }
        private IMapper Mapper { get; }

        public ScheduleDataAccess(TheatreContext context, IMapper mapper)
        {
            this.theaterContext = context;
            Mapper = mapper;
        }

        public async Task<Schedule> InsertAsync(ScheduleUpdateModel scheduleUpdateModel)
        {
            var result = await this.theaterContext.AddAsync(this.Mapper.Map<DataAccess.Entities.Schedule>(scheduleUpdateModel));
            await this.theaterContext.SaveChangesAsync();
            return this.Mapper.Map<Schedule>(result.Entity);
        }

        public async Task<IEnumerable<Schedule>> GetAsync()
        {
            //TODO
            return this.Mapper.Map<IEnumerable<Schedule>>(await this.theaterContext.Schedule.Include(x => x.Theatre).Include(x=>x.Perfomance).ToListAsync());
        }

        public async Task<Schedule> GetAsync(IScheduleIdentity scheudleIdentity)
        {

            var result = await this.Get(scheudleIdentity);
            return this.Mapper.Map<Schedule>(result);
        }
        
        private async Task<Theatres.DataAccess.Entities.Schedule> Get(IScheduleIdentity scheduleIdentity)
        {
            //TODO
            if (scheduleIdentity == null)
                throw new ArgumentNullException(nameof(scheduleIdentity));
            return await this.theaterContext.Schedule.Include(x => x.Theatre).Include(x=>x.Perfomance).FirstOrDefaultAsync(x => x.Id == scheduleIdentity.Id);
            
        }

        public async Task<Schedule> UpdateAsync(ScheduleUpdateModel scheduleUpdateModel)
        {
            var existing = await this.Get(scheduleUpdateModel);

            var result = this.Mapper.Map(scheduleUpdateModel, existing);

            this.theaterContext.Update(result);

            await this.theaterContext.SaveChangesAsync();

            return this.Mapper.Map<Schedule>(result);
        }

        public async Task<Schedule> GetByAsync(IScheduleContainer scheduleContainer)
        {
            return scheduleContainer.ScheduleId.HasValue 
                ? this.Mapper.Map<Schedule>(await this.theaterContext.Schedule.FirstOrDefaultAsync(x => x.Id == scheduleContainer.ScheduleId)) 
                : null;
        }
    }
}