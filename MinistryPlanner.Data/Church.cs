using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Data
{
    public class Church
    {
        [Key]
        public int ChurchId { get; set; }
        
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
        public State State { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "There are too many characters in this field.")]
        [MinLength(4, ErrorMessage = "Please enter at least 4 characters.")]
        public string Zip { get; set; }
        public Denomination DenominationOfChurch { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        
    }
    public enum State { AK, AL, AR, AS, AZ, CA, CO, CT, DC, DE, FL, GA, GU, HI, IA, ID, IL, IN, KS, KY, LA, MA, MD, ME, MI, MN, MO, MP, MS, MT, NC, ND, NE, NH, NJ, NM, NV, NY, OH, OK, OR, PA, PR, RI, SC, SD, TN, TX, UM, UT, VA, VI, VT, WA, WI, WV, WY }
    public enum Denomination { Baptist, Catholic, Christian, Episcopal, Lutheran, Methodist, Orthodox, Presbyterian, Reformed, SpiritFilled }
}
