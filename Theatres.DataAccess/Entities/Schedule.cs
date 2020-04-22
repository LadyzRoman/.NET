using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatres.DataAccess.Entities
{
    public class Schedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        //Время спектакля
        public string Time { get; set; }

        //Дата спектакля
        public string Date { get; set; }
        
        public int? TheatreId { get; set; }

        public int? PerfomanceId { get; set; }

        public virtual Perfomance Perfomance { get; set; }

        public virtual Theatre Theatre { get; set; }
    }
}