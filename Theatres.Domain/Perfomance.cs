using Theatres.Domain.Contracts;

namespace Theatres.Domain
{
    public class Perfomance 
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Director { get; set; }

        public string DateOfPremiere { get; set; }
    }
}