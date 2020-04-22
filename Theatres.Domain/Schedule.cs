using Theatres.Domain.Contracts;

namespace Theatres.Domain
{
    public class Schedule : ITheatreContainer, IPerfomanceContainer
    {
        public int Id { get; set; }
        
        public Perfomance Perfomance{ get; set; }
        
        public string Time { get; set; }
        
        public string Date { get; set; }

        public Theatre Theatre { get; set; }
        
        public int? TheatreId => Theatre.Id;

        public int? PerfomanceId => Perfomance.Id;
    }
}