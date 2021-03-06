using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Data
{
    public class Parishoner : Individual
    {
        //[Key]
        //public int ParishonerId {get; set;}
        //[ForeignKey("Church")]
        //public int ChurchId { get; set; }
        //public virtual Church Church { get; set; }
        [Required]
        public bool Officer { get; set; }
        public string OfficerTitle { get; set; }
        //public string State { get; set; }

        public Parishoner() { }
        public Parishoner(bool officer, string officerTitle, string firstName, string middleName, string lastName, string email, string homePhone, string cellPhone, DateTime dateOfBirth, string address, string city, State state, string zip, DateTimeOffset createdUtc, DateTimeOffset? modifiedUtc)
            : base(firstName, middleName, lastName, email, homePhone, cellPhone, dateOfBirth, address, city, state, zip, createdUtc, modifiedUtc)
        {
            Officer = officer;
            OfficerTitle = officerTitle;
            CreatedUtc = createdUtc;
            ModifiedUtc = modifiedUtc;
        }
    }
}
