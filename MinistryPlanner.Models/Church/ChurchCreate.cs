using MinistryPlanner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Models
{
    public class ChurchCreate
    {
        [Required]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        public string Name { get; set; }
        
        public int NumberMembers { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "There are too many characters in this field.")]
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        public string Address { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        public string City { get; set; }
        public State StateOfChurch { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "There are too many characters in this field.")]
        [MinLength(4, ErrorMessage = "Please enter at least 4 characters.")]
        public string Zip { get; set; }
        public Denomination DenominationOfChurch { get; set; }
    }
}
