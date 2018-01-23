<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="Christoc.Modules.MyFirstModule.Settings" %>

Show completed tasks
<asp:DropDownList ID="ShowCompletedTasksSelector" runat="server">
    <asp:ListItem Value="True">Yes</asp:ListItem>
    <asp:ListItem Value="False">No</asp:ListItem>
</asp:DropDownList>