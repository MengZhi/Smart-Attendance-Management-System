<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="Version20140107.Account.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">

        function checkResult() {
            //var x;
            var r = confirm("Your Password has been changed and send an Email to your mail box!");
            //if (r == true) {
            //sendMail();
            //}

            //document.getElementById("demo").innerHTML = x;
        }

    </script>

</head>
<body>

    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <div id="staffmatricnumber">Staff No./Matric No.:</div>
            <asp:TextBox ID="tbstaffmatricnumber" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                ForeColor="Red"
                ControlToValidate="tbstaffmatricnumber"
                ValidationGroup="PersonalInfoGroup"
                runat="Server">*
            </asp:RequiredFieldValidator>

            <div id="email">E-mail Address:</div>
            <asp:TextBox ID="tbemail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                ForeColor="Red"
                ControlToValidate="tbemail"
                ValidationGroup="PersonalInfoGroup"
                runat="Server">*
            </asp:RequiredFieldValidator>

            <div>
                <asp:Button ID="submit" runat="server" Text="Submit" ValidationGroup="PersonalInfoGroup" CausesValidation="true" OnClick="submit_Click" />
            </div>

            <div>
                <asp:Button ID="finish" runat="server" Text="Finish" OnClick="finish_Click" />
            </div>


        </div>
    </form>
</body>
</html>
