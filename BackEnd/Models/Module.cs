using System.Collections.Generic;
namespace BackEnd.Models
{
    public class Module
    {
        public int ModuleId {get; set;}
        public string ModuleName {get; set;}
        public string ModuleDescription {get; set;}
        public bool ModuleStatus {get; set;} = true;
        public ICollection<Task> Tasks {get; set;}
    }
}