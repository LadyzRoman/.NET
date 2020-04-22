using Theatres.Domain.Contracts;

namespace Theatres.Domain.Models
{
    public class ScheduleIdentityModel : IScheduleIdentity
    {
        public int Id { get; }

        public ScheduleIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}