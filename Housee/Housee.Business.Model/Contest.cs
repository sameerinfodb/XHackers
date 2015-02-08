using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Housee.Business.Model
{
    // A Game session will have one or more Contest 
    // Ex:  Quick 5 number Contest
    //      Full House Contest
    public class Contest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public Player Winner { get; set; }
    }
}
