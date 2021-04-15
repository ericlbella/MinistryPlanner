using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Data
{
    public class Pastor : Individual
    {
        //[Key]
        //public int PastorId { get; set; }
        //[ForeignKey("Church")]
        //public int ChurchId { get; set; }
        //public virtual Church Church { get; set; }
        [Required]
        public bool SeniorPastor { get; set; }
        [Required]
        public bool AssistantPastor { get; set; }
        [Required]
        public bool YouthPastor { get; set; }
        [Required]
        public bool SongLeader { get; set; }

        public Pastor() { }
        public Pastor(bool seniorPastor, bool assistantPastor, bool youthPastor, bool songLeader, string firstName, string middleName, string lastName, string email, string homePhone, string cellPhone, DateTime dateOfBirth, string address, string city, string state, string zip, DateTimeOffset createdUtc, DateTimeOffset? modifiedUtc)
            : base(firstName, middleName, lastName, email, homePhone, cellPhone, dateOfBirth, address, city, state, zip, createdUtc, modifiedUtc)
        {
            SeniorPastor = seniorPastor;
            AssistantPastor = assistantPastor;
            YouthPastor = youthPastor;
            SongLeader = songLeader;
            CreatedUtc = createdUtc;
            ModifiedUtc = modifiedUtc;
        }
    }
}
