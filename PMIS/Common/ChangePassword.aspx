<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="RCDPMISNEW_Common_ChangePassword" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <div class="containers" style="border: 1px inset #78bb2e; padding-top:10px;">
               <%--<div class="row">
                       <asp:Panel ID="pnlChngePwd" runat="server" Width="100%">
                              <div class="col-md-4"></div>
                              <div class="col-md-4">
                                      <h3 style="text-align:center; text-decoration:underline; font-weight: bold">Change Password</h3>
                            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                              </div>
                              <div class="col-md-4"></div>
                       
                    </asp:Panel>

               </div>--%>
               <br />

               <div class="panel panel-primary" style="width:60%; margin-left:20%">
                   <div class="panel-heading">Change Password</div>
                   <div class="panel-body">
                         <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                        <div class="row">
                    <div class="col-md-4"></div>
                   <div class="col-md-4 form-group">
                         <label> Old Password* :</label>
                        <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password" class="form-control" MaxLength="13" TabIndex="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Old Password!"
                                        ControlToValidate="txtOldPwd" ForeColor="#990099" ValidationGroup="s">*</asp:RequiredFieldValidator>
                   </div>
                     <div class="col-md-4"></div>
                     </div>
               <div class="row">
                     <div class="col-md-4"></div>
                   <div class="col-md-4 form-group">
                        <label> New Password* :</label>
                          <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" class="form-control" MaxLength="20" TabIndex="2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPwd"
                                        ErrorMessage="Enter New Password !" ForeColor="#990099" ValidationGroup="s">*</asp:RequiredFieldValidator>
                   </div>
                     <div class="col-md-4"></div>
                     </div>
               <div class="row">
                     <div class="col-md-4"></div>
                   <div class="col-md-4 form-group">
                         <label> Confirm Password* :</label>
                       <asp:TextBox ID="txtRePwd" runat="server" TextMode="Password" class="form-control" MaxLength="20" TabIndex="3"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPwd"
                                        ControlToValidate="txtRePwd" ForeColor="#990099" ErrorMessage="New and RePassword does not match !"
                                        SetFocusOnError="True" ValidationGroup="s">*</asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter RePassword !"
                                        ControlToValidate="txtRePwd" ForeColor="#990099" ValidationGroup="s">*</asp:RequiredFieldValidator>
                   </div>
                     <div class="col-md-4"></div>
                     </div>
               <div class="row">
                      <div class="col-md-4"></div>
                     <div class="col-md-2 form-group">
                  <cc1:captchacontrol id="ccJoin" runat="server" captchabackgroundnoise="None" captchalength="4"
                                        captchaheight="35" captchawidth="110" captchalinenoise="None" captchamintimeout="5"
                                        captchamaxtimeout="240" fontcolor="#529E00" bordercolor="Black" borderstyle="Solid"
                                        borderwidth="1px" width="135px" backcolor="White" />
                   </div>
                   <div class="col-md-2 form-group">
                         <asp:TextBox ID="txtCaptha" runat="server" Width="135px" placeholder="Enter Captcha" class="form-control" TabIndex="4"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Code !"
                                        ControlToValidate="txtCaptha" ForeColor="#990099" ValidationGroup="s">*</asp:RequiredFieldValidator>
                   </div>
                      <div class="col-md-4"></div>
                    </div>
               <div class="row">
                      <div class="col-md-4"></div>
                   <div class="col-md-4 form-group">

                       <asp:Button ID="btnSubmit" runat="server" class="btn btn-danger" OnClick="btnSubmit_Click" Text="Change" Width="80px" ValidationGroup="s"
                                        TabIndex="5"/>
                                   

                       <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="s" />
                          <div class="col-md-4"></div>
                   </div>

                        

               </div>
                   </div>
                  

               </div>


              
            </div>   

</asp:Content>

