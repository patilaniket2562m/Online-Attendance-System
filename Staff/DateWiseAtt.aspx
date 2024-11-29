<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendanceReport.aspx.cs" Inherits="AttendanceReport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Attendance Report</h2>
            <label for="txtRollNo">Roll Number:</label>
            <asp:TextBox ID="txtRollNo" runat="server"></asp:TextBox>
            <br />
            <label for="txtStartDate">Start Date:</label>
            <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <label for="txtEndDate">End Date:</label>
            <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <br /><br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
        </div>
    </form>
</body>
</html>
