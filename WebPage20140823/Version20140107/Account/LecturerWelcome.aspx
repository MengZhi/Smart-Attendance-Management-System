<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LecturerWelcome.aspx.cs" Inherits="Version20140107.Account.LecturerWelcome" %>

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
                <strong>Staff Name:
        <asp:Label ID="StaffName" runat="server"></asp:Label>
                </strong>
            </div>

            <div>
                <strong>Staff Number:
        <asp:Label ID="StaffNumber" runat="server"></asp:Label>
                </strong>
            </div>


            <div>
                <a href="LVAShowingCourse.aspx">
                    <strong>
                    <asp:Label ID="Label2" Text='View the Attendance' runat="server" />
                </strong>
                </a>
            </div>

            <div>
                <a href="ChangePassword.aspx">
                    <strong>
                    <asp:Label ID="Label4" Text='Change Password' runat="server" />
                </strong>
                </a>
            </div>

            <div>
                <strong>
                <asp:Button ID="logout" runat="server" Text="Log Out" OnClick="logout_Click" />
                </strong>
            </div>
        </div>
    </form>
</body>
</html>
