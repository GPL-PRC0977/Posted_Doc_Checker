<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="PD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="card text-white bg-info mb-3" style="max-width: 25rem;margin: auto;">
  <div class="card-header">Posted Document Login</div>
  <div class="card-body" style="background-color: white;">
      <div class="alert alert-dismissible alert-primary" style="font-size: 12px;">
  Please use your Barter username/password to login.
</div>
      <table border="0" style="width: 100%; color: black;">
          <tr>
              <td>Username:</td><td><asp:TextBox runat="server" ID="txt_uname" CssClass="form-control"></asp:TextBox></td>
          </tr>
          <tr>
              <td>Password:</td><td><asp:TextBox runat="server" ID="txt_pwd" CssClass="form-control" TextMode="Password"></asp:TextBox></td>
          </tr>
          <tr>
              <td colspan="2"><asp:Label runat="server" id="lbl_err" class="float-left mt-10" ForeColor="Red" Visible="false"></asp:Label><asp:Button runat="server" CssClass="btn btn btn-info float-right mt-3" Text="Login" id="btn_login"/></td>
          </tr>
      </table>
  </div>
</div>
</asp:Content>
