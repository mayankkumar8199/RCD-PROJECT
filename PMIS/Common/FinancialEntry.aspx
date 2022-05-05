<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true"
    CodeFile="FinancialEntry.aspx.cs" Inherits="PMIS_Common_FinancialEntry" %>
     <%@ Register Assembly="RJS.Web.WebControl.PopCalendar" Namespace="RJS.Web.WebControl"
    TagPrefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        
        
        .loading
        {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
        
        .grid-sltrow
        {
            background: #ddd;
            font-weight: bold;
        }
        
        .SubTotalRowStyle
        {
            border: solid 1px Black;
            background-color: #D8D8D8;
            font-weight: bold;
        }
        
        .GrandTotalRowStyle
        {
            border: solid 1px Gray;
            background-color: #000000;
            color: #ffffff;
            font-weight: bold;
        }
        
        .GroupHeaderStyle
        {
            border: solid 1px Black;
            background-color: #4682B4;
            color: #ffffff;
            font-weight: bold;
        }
        
        .serh-grid
        {
            width: 85%;
            border: 1px solid #6AB5FF;
            background: #fff;
            line-height: 14px;
            font-size: 11px;
            font-family: Verdana;
        }
        
        
        .dropdown-icon
        {
            color: red;
        }
        
        .table table tbody tr td a, .table table tbody tr td span
        {
            position: relative;
            float: left;
            padding: 6px 12px;
            margin-left: -1px;
            line-height: 1.42857143;
            color: #337ab7;
            text-decoration: none;
            background-color: #fff;
            border: 1px solid #ddd;
        }
        
        .table table > tbody > tr > td > span
        {
            z-index: 3;
            color: #fff;
            cursor: default;
            background-color: #337ab7;
            border-color: #337ab7;
        }
        
        .table table > tbody > tr > td:first-child > a, .table table > tbody > tr > td:first-child > span
        {
            margin-left: 0;
            border-top-left-radius: 4px;
            border-bottom-left-radius: 4px;
        }
        
        .table table > tbody > tr > td:last-child > a, .table table > tbody > tr > td:last-child > span
        {
            border-top-right-radius: 4px;
            border-bottom-right-radius: 4px;
        }
        
        
        
        
        .table table > tbody > tr > td > a:hover, .table table > tbody > tr > td > span:hover, .table table > tbody > tr > td > a:focus, .table table > tbody > tr > td > span:focus
        {
            z-index: 2;
            color: #23527c;
            background-color: #eee;
            border-color: #ddd;
        }
        
        fieldset
        {
            border: 1px solid #0f2c62;
            border-radius: 3px;
            padding: 10px;
            background-color: White;
        }
        
        legend
        {
            background-color: #014e9c;
            color: #fff;
            padding: 3px 6px;
            font-weight: 100;
            text-align: center;
        }
        
        .grid th
        {
            background-color: #3393ff;
            color: White;
            border-collapse: collapse;
            padding: 10px;
            border-color: Black;
        }
        
        .grid tr
        {
            background-color: White;
            color: Black;
            border-collapse: collapse;
            padding: 10px;
        }
        
        .grid td
        {
            text-align: center;
        }
        
        .grid th:first-child
        {
            background-color: #3393ff;
            -moz-border-radius-topleft: 14px;
            -webkit-border-top-left-radius: 14px;
            border-top-left-radius: 14px;
            border-collapse: collapse;
            cellpadding: 0px;
            cellspacing: 0px;
        }
        
        .grid th:last-child
        {
            background-color: #3393ff;
            -moz-border-radius-topright: 14px;
            -webkit-border-top-right-radius: 14px;
            border-top-right-radius: 14px;
        }
        
        .grid tr:hover
        {
            background-color: #EEE5CE;
        }
        
        .grid tr:nth-child(even)
        {
            background-color: #f2f2f2;
        }
        
        .grid tr:hover
        {
            background-color: #ddd;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="container-fluid" style="padding-top: 12px;">
        <div class="panel-group">
     <div class="panel panel-default">
         <div class="panel-heading" style="text-align: center; font-weight: 700; color: blue;"><h4>Financial Progress</h4></div><br />
        <div class="panel-heading" style="font-weight: bold; text-align: center">
            <div class="row" style="padding-top: 10px;">
                <div class="col-md-1">
                    <p style="font-size:12px">Search By Date:</p>
                       
                </div>
                <div class="col-md-1">
                          <label> From</label>
                      </div>
                        <div class="col-md-2">
                          <asp:TextBox ID="txtfromdate" runat="server" CssClass="form-control" AutoCompleteType="Disabled" ></asp:TextBox>
                           
                            </div>
                      <div class="col-md-1"  style="text-align:left">
                           <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="txtfromdate" Format="dd mmm yyyy" />
                      </div>
                
                <div class="col-md-1">
                          <label> To</label>
                      </div>
                        <div class="col-md-2">
                          <asp:TextBox ID="txttodate" runat="server" CssClass="form-control" AutoCompleteType="Disabled" ></asp:TextBox>
                           
                            </div>
                      <div class="col-md-1" style="text-align:left">
                           <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txttodate" Format="dd mmm yyyy" />
                      </div>
                <div class="col-md-1">
                    <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_click" />
                </div>
                <div class="col-md-2  col-xs-12">
                    <asp:Button ID="btn_Project_Entry" runat="server" Text="Add Expenditure" OnClick="btn_Project_Entry_Click"/>
                    <%--<a href='AddFinancialProject.aspx?TargetID=<%#Eval("TargetID")%>&ProjectNo=<%#Eval("Projectno")%>'
                        target="_blank">View</a><br />--%>
                </div>
               </div>
        </div>
        <br />
        <div class="panel-heading" style="font-weight: bold; text-align: center; color: blue;">
            <%--<h4>
                Expenditure Of(Project Name)</h4>--%>
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
            <asp:Panel ID="pnl_main_search" runat="server">
                <asp:GridView ID="grdfinancial" CssClass="table table-striped table-bordered table text-center"
                    runat="server" Width="100%" AutoGenerateColumns="false" ShowFooter="true" ShowHeaderWhenEmpty="True"
                    EmptyDataText="No records Found..." EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-ForeColor="#990000"
                    DataKeyNames="" AllowPaging="true" OnRowCommand="GridView1_RowCommand" PageSize="10">
                    <Columns>
                        <asp:TemplateField HeaderText="Sl. No." HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"
                            HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                            HeaderStyle-Width="1%">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Year" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"
                            HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                            HeaderStyle-Width="1%">
                            <ItemTemplate>
                                <label style="font-weight: 400; color: maroon;">
                                </label>
                                <asp:Label ID="lblyear" runat="server" Text='<%# Eval("FY") %>'></asp:Label><br />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Months" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"
                            HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black" HeaderStyle-Width="1%">
                            <ItemTemplate>
                                <asp:Label ID="lblmonth" runat="server" Text='<%# Eval("Months") %>'></asp:Label><br />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bill Date" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"
                            HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black" HeaderStyle-Width="1%">
                            <ItemTemplate>
                                <asp:Label ID="lbldate" runat="server" Text='<%# Eval("Entrydate", "{0:MM/dd/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Expenditure (In Lakh)" HeaderStyle-BackColor="#008abc"
                            HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                            HeaderStyle-Width="1%">
                            <ItemTemplate>
                                <asp:Label ID="lblrs" runat="server" Text='<%# Eval("Expenditureamount") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Action" HeaderStyle-BackColor="#008abc"
                            HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                            HeaderStyle-Width="1%">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnk_view" runat="server" CommandName="View" Font-Bold="true"
                                    ToolTip="Click Here To View" CommandArgument='<%#Eval("slno")%>'>
                                        <i class="fa fa-eye" aria-hidden="true"  style="color:cornflowerblue"></i>
                                </asp:LinkButton>&nbsp;&nbsp;
                                <asp:LinkButton ID="lnk_update" runat="server" ToolTip="Click Here To Update" CommandName="Modify"
                                    Font-Bold="true" CommandArgument='<%#Eval("slno")%>'>
                                          <i class="fa fa-pencil-square-o" aria-hidden="true" style="color:darkgreen"></i>
                                </asp:LinkButton>&nbsp;&nbsp;
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                    <FooterStyle BackColor="#CCCCCC"   HorizontalAlign="Left" />
                    <HeaderStyle BackColor="white" Font-Bold="True" ForeColor="black" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                 <div class="row">
                <div class="col-md-12">
                 <div class="col-md-4"></div>
                    <div class="col-md-4">
                         <asp:Button ID="btn_reset" runat="server" Width="80px" Text="Back"  CssClass="btn btn-danger" OnClick="btn_reset_Click"/>
                    </div>
                    <div class="col-md-4"></div>
                </div>
                </div>

            </asp:Panel>
        </div>
        </div>
        </div>
        </div>
</asp:Content>
