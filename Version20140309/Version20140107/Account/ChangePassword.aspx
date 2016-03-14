<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Version20140107.Account.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
            <div id="CurrentNo.">User Name: <%=Session["UserName"]%></div>

            <div>
                <asp:Label ID="message" runat="server"></asp:Label>
            </div>

        

        <div id="OldPassword">Old password:</div>
            <asp:TextBox ID="tbOldPassword" TextMode="password" runat="server"></asp:TextBox>
        <div id="NewPassword">New password:</div>
            <asp:TextBox ID="tbNewPassword" TextMode="password" runat="server"></asp:TextBox>
        <div id="NewPasswordConform">New password Conform:</div>
            <asp:TextBox ID="tbReenter" TextMode="password" runat="server"></asp:TextBox>
        <div id="submit">
            <asp:Button ID="passwordChange" Text="Submit" runat="server" OnClick="passwordChange_Click" />
            <asp:Button ID="cancle" Text="Cancle" runat="server" OnClick="cancle_Click" />
        </div>
    </div>
    </form>
</body>
</html>
