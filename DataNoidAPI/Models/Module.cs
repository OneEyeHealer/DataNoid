using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataNoidAPI.Models
{
    public class Module
    {
        [ForeignKey(name: "AppUser")]
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        [Key]
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public bool ModuleStatus { get; set; } = true;
        public ICollection<Task> Tasks { get; set; }
    }
}