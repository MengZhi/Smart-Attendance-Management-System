<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentWelcome.aspx.cs" Inherits="Version20140107.Account.StudentWellcome" %>

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

        <div>
             Welcome: <%=Session["UserName"]%>
        </div>
       

        <asp:Label ID="MatricNumber" runat="server"></asp:Label>

        <div>
            <a href="StudentAttInfo.aspx">
                <asp:Label ID="Label2" Text='View my attendance' runat="server"/>
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
