using System.Threading.Tasks;
using Theatres.BLL.Contracts;
using Theatres.DataAccess.Contracts;
using Theatres.Domain;
using Theatres.Domain.Models;

namespace Theatres.BLL.Implementation
{
    public class ScheduleUpdateService : IScheduleUpdateService
    {
        private IScheduleDataAccess ScheduleDataAccess { get; }
        private IPerfomanceGetService PerfomanceGetService { get; }
        private ITheatreGetService TheatreGetService { get; }

        public ScheduleUpdateService(IScheduleDataAccess scheduleDataAccess, ITheatreGetService theatreGetService,
            IPerfomanceGetService perfomanceGetService)
        {
            this.ScheduleDataAccess = scheduleDataAccess;
            this.PerfomanceGetService = perfomanceGetService;
            this.TheatreGetService = theatreGetService;
        }

        public async Task<Schedule> UpdateAsync(ScheduleUpdateModel scheduleUpdateModel)
        {
            await PerfomanceGetService.ValidateAsync(scheduleUpdateModel);
            await TheatreGetService.ValidateAsync(scheduleUpdateModel);

            return await ScheduleDataAccess.UpdateAsync(scheduleUpdateModel);

        }
    }
}