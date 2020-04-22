using System.ComponentModel.DataAnnotations;

namespace Theatres.Client.Requests.Create
{
    public class ScheduleCreateDTO
    {
        public int? PerfomanceId{ get; set; }
        
        [Required(ErrorMessage = "Time is required")]
        public string Time { get; set; }
        
        [Required(ErrorMessage = "Date is required")]
        public string Date { get; set; }

        public int? TheatreId { get; set; }
    }
}