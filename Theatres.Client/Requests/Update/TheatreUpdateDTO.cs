using Theatres.Client.Requests.Create;

namespace Theatres.Client.Requests.Update
{
    public class TheatreUpdateDTO : TheatreCreateDTO
    {
        public int Id { get; set; }
    }
}