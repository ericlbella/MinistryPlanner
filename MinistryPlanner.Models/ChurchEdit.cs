using MinistryPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Models
{
    public class ChurchEdit
    {
        public int ChurchId { get; set; }
        public string Name { get; set; }
        public int NumberMembers { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string Zip { get; set; }
        public Denomination Denomination { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
