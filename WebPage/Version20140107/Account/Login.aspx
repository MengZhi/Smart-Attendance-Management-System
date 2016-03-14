<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Version20140107.Account.Login" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="../CSSFile/base.css" rel="stylesheet" type="text/css" />
    <link href="../CSSFile/templatemo_style.css" rel="stylesheet" type="text/css" />
    <link href="../CSSFile/skeleton.css" rel="stylesheet" type="text/css" />--%>
    <link href="../CSSFile/Login.css" rel="stylesheet" type="text/css" />
    <%--<style type="text/css">
        .auto-style2 {
            font-size: large;
            font-weight: normal;
        }
        .auto-style3 {
            font-weight: normal;
        }
        .auto-style4 {
            font-size: medium;
        }
        .auto-style5 {
            font-weight: bold;
        }
    </style>--%>
</head>
<body>

    <form id="form1" runat="server">
        <div class="container">
            <div class="login">
                <div>
                    <h1 class="auto-style2"><span class="auto-style3"><strong>Welcome to RFID-enabled Smart Attendance </strong></span><strong>System</strong></h1>
                </div>

                <div>
                    <strong><span class="auto-style4">User Name:</span></strong> 

                    <asp:TextBox ID="TextBox1" runat="server" Width="174px" CssClass="auto-style5"></asp:TextBox>
                    
                </div>

                <div>
                    <span class="auto-style4"><strong>
                    <br />
                    password:&nbsp;&nbsp; </strong></span> 
                    <asp:TextBox ID="TextBox2" TextMode="password" runat="server" CssClass="auto-style5" Width="174px"></asp:TextBox>
                    <asp:Label ID="WrongPassword" runat="server" style="font-size: medium; font-weight: 700" />
                </div>

                <div>
                    <br />
                    <span class="auto-style4"><strong>User Type: 
                    </strong></span> 
                    <asp:DropDownList ID="UserType" runat="server">
                        <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                        <asp:ListItem Text="Lecturer" Value="Lecturer"></asp:ListItem>
                        <asp:ListItem Text="Administrator" Value="Administrator"></asp:ListItem>
                    </asp:DropDownList>

                    <br />

                </div>

                <div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" CssClass="submit" runat="server" OnClick="Button1_Click1" Text="Login" />

                </div>
                <div class="login-help">
                    <a href="ForgetPassword.aspx">
                        <asp:Label ID="Label1" Text='Forget Password?' runat="server" />
                    </a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
