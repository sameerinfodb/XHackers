using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housee.Business.Model
{
    public class Chit
    {

        public Chit()
        {
            numbers = new List<int>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public Player Player { get; set; }
        public Game Game { get; set; }
        public virtual List<int> numbers { get; set; }

    }
}
