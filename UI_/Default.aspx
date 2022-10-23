<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI_._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
    <div>
        <div style="font-size: Medium; color: #000000; font-family: Arial, Helvetica, sans-serif; position: relative; background-color: #FFFFFF; width: 1300px; left: 1px; top: 0px; height: 22px;"> Users<br />
        </div>
    </div>

    <div style="width: 1294px; height:351px;  overflow-y:auto; overflow-x:auto;  background-color: #FFFFFF;">
         <asp:GridView ID="GridView1" runat="server" style="scrollbar-highlight-color:ActiveBorder; overflow-x:scroll;overflow-y:scroll; margin-right: 50px;" AutoGenerateColumns="false"
              OnRowDeleting="Delete"  OnSelectedIndexChanging="Select" Font-Names="Arial" Width="1200px" Height="270px">
                        <PagerStyle BorderStyle="None" />
                        <SelectedRowStyle BackColor="#0099FF" />
                       <HeaderStyle BorderStyle="Solid" Font-Size="Small" BorderWidth="3px" Font-Bold="true"/>
                       
         <Columns>
           
            <asp:BoundField DataField="ID" HeaderText="ID" 
            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
            InsertVisible="False" ReadOnly="True" NullDisplayText="&quot;&quot;">
            <HeaderStyle HorizontalAlign="Left" Height="30px" Width="80px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Left" Width="80px" Font-Size="Small" Font-Bold="true"></ItemStyle> </asp:BoundField>

             <asp:BoundField DataField="First_Name" HeaderText="First Name"
             ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
             <HeaderStyle HorizontalAlign="Left" Height="30px" Width="100px" ></HeaderStyle>
             <ItemStyle HorizontalAlign="Left" Width="100px" Font-Size="Small"></ItemStyle>
             </asp:BoundField>

             <asp:BoundField DataField="Last_Name" HeaderText="Last Name"
             ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
             <HeaderStyle HorizontalAlign="Left" Height="30px" Width="100px"></HeaderStyle>
             <ItemStyle HorizontalAlign="Left" Width="100px" Font-Size="Small"></ItemStyle></asp:BoundField>

             <asp:BoundField DataField="Date_Of_Birth" HeaderText="Date Of Birth"
             ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
             <HeaderStyle HorizontalAlign="Left" Height="30px" Width="100px"></HeaderStyle>
             <ItemStyle HorizontalAlign="Left" Width="100px" Font-Size="Small"></ItemStyle></asp:BoundField>

             <asp:BoundField DataField="Address" HeaderText="Address"
             ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
             <HeaderStyle HorizontalAlign="Left" Width="100px" Height="30px" ></HeaderStyle>
             <ItemStyle HorizontalAlign="Left" Width="100px" Font-Size="Small"></ItemStyle></asp:BoundField>

             <asp:BoundField DataField="Phone_Number" HeaderText="Phone Number"
             ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
             <HeaderStyle HorizontalAlign="Left" Height="30px" Width="80px"></HeaderStyle>
             <ItemStyle HorizontalAlign="Left" Width="80px" Font-Size="Small"></ItemStyle></asp:BoundField>

             <asp:BoundField DataField="Cell_Phone_Number" HeaderText="Cell Phone Number"
             ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
             <HeaderStyle HorizontalAlign="Left" Height="30px" Width="90px"></HeaderStyle>
             <ItemStyle HorizontalAlign="Left" Width="90px" Font-Size="Small"></ItemStyle></asp:BoundField>
             
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ButtonType="Button" ControlStyle-BackColor="LightBlue" ControlStyle-BorderStyle="None">
            <HeaderStyle HorizontalAlign="Center" Height="30px" ></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" Width="80px" BackColor="LightBlue"></ItemStyle>
            </asp:CommandField>

            <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" ControlStyle-BackColor="LightBlue" ControlStyle-BorderStyle="None" >  
            <HeaderStyle HorizontalAlign="Center" Height="30px" ></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" Width="80px" BackColor="LightBlue"></ItemStyle>
            </asp:CommandField>

            </Columns>
          </asp:GridView>
       </div>
    <div>
        <asp:Button runat="server" BackColor="LightBlue" Text="Add" ID="btn_add" OnClick="btn_add_Click" Width="103px" />
    </div>
    
    
</asp:Content>
