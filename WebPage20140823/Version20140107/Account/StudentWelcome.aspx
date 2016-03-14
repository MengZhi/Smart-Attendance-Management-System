<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentWelcome.aspx.cs" Inherits="Version20140107.Account.StudentWellcome" %>

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
            
            <div>
                <a href="Login.aspx">
                    <strong>
                    <asp:Label ID="logoutLink" Text='Logout' runat="server" />
                </strong>
                </a>
            </div>
            <div>
                <strong>Welcome: <%=Session["UserName"]%>
                </strong>
            </div>

            <div>
                <strong>Student Name:
        <asp:Label ID="StudentName" runat="server"></asp:Label>
                </strong>
            </div>

            <div>
                <strong>Matric Number:
        <asp:Label ID="MatricNumber" runat="server"></asp:Label>
                </strong>
            </div>
            

            <div>
                <a href="StudentAttendanceShowingCourse.aspx">
                    <strong>
                    <asp:Label ID="Label2" Text='View my attendance' runat="server" />
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
                <asp:Button ID="logout" runat="server" Text="Log Out" OnClick="logout_Click" style="font-weight: 700" />
                </strong>
            </div>


        </div>

    </form>
</body>
</html>
