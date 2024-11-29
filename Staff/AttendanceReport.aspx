<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendanceReport.aspx.cs" Inherits="AttendanceReport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance Report</title>
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }
        .form-container {
            background-color: white;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            max-width: 700px;
            margin: auto;
        }
        .form-input {
            margin-bottom: 15px;
        }
        .form-label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        .form-input input, .form-input select {
            width: 100%; /* Makes the input fields full-width */
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            transition: border-color 0.3s ease; /* Smooth transition */
        }
        .form-input input:focus, .form-input select:focus {
            border-color: #007BFF; /* Change border color on focus */
            outline: none; /* Remove default outline */
        }
        .form-input input::placeholder {
            color: #aaa; /* Placeholder text color */
        }
        .btn {
            background-color: #007BFF;
            color: white;
            border: none;
            padding: 10px 15px;
            cursor: pointer;
            border-radius: 4px; /* Rounded corners */
            transition: background-color 0.3s ease; /* Smooth transition */
        }
        .btn:hover {
            background-color: #0056b3; /* Darker shade on hover */
        }
        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        .grid-view th {
            background-color: #007BFF;
            color: white;
        }
        .grid-view tr:hover {
            background-color: #f1f1f1; /* Highlight row on hover */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <div class="form-input">
                <label class="form-label" for="drpStudent">Select Student:</label>
                <asp:DropDownList ID="drpStudent" runat="server" style="width: 100%;">
                </asp:DropDownList>
            </div>
            <div class="form-input">
                <label class="form-label" for="txtStartDate">Start Date:</label>
                <asp:TextBox ID="txtStartDate" runat="server" placeholder="Start Date"></asp:TextBox>
            </div>
            <div class="form-input">
                <label class="form-label" for="txtEndDate">End Date:</label>
                <asp:TextBox ID="txtEndDate" runat="server" placeholder="End Date"></asp:TextBox>
            </div>
            <div class="form-input">
                <asp:Button ID="btnFetchAttendance" runat="server" Text="Fetch Attendance" OnClick="btnFetchAttendance_Click" CssClass="btn" />
            </div>
            <asp:GridView ID="GridView1" runat="server" CssClass="grid-view"></asp:GridView>
        </div>
                      <center><asp:Button ID="Button2" runat="server" CssClass="btn" Text="Back" 
PostBackUrl="~/Staff/AdvanceAttReport.aspx" /></center>
    </form>
</body>
</html>
