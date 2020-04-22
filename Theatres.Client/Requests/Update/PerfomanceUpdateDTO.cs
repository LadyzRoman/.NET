using Theatres.Client.Requests.Create;

namespace Theatres.Client.Requests.Update
{
    public class PerfomanceUpdateDTO : PerfomanceCreateDTO
    {
        public int Id { get; set; }
    }
}