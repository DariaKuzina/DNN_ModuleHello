<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.MyFirstModule.View" %>
<div class="AddTaskDiv">
    <h2>Add Task</h2>
    <hr />
    <div class="lblTaskName">Task Name</div>
    <input id="TaskName" type="text" />
    <div class="lblTaskDescription">Task Description</div>
    <input id="TaskDescription" type="text" />
    <div class="isCompleteGroup">
        <input id="cbxIsComplete" type="checkbox" />
        <div class="lblTaskIsComplete">Is Complete</div>
    </div>
    <input class="dnnClear dnnRight dnnPrimaryAction" id="btnAddTask" type="button" value="Add Task" />
</div>
<div class="TaskListDiv">
    <div class="Headings">
        <h2>Task Name</h2>
        <h2>Task Description</h2>
        <h2>Complete</h2>
        <hr />
    </div>
    <div class="ListItems">
    </div>
</div>
<script type="text/javascript">

    var moduleId = <%= ModuleId %>;
    var userID = <%= UserId %>;

    function loadTasks() {
            $.getJSON(
            "/DesktopModules/MyFirstModule/API/Task/GetTasks?moduleId=" + moduleId,
             function (result) {
                 $('.ListItems').html("");
               var parsedTaskJSONObject = jQuery.parseJSON(result);
               $.each(parsedTaskJSONObject, function () {
                   var checked = '';
                   if (this.IsComplete == true) {
                       checked = ' checked';
                   }
                   $('.ListItems').append(
               
                     '<div class="ListTaskName">' + this.TaskName + '</div>' +
                     '<div class="ListTaskDescription">' + this.TaskDescription + '</div>'+
                     '<input class="checkbox" type="checkbox"' + checked + '/>');
               });
        });  
}

loadTasks();

    $('#btnAddTask').click(function() {
        var taskName = $('#TaskName').val();
        var taskDescription = $('#TaskDescription').val();
        var isComplete = $('#cbxIsComplete').prop('checked');

        var taskToCreate = {
            TTC_TaskName: taskName,
            TTC_TaskDescription: taskDescription,
            TTC_isComplete: isComplete,
            TTC_ModuleID: moduleId,
            TTC_UserID: userID
        };

        var sf = $.ServicesFramework(<%:ModuleContext.ModuleId%>);

        $.ajax({
            url: '/DesktopModules/MyFirstModule/API/Task/AddTask',
            type: "POST",
            contentType: "application/json",
            beforeSend: sf.setModuleHeaders,
            data: JSON.stringify(taskToCreate),
            success: function(data) {
                loadTasks();
            }
        });
    });
</script>
