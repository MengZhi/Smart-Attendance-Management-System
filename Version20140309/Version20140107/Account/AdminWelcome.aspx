<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminWelcome.aspx.cs" Inherits="Version20140107.Account.AdminWellcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <h1>Welcome to Attendence System</h1>
        </div>

        Welcome:<%=Session["UserName"]%>

        <div>
            <a href="EnrollStudent.aspx">
                <asp:Label ID="Label1" Text='Enroll Student' runat="server"/>
            </a>
        </div>
        <div>
            <a href="EnrollStaff.aspx">
                <asp:Label ID="Label2" Text='Enroll Staff' runat="server"/>
            </a>
        </div>
        <div>
            <a href="FacilityUsage.aspx">
                <asp:Label ID="Label3" Text='View the Facilities Usage' runat="server"/>
            </a>
        </div>

        <div>
            <a href="SetClass.aspx">
                <asp:Label ID="Label5" Text="Set Class for Lecturer" runat="server"/>
            </a>
        </div>

        <div>
            <a href="ChangePassword.aspx">
                <asp:Label ID="Label4" Text='Change Password' runat="server"/>
            </a>
        </div>

        <div>
            <asp:Button ID="logout" runat="server" Text="Log Out" OnClick="logout_Click" />
        </div>

    </div>
    </form>
</body>
</html>
