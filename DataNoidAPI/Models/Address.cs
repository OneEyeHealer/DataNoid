using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataNoidAPI.Models
{
    public class Address
    {
        [ForeignKey(name: "AppUser")]
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        [Key]
        public int AddressId { get; set; }
        public bool DefaultAddressType { get; set; } = false;
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Pincode { get; set; }
        public string Landmark { get; set; }
    }
}