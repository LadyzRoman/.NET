using System.Collections.Generic;
using System.Threading.Tasks;
using Theatres.Domain;
using Theatres.Domain.Contracts;
using Theatres.Domain.Models;
namespace Theatres.DataAccess.Contracts
{
    public interface IScheduleDataAccess
    {
        Task<Schedule> InsertAsync(ScheduleUpdateModel scheduleUpdateModel);
        Task<IEnumerable<Schedule>> GetAsync();
        Task<Schedule> GetAsync(IScheduleIdentity scheduleIdentity);
        Task<Schedule> UpdateAsync(ScheduleUpdateModel scheduleUpdateModel);
        Task<Schedule> GetByAsync(IScheduleContainer scheduleContainer);

    }
}