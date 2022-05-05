<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true"
    CodeFile="AddFinancialProject.aspx.cs" Inherits="PMIS_Common_Default" %>
    <%@ Register Assembly="RJS.Web.WebControl.PopCalendar" Namespace="RJS.Web.WebControl"
    TagPrefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid" style="padding-top: 12px;">
        <div class="panel-group">
            <div class="panel panel-default">
            <div class="panel-heading" style="text-align: center; font-weight: 700; color: blue;"><h4>Financial Progress</h4></div>
               <div class="panel-body">
                    <table width="100%">
                        <tr>
                            <td align="left" colspan="10">
                                <strong>Project Name/ No. :</strong>&nbsp;&nbsp;
                                <asp:Label ID="lblProject" runat="server" Text="" ForeColor="#800000"></asp:Label><asp:Label
                                    ID="iblProjNo" runat="server" Text="" ForeColor="#800000"></asp:Label>
                            </td>
                            <td align="right" colspan="10">
                                <asp:Label ID="lblsancroad" runat="server" Text="" Visible="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="panel-body">
                    <div class="row" style="padding-top: 10px;">
                        <div class="col-md-2 ">
                            <asp:Label ID="lblaaamount1" runat="server" Text="AA Amount(In Lacs):" Font-Bold="true"></asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="lblamount" runat="server"  Font-Bold="true"></asp:Label>
                        </div>

                        <div class="col-md-4 col-xs-12">
                        </div>
                        <div class="col-md-2" >
                            <asp:Label ID="lblagreement1" runat="server" Text="Agreement Amount(In Lacs):" Font-Bold="true"></asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="lblagreement" runat="server"  Font-Bold="true"></asp:Label>
                        </div>

                    </div>
                    <div class="row" style="padding-top: 10px;">
                        <div class="col-md-2 col-xs-4">
                            <asp:Label ID="lblexpenditure1" runat="server" Text="Expenditure Till Date:" Font-Bold="true"></asp:Label>
                        </div>
                        <div class="col-md-2 col-xs-4">
                            <asp:Label ID="lblexpenditure" runat="server"  Font-Bold="true"></asp:Label>
                        </div>
                         <div class="col-md-4 col-xs-12">
                        </div>
                    <div class="col-md-2 col-xs-4">
                            <asp:Label ID="lbllast1" runat="server" Text="Last Update Date:" Font-Bold="true"></asp:Label>
                        </div>
                        <div class="col-md-2 col-xs-4">
                            <asp:Label ID="lbllast" runat="server"  Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                    <%--<div class="row" style="padding-top: 10px;">
                        <div class="col-md-4 col-xs-4">
                            <asp:Label ID="lbllast" runat="server" Text="Last Update Date:" Font-Bold="true"></asp:Label>
                        </div>
                    </div>--%>
                </div>
                <div class="panel-body">
                    <div class="row" style="padding-top: 10px;">
                        <div class="col-md-2 col-xs-4">
                            <label>
                                Year:</label>
                        </div>
                        <div class="col-md-2 col-xs-4">
                            <asp:DropDownList ID="ddl_year" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2 col-xs-12">
                            <label>
                                Month:</label>
                        </div>
                        <div class="col-md-2 col-xs-12">
                            <asp:DropDownList ID="ddl_month" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                       <%-- <div class="col-md-2 col-xs-12">
                            <label>
                                Date:</label>
                        </div>
                        <div class="col-md-2  col-xs-12">
                            <asp:TextBox ID="txt_date" runat="server" TextMode="date" CssClass="form-control"></asp:TextBox>
                        </div>
--%>                        
                       <div class="col-md-1">
                          <label> Bill Date:</label>
                      </div>
                        <div class="col-md-2">
                          <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" AutoCompleteType="Disabled" ></asp:TextBox>
                           
                            </div>
                      <div class="col-md-1">
                           <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="txt_date" Format="dd mmm yyyy" />
                      </div>
            
                
                    </div>
                    <div class="row" style="padding-top: 10px;">
                        <div class="col-md-2 col-xs-12">
                            <asp:Label ID="lbl_expenditure" runat="server" Text="Expenditure Amount(In Lacs):<br />(In above selected month)" ></asp:Label>
                        </div>
                        <div class="col-md-2 col-xs-12">
                            <asp:TextBox ID="txt_expenditure" runat="server" CssClass="form-control"  onkeypress="return validate(event)"
                                        onfocus="if(this.value=='0'){this.value=''}" onblur="if(this.value==''){this.value='0'}"
                                        Text="0"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 10px;">
                        <div class="col-md-2 col-xs-12">
                            <asp:Label ID="lbl_Measuring" runat="server" Text="Measuring Book No.:"></asp:Label>
                        </div>
                        <div class="col-md-2 col-xs-12">
                            <asp:TextBox ID="txt_Measuring" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 10px; padding-bottom: 10px;">
                        <div class="col-md-5 col-xs-6">
                        </div>
                        <div class="col-md-6 col-xs-6">
                            <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" CssClass="btn btn-primary "
                                Width="80px" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="80px" CssClass="btn btn-danger"
                                OnClientClick="return confirm('Are you sure to delete Project Details?');" Visible="false" />
                            <asp:Button ID="btn_reset" runat="server" Width="80px" Text="Back" OnClick="btn_Reset_Click" CssClass="btn btn-danger " />
                        </div>
                    </div>
                </div>
            </div>
            <%--  <h3 style="text-align:center; font-family:Arial; font-weight:600; color:blue;">Add Project
       
           
     </h3>
        <hr style="border:1px solid grey" />--%>
        </div>
        </div>
</asp:Content>
