using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Models
{
    public class PastorListItem
    {
        [Display(Name = "Individual Id")]
        public int IndividualId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Senior Pastor")]
        public bool SeniorPastor { get; set; }
        [Display(Name = "Assistant Pastor")]
        public bool AssistantPastor { get; set; }
        [Display(Name = "Youth Pastor")]
        public bool YouthPastor { get; set; }
        [Display(Name = "Song Leader")]
        public bool SongLeader { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
