using System.Collections.Generic;
using System.Threading.Tasks;
using Theatres.Domain;
using Theatres.Domain.Contracts;

namespace Theatres.BLL.Contracts
{
    public interface IScheduleGetService
    {
        Task<IEnumerable<Schedule>> GetAsync();
        Task<Schedule> GetAsync(IScheduleIdentity scheduleIdentity);
        Task ValidateAsync(IScheduleContainer scheduleContainer);
    }
}