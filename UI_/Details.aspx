<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="UI_.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified" style="width:1000px">
        <tr>
            <td class="modal-sm" style="width: 169px">ID</td>
            <td style="width: 237px">
                <asp:TextBox ID="tb_id" runat="server" Width="378px"></asp:TextBox>
            </td>
              <td style="width: 762px" class="modal-sm">
                  &nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 169px; height: 20px">First Name</td>
            <td style="height: 20px; width: 237px">
                <asp:TextBox ID="tb_fn" runat="server" Width="378px"></asp:TextBox>
            </td>
            <td style="width:25px"></td>
              <td style="width: 762px" class="modal-sm" \>
                  <asp:Button ID="Button_update" runat="server" Text="Update" OnClick="Button_update_Click1"  />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 169px">Last Name</td>
            <td style="width: 237px">
                <asp:TextBox ID="tb_ln" runat="server" Width="378px"></asp:TextBox>
            </td>
              <td style="width: 762px" class="modal-sm">
                  &nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 169px">Date Of Birth</td>
            <td style="width: 237px">
                <asp:TextBox ID="tb_dob" runat="server" Width="378px"></asp:TextBox>
            </td>
            <td style="width:25px"></td>
              <td style="width: 762px" class="modal-sm">
                  <asp:Button ID="Button_Insert" runat="server" Text="Insert" Width="64px" OnClick="Button_Insert_Click" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 169px">Address</td>
            <td style="width: 237px">
                <asp:TextBox ID="tb_ad" runat="server" Width="378px"></asp:TextBox>
            </td>
              <td style="width: 762px" class="modal-sm">
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 169px">Phone Number</td>
            <td style="width: 237px">
                <asp:TextBox ID="tb_pn" runat="server" Width="378px"></asp:TextBox>
            </td>
              <td style="width: 762px" class="modal-sm">
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 169px">Cell Phone Number</td>
            <td style="width: 237px">
                <asp:TextBox ID="tb_cell_pn" runat="server" Width="378px"></asp:TextBox>
            </td>
              <td class="modal-sm" style="width: 762px"></td>
            <td style="width: 237px">
                <asp:Button ID="btn_vac" runat="server" OnClick="btn_vac_Click" Text="Add Vaccine" />
&nbsp;      <asp:Button ID="btn_ill" runat="server" OnClick="btn_ill_Click" Text="Add Illness" />
            </td>
            <td>
                <asp:Label ID="lbl_ill" runat="server" Text="begin Illness"></asp:Label>
                <asp:Label ID="lbl_rec" runat="server" Text="Recovery"></asp:Label>
                <asp:Label ID="lbl_man" runat="server" Text="Manufacterer"></asp:Label>
                <asp:Label ID="labl_date" runat="server" Text="Date of vaccine"></asp:Label>
            </td>
            <td>
               <asp:TextBox runat="server" ID="tb_ill"></asp:TextBox>
               <asp:TextBox runat="server" ID="tb_reco"></asp:TextBox>
               <asp:TextBox runat="server" ID="tb_man"></asp:TextBox>
               <asp:TextBox runat="server" ID="tb_dt"></asp:TextBox>
            </td>

        </tr>
        
    </table>
    <table>
        <tr>
          <td>
              <asp:Gridview runat="server"  Width="500px" AutoGenerateColumns="true" ID="gv_Vaccines">
         </asp:Gridview></td>
             <td Style="width:10px"></td>
        <td style="width: 500px"><asp:Gridview runat="server"  Width="500px" AutoGenerateColumns="true" ID="gv_Covid_His" >
         </asp:Gridview></td>
        </tr>
   </table>
</asp:Content>
