using System.Threading.Tasks;
using Theatres.Domain;
using Theatres.Domain.Models;

namespace Theatres.BLL.Contracts
{
    public interface IScheduleUpdateService
    {
        Task<Schedule> UpdateAsync(ScheduleUpdateModel scheduleUpdateModel);
    }
}