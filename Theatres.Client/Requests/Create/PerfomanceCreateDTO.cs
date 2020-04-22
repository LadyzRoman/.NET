using System.ComponentModel.DataAnnotations;

namespace Theatres.Client.Requests.Create
{
    public class PerfomanceCreateDTO
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Date of premiere is required")]
        public string DateOfPremiere { get; set; }

    }
}