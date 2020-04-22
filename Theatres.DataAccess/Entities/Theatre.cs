using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatres.DataAccess.Entities
{
        public partial class Theatre
    {
        public Theatre()
        {
            this.Schedule = new HashSet<Schedule>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual ICollection<Schedule> Schedule { get; set; }

        public int Id { get; set; }
        
        //Название театра
        public string Name { get; set; }

        //Адрес
        public string Address { get; set; }
        
    }
}