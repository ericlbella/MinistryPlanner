using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Models
{
    public class ChurchListItem
    {
        public int ChurchId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        public string Name { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
