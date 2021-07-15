using System;
using System.Collections.Generic;
using System.Web.Http.Cors;


namespace BackEnd.Models
{
    [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    public class AppUser
    {
        public int AppUserId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public long PhoneNo {get; set;}
        public DateTime DateOfBirth {get; set;}
        public int Age {get; set;}
        public string Department {get; set;}
        public string JobRole {get; set;}
        public ICollection<Address> Addresses {get; set;}
        public ICollection<Module> Modules {get; set;}

    }
}