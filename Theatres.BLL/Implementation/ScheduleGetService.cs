using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theatres.BLL.Contracts;
using Theatres.DataAccess.Contracts;
using Theatres.Domain;
using Theatres.Domain.Contracts;

namespace Theatres.BLL.Implementation
{
    public class ScheduleGetService : IScheduleGetService
    {
        private IScheduleDataAccess ScheduleDataAccess { get; }
        
        public ScheduleGetService(IScheduleDataAccess scheduleDataAccess)
        {
            this.ScheduleDataAccess = scheduleDataAccess;
        }
        public Task<IEnumerable<Schedule>> GetAsync()
        {
            return this.ScheduleDataAccess.GetAsync();
        }

        public Task<Schedule> GetAsync(IScheduleIdentity scheduleIdentity)
        {
            return this.ScheduleDataAccess.GetAsync(scheduleIdentity);
        }

        public async Task ValidateAsync(IScheduleContainer scheduleContainer)
        {
            if (scheduleContainer == null)
            {
                throw new ArgumentNullException(nameof(scheduleContainer));
            }
            
            var schedule = await this.GetBy(scheduleContainer);

            if (scheduleContainer.ScheduleId.HasValue && schedule == null)
            {
                throw new InvalidOperationException($"Schedule not found by id {scheduleContainer.ScheduleId}");
            }
        }
        private Task<Schedule> GetBy(IScheduleContainer scheduleContainer)
        {
            return this.ScheduleDataAccess.GetByAsync(scheduleContainer);
        }
    }
}