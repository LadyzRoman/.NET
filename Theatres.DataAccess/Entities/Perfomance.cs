using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatres.DataAccess.Entities
{
    public class Perfomance
    {
        public Perfomance()
        {
            this.Schedule = new HashSet<Schedule>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        //Название спектакля
        public string Title { get; set; }

        //Режиссер
        public string Director { get; set; }

        //Дата премьеры
        public string DateOfPremiere { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}