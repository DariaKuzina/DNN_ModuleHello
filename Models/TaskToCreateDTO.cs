using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.MyFirstModule.Models
{
    public class TaskToCreateDTO
    {
        public string TTC_TaskName { get; set; }
        public string TTC_TaskDescription { get; set; }
        public bool TTC_isComplete { get; set; }
        public int TTC_ModuleID { get; set; }
        public int TTC_UserId { get; set; }
    }
}