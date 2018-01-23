using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.MyFirstModule.Models
{
    public class Task
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public int ModuleId { get; set; }

        public bool IsComplete { get; set; }

        public int UserId { get; set; }


    }


}