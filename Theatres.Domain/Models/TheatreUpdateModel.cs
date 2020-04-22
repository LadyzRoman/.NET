using Theatres.Domain.Contracts;

namespace Theatres.Domain.Models
{
    public class TheatreUpdateModel: ITheatreIdentity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Address { get; set; }
    }
}