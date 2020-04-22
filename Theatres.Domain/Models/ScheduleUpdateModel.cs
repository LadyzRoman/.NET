using Theatres.Domain.Contracts;

namespace Theatres.Domain.Models
{
    public class ScheduleUpdateModel : IScheduleIdentity, IPerfomanceContainer, ITheatreContainer
    {
        public int Id { get; set; }
        
        public string Time { get; set; }
        
        public string Date { get; set; }
        
        public int? PerfomanceId { get; set; }
        public int? TheatreId { get; set; }
    }
}