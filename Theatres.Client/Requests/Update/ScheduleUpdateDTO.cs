using Theatres.Client.Requests.Create;

namespace Theatres.Client.Requests.Update
{
    public class ScheduleUpdateDTO : ScheduleCreateDTO
    {
        public int Id { get; set; }
    }
}