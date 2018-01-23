using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using System.Collections.Generic;

namespace Christoc.Modules.MyFirstModule.Models
{
    public class TaskLogic
    {
        public IList<Task> GetTasks(int ModuleID)
        {
            return CBO.FillCollection<Task>(DataProvider.Instance().ExecuteReader("CBP_GetTasks", ModuleID));
        }

        public void AddTask(Task task)
        {
            task.TaskId = DataProvider.Instance().ExecuteScalar<int>("CBP_AddTask",
                                                      task.TaskName,
                                                      task.TaskDescription,
                                                      task.IsComplete,
                                                      task.ModuleId,
                                                       task.UserId);
        }
        public void UpdateTask(Task task)
        {
            task.TaskId = DataProvider.Instance().ExecuteScalar<int>("CBP_UpdateTask",
                                                                     task.TaskId,
                                                                     task.TaskName,
                                                                     task.TaskDescription,
                                                                     task.IsComplete);
        }

        public void DeleteTask(int taskId)
        {
            DataProvider.Instance().ExecuteNonQuery("CBP_DeleteTask", taskId);
        }

        public IList<Task> GetIncompleteTasks(int ModuleId)
        {
            return CBO.FillCollection<Task>(DataProvider.Instance().ExecuteReader("CBP_GetIncompleteTasks", ModuleId));
        }
    }
}