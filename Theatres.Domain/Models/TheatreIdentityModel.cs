using Theatres.Domain.Contracts;

namespace Theatres.Domain.Models
{
    public class TheatreIdentityModel : ITheatreIdentity
    {
        public int Id { get; }

        public TheatreIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}