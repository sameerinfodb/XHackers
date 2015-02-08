using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housee.Business.Model
{
    public class Game
    {
        public Game()
        {
            Contests = new List<Contest>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public  DateTime ScduledDateTime { get; set; }
        public virtual List<Contest> Contests { get; set; }
        public virtual List<Announcement> announcement { get; set; }

    }
    public enum Status
    {
        NotStarted=0,
        Started,
        Completed
    }
}
