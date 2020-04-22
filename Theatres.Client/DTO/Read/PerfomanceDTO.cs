namespace Theatres.Client.DTO.Read
{
    public class PerfomanceDTO
    {
        //идентификатор
        public int Id { get; set; }
        
        //Название спектакля
        public string Title { get; set; }

        //Режиссер
        public string Director { get; set; }

        //Дата премьеры
        public string DateOfPremiere { get; set; }
    }
}