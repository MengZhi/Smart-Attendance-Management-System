<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Version20140107.Account.Login" %>

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
            <asp:label id="WrongPassword" runat="server"/> 
        </div>

        <div>
            <asp:label Text="password: " runat="server" />
            <asp:TextBox id="TextBox2" TextMode="password" runat="server" ></asp:TextBox>
        </div>
        
        <div>
            <asp:label Text="User Type: " runat="server" />
            <asp:DropDownList ID="UserType" runat="server" >
                <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                <asp:ListItem Text="Lecturer" Value="Lecturer"></asp:ListItem>
                <asp:ListItem Text="Administrator" Value="Administrator"></asp:ListItem>
        </asp:DropDownList>

        </div>

        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Login" />
        </div>
        
        <div>
            <a href="ForgetPassword.aspx">
                <asp:Label ID="Label1" Text='Forget Password?' runat="server"/>
            </a>  
        </div>

        

        
        


    </form>
</body>
</html>
