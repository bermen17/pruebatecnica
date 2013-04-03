<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Interface.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript">
    function validar() {
        mtxtName = document.getElementById("txtComments").value;
        
        if (mtxtName.length == 0) {
            alert('you must enter ...');
            return;
        }
        return false;
    }
</script>
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 109px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td colspan="2">
                    &nbsp;
                    <h3>
                        Insert new Task</h3>
                </td>
                <td>
                    <h3>
                        Today Due Tasks</h3>
                </td>
                <td>
                    <h3>
                        Unfinished Tasks</h3>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Task Name
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a task name"
                        ControlToValidate="txtName">
                    </asp:RequiredFieldValidator>
                </td>
                <td rowspan="5">
                    <asp:GridView ID="gvDueTasks" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="taskName" HeaderText="Task Name" />
                            <asp:BoundField DataField="startDate" HeaderText="Start Date" />
                            <asp:BoundField DataField="dueDate" HeaderText="Due Date" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td rowspan="5">
                    <asp:GridView ID="gvUnfinishedTasks" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="taskName" HeaderText="Task Name" />
                            <asp:BoundField DataField="startDate" HeaderText="Start Date" />
                            <asp:BoundField DataField="dueDate" HeaderText="Due Date" />
                            <asp:BoundField DataField="taskComments" HeaderText="Comments" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Start date
                </td>
                <td>
                    <asp:TextBox ID="txtStartDate" runat="server" ToolTip="AAAA-MM-DD"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter a start date"
                        ControlToValidate="txtStartDate">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Finish date
                </td>
                <td>
                    <asp:TextBox ID="txtFinishDate" runat="server" ToolTip="AAAA-MM-DD"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter a due date"
                        ControlToValidate="txtFinishDate">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Comments
                </td>
                <td>
                    <asp:TextBox ID="txtComments" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnInsert" runat="server" Style="margin-left: 91px" Text="Add" OnClick="btnInsert_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
