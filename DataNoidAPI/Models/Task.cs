using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataNoidAPI.Models
{
    public class Task
    {
        [ForeignKey(name: "Module")]
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool TaskStatus { get; set; } = true;
    }
}