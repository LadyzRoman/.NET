using System.ComponentModel.DataAnnotations;

namespace Theatres.Client.Requests.Create
{
    public class TheatreCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}