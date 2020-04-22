using Theatres.Domain.Contracts;

namespace Theatres.Domain.Models
{
    public class PerfomanceIdentityModel : IPerfomanceIdentity
    {
        public int Id { get; }

        public PerfomanceIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}