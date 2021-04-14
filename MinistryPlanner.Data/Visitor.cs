using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Data
{
    public class Visitor : Individual
    {
        //[Key]
        //public int VisitorId { get; set; }
        //[ForeignKey("Church")]
        //public int ChurchId { get; set; }
        //public virtual Church Church { get; set; }
        [Required]
        public DateTime DateVisited { get; set; }
        public Visitor() { }
        public Visitor(DateTime dateVisited, string firstName, string middleName, string lastName, string email, string homePhone, string cellPhone, DateTime dateOfBirth, string address, string city, string state, string zip)
            : base(firstName, middleName, lastName, email, homePhone, cellPhone, dateOfBirth, address, city, state, zip)
        {
            DateVisited = dateVisited;
        }
    }
}
