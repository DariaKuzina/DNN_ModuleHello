namespace Christoc.Modules.MyFirstModule.Models
{
    public class TaskToUpdateDTO
    {
        public string TTU_TaskName { get; set; }
        public string TTU_TaskDescription { get; set; }
        public bool TTU_isComplete { get; set; }
        public int TTU_TaskID { get; set; }
    }
}