<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="posteddoc.aspx.vb" Inherits="PD.posteddoc" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card text-white bg-info mb-3" style="width: 100%; margin: auto;">
        <div class="card-header">
            <table border="0" class="float-left">
                <tr>
                    <td>Document No:</td>
                    <td><asp:TextBox runat="server" ID="txt_search" CssClass="form-control-sm" Width="300"></asp:TextBox></td>
                    <td>
                        <asp:Button runat="server" CssClass="btn btn-info float-right btn-sm" Text="Search" id="btn_search"/>
                    </td>
                </tr>
            </table>

              <asp:Button runat="server" CssClass="btn btn-info float-right btn-sm" Text="Logout" id="btn_logout"/>
        </div>
        <div class="card-body" style="background-color: white;">
                  <div class="alert alert-dismissible alert-primary"><asp:Label runat="server" CssClass="lbl_message " ID="lbl_message">Start Searching..</asp:Label></div>
            <asp:GridView runat="server" ID="gv" CssClass="gv_css table-hover" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Source No:" DataField="Source No_" />
                    <asp:BoundField HeaderText="Location Code" DataField="Location Code" />
                    <asp:BoundField HeaderText="Destination No" DataField="Destination No_" />
                    <asp:BoundField HeaderText="Shipment Date" DataField="Shipment Date" />
                    <asp:BoundField HeaderText="Posting Date" DataField="Posting Date" />
                    <asp:BoundField HeaderText="Warehouse Shipment No" DataField="Whse_ Shipment No_" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
