using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Users;
using DotNetNuke.Web.Api;
using System;
using DotNetNuke.Security;

namespace Christoc.Modules.MyFirstModule.Models
{
    public class TaskController : DnnApiController
    {
        private TaskLogic _logicHandler = new TaskLogic();

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetTasks(int moduleId)
        {
            try
            {
                var tasks = _logicHandler.GetTasks(moduleId).ToJson();
                return Request.CreateResponse(HttpStatusCode.OK, tasks);
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetIncompleteTasks(int moduleId)
        {
            try
            {
                var tasks = _logicHandler.GetIncompleteTasks(moduleId).ToJson();
                return Request.CreateResponse(HttpStatusCode.OK, tasks);
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }

        }

        [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public HttpResponseMessage AddTask(TaskToCreateDTO DTO)
        {
            try
            {
                var task = new Task()
                {
                    TaskName = DTO.TTC_TaskName,
                    TaskDescription = DTO.TTC_TaskDescription,
                    IsComplete = DTO.TTC_isComplete,
                    ModuleId = DTO.TTC_ModuleID,
                    UserId = DTO.TTC_UserId
                };

                _logicHandler.AddTask(task);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public HttpResponseMessage UpdateTask(TaskToUpdateDTO DTO)
        {
            try
            {
                var task = new Task()
                {
                    TaskName = DTO.TTU_TaskName,
                    TaskDescription = DTO.TTU_TaskDescription,
                    IsComplete = DTO.TTU_isComplete,
                    TaskId = DTO.TTU_TaskID
                };

                _logicHandler.UpdateTask(task);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public HttpResponseMessage DeleteTask(TaskToDeleteDTO DTO)
        {
            try
            {
                var task = new Task()
                {
                    TaskId = DTO.TTD_TaskID
                };

                _logicHandler.DeleteTask(task.TaskId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
    }
}