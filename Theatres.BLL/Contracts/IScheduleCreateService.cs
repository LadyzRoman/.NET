using System.Threading.Tasks;
using Theatres.Domain;
using Theatres.Domain.Models;

namespace Theatres.BLL.Contracts
{
    public interface IScheduleCreateService
    {
        Task<Schedule> CreateAsync(ScheduleUpdateModel scheduleUpdateModel);
    }
}