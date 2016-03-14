<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatNewUser.aspx.cs" Inherits="Version20140107.Account.CreatNewuser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3>Create New User</h3>
    <form id="form1" runat="server">
        <div>
            <div id="email">E-mail Address:</div>
                <input type="text"/>
            <div>Staff No./Student No.:</div>
                <input type="text"/>
            <div>User Type:</div>
                <select name="select">
                   <option value="2">Student</option>
                   <option value="3">Lecture</option>
                </select>
            <div>Password:</div>
                <input type="password"/>
            <div id="conform">Retype your password:</div>
                <input type="password"/>
            <div id="submit">
                <input type="submit" tabindex="5" value="Submit"/>
                <input type="button" tabindex="5" value="Reset"/>
                <input type="button" tabindex="5" value="Cancle"/>
            </div>
        </div>
    </form>
</body>
</html>