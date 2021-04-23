using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Data
{
    public abstract class Individual
    {
        [Key]
        public int IndividualId { get; set; }
        [ForeignKey("Church")]
        public int ChurchId { get; set; }
        public virtual Church Church { get; set; }
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
        //[MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        //public State StateOfChurch { get; set; }
        public State State { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "There are too many characters in this field.")]
        [MinLength(4, ErrorMessage = "Please enter at least 4 characters.")]
        public string Zip { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }


        public Individual() { }
        public Individual(string firstName, string middleName, string lastName, string email, string homePhone, string cellPhone, DateTime dateOfBirth, string address, string city, State state, string zip, DateTimeOffset createdUtc, DateTimeOffset? modifiedUtc) 
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Email = email;
            HomePhone = HomePhone;
            CellPhone = cellPhone;
            DateOfBirth = DateOfBirth;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            CreatedUtc = createdUtc;
            ModifiedUtc = modifiedUtc;
        }
    }
}
