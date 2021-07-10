namespace BackEnd.Models
{
    public class Task
    {
        public int TaskId {get; set;}
        public string TaskName {get; set;}
        public string TaskDescription {get; set;}
        public bool TaskStatus {get; set;} = true;
    }
}