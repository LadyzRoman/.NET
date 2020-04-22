namespace Theatres.Client.DTO.Read
{
    public class ScheduleDTO
    {
        //идентификатор
        public int Id { get; set; }

        //Время представления
        public string Time { get; set; }
        
        //Дата предаставления
        public string Date { get; set; }

        public TheatreDTO Theatre { get; set; }
        
        public PerfomanceDTO Perfomance{ get; set; }
    }
}