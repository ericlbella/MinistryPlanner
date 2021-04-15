using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Models
{
    public class VisitorCreate
    {
        [Required]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        [Required]
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
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string State { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "There are too many characters in this field.")]
        [MinLength(4, ErrorMessage = "Please enter at least 4 characters.")]
        public string Zip { get; set; }
        public DateTime DateVisited { get; set; }
    }
}
