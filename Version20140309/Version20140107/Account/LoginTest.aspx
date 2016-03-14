<%@ Page Language="C#" Trace="true" AutoEventWireup="true" CodeBehind="LoginTest.aspx.cs" Inherits="Version20140107.Account.Login2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <asp:label ID="CurrentTime" runat="server" ForeColor="#0099FF"/>
        </div>

        <div>
            <asp:label Text="User Name: " runat="server" />
            <asp:TextBox id="TextBox1" runat="server" ></asp:TextBox>
        </div>

        <div>
            <asp:label Text="password: " runat="server" />
            <asp:TextBox id="TextBox2" runat="server" ></asp:TextBox>
        </div>
        
        <div>
            <asp:Button ID="clickme" Text="Click Me!" runat="server" OnClick="clickme_Click" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
        </div>
    
        


    </form>
</body>
</html>
