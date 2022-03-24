<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="TrainTicketReservation.UserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>provide the following details</h4>
            <table>
                <tr>
                    <td><asp:Label ID="NameLabel" runat="server" Text="Enter Your Name"></asp:Label></td>
                    <td><asp:TextBox ID="Name" runat="server" ToolTip="Enter Name"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="AgeLabel" runat="server" Text="Age"></asp:Label></td>
                    <td><asp:TextBox ID="Age" runat="server" ToolTip="Enter Age"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="MobLabel" runat="server" Text="MobNo"></asp:Label></td>
                    <td><asp:TextBox ID="MobNo" runat="server" ToolTip="Enter Indian MobilleNo"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Gender" runat="server" Text="Gender"></asp:Label></td>
                    <td><asp:RadioButton ID="MaleButton" runat="server" Text="Male" GroupName="Gender"/>
                    <asp:RadioButton ID="FemaleButton" runat="server" Text="Female" GroupName="Gender"/>
                        <asp:RadioButton ID="TransGenderButton" runat="server" Text="TransGender"  GroupName="Gender" />
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label></td>
                    <td><asp:TextBox ID="Email" runat="server" ToolTip="Enter Email like Name@domain.extension"></asp:TextBox></td>

                </tr>
                <tr>
                    <td><asp:Label ID="UsernameLabel" runat="server" Text="UserName"></asp:Label></td>
                    <td><asp:TextBox ID="UserName" runat="server" ToolTip="Enter UserName"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label></td>
                    <td><asp:TextBox ID="Password" runat="server" ToolTip="Enter password"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td><asp:Label ID="confirm" runat="server" Text="Password"></asp:Label></td>
                    <td><asp:TextBox ID="Confirmpassword" runat="server" ToolTip="Enter password"></asp:TextBox></td>
                </tr>
            </table>
        </div>
        <p>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit"  OnClick="SubmitButton_Click" style="width: 100px;background-color:lightsteelblue"/>
        </p>
    </form>
</body>
</html>
