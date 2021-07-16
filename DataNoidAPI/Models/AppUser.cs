using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataNoidAPI.Models
{
    public class AppUser
    {
        [Key]
        public int AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public string JobRole { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Module> Modules { get; set; }
    }
}