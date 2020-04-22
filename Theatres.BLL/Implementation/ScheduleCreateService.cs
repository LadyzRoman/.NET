using System.Threading.Tasks;
using Theatres.BLL.Contracts;
using Theatres.DataAccess.Contracts;
using Theatres.Domain;
using Theatres.Domain.Models;

namespace Theatres.BLL.Implementation
{
    public class ScheduleCreateService : IScheduleCreateService
    {
        private IScheduleDataAccess ScheduleDataAccess { get; }
        private IPerfomanceGetService PerfomanceGetService { get; }
        private ITheatreGetService TheatreGetService { get; }

        public ScheduleCreateService(IScheduleDataAccess scheduleDataAccess, ITheatreGetService theatreGetService,
            IPerfomanceGetService perfomanceGetService)
        {
            this.ScheduleDataAccess = scheduleDataAccess;
            this.PerfomanceGetService = perfomanceGetService;
            this.TheatreGetService = theatreGetService;
        }

        public async Task<Schedule> CreateAsync(ScheduleUpdateModel scheduleUpdateModel)
        {
            await PerfomanceGetService.ValidateAsync(scheduleUpdateModel);
            await TheatreGetService.ValidateAsync(scheduleUpdateModel);

            return await ScheduleDataAccess.InsertAsync(scheduleUpdateModel);

        }
    }
}