﻿using System;
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
        public string Name { get; set; }
        public enum Denomination { Baptist, Catholic, Christian, Episcopal, Lutheran, Methodist, Orthodox, Presbyterian, Reformed, SpiritFilled }
        public int NumberMembers { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public enum State { AK, AL, AR, AS, AZ, CA, CO, CT, DC, DE, FL, GA, GU, HI, IA, ID, IL, IN, KS, KY, LA, MA, MD, ME, MI, MN, MO, MP, MS, MT, NC, ND, NE, NH, NJ, NM, NV, NY, OH, OK, OR, PA, PR, RI, SC, SD, TN, TX, UM, UT, VA, VI, VT, WA, WI, WV, WY }
        public string Zip { get; set; }
    }
}
