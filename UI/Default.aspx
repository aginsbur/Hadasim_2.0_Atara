<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="UI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div style="font-size: x-large" align="center">Covid User Information Center</div>
        <table class="nav-justified">
            <tr>
                <td style="width: 165px">User Id</td>
                <td style="width: 652px">
                    <asp:TextBox ID="TextBox1" runat="server" Font-Size="Medium"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 165px">First Name</td>
                <td style="width: 652px">
                    <asp:TextBox ID="TextBox2" runat="server" Font-Size="Medium"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 165px">Last Name</td>
                <td style="width: 652px">
                    <asp:TextBox ID="TextBox3" runat="server" Font-Size="Medium"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 165px">Date Of Birth</td>
                <td style="width: 652px">
                    <asp:TextBox ID="TextBox4" runat="server" Font-Size="Medium"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 165px">Address</td>
                <td style="width: 652px">
                    <asp:TextBox ID="TextBox5" runat="server" Font-Size="Medium"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 165px">Phone Number</td>
                <td style="width: 652px">
                    <asp:TextBox ID="TextBox6" runat="server" Font-Size="Medium"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 165px">Cell Phone Number</td>
                <td style="width: 652px">
                    <asp:TextBox ID="TextBox7" runat="server" Font-Size="Medium"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 165px">&nbsp;</td>
                <td style="width: 652px">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 165px">&nbsp;</td>
                <td style="width: 652px">
                    <asp:Button ID="Button1" runat="server" BackColor="Lime" Font-Size="Small" Text="Insert" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 165px">&nbsp;</td>
                <td style="width: 652px">
                    <asp:GridView ID="GridView1" runat="server" Height="318px" style="margin-top: 36px" Width="914px">
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
            </table>
    </div>
</asp:Content>
