using MinistryPlanner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Models
{
    public class VisitorDetail
    {
        [Display(Name = "Individual Id")]
        public int IndividualId { get; set; }
        [Display(Name = "Church Id")]
        public int ChurchId { get; set; }
        [Display(Name = "Church Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "There are too many characters in this field.")]
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        public string Address { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        public string City { get; set; }
        [Required]
        //[MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        //public State StateOfChurch { get; set; }
        public State State { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "There are too many characters in this field.")]
        [MinLength(4, ErrorMessage = "Please enter at least 4 characters.")]
        public string Zip { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Visited")]
        public DateTime DateVisited { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
