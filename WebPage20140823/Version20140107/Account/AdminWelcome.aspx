<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminWelcome.aspx.cs" Inherits="Version20140107.Account.AdminWellcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSSFile/Login.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <h1 class="auto-style1">Welcome to Smart Attendance Management System</h1>
        </div>

        <strong>Welcome:<%=Session["UserName"]%></strong>

        
        <div>
            <a href="EnrollStaff.aspx">
                <strong>
                <asp:Label ID="Label2" Text='Enroll Staff' runat="server"/>
            </strong>
            </a>
        </div>
        <div>
            <a href="EnrollStudent.aspx">
                <strong>
                <asp:Label ID="Label1" Text='Enroll Student' runat="server"/>
            </strong>
            </a>
        </div>

        <div>
            <a href="SetClass.aspx">
                <strong>
                <asp:Label ID="Label5" Text="Set Class for Lecturer" runat="server"/>
            </strong>
            </a>
        </div>

        <div>
            <a href="MonteCarloSimulation.aspx">
                <strong>
                <asp:Label ID="Label6" Text='Monte Carlo Simulation' runat="server"/>
            </strong>
            </a>
        </div>

        <div>
            <a href="ChangePassword.aspx">
                <strong>
                <asp:Label ID="Label4" Text='Change Password' runat="server"/>
            </strong>
            </a>
        </div>

        <div>
            <asp:Button ID="logout" runat="server" Text="Log Out" OnClick="logout_Click" style="font-weight: 700" />
        </div>

    </div>
    </form>
</body>
</html>
