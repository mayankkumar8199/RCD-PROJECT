<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true"
    CodeFile="ProgressRptOngoing.aspx.cs" Inherits="PMIS_Common_ProgressRptOngoing"
    EnableEventValidation="false" %>

<%@ Register Assembly="RJS.Web.WebControl.PopCalendar" Namespace="RJS.Web.WebControl"
    TagPrefix="rjs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <div class="container-fluid" style="padding-top: 10px;">
        <div class="panel panel-primary">
            <div class="panel-heading" style="text-align: center; font-weight: 700; font-size: x-large">
                Ongoing Progress Report
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-8">
                    </div>
                </div>
                <div class="row" style="padding-bottom: 10px; padding-top: 9px;">
                    <div class="col-md-2 col-xs-12">
                        <label>
                            Select Financial Year:</label>
                        <asp:DropDownList ID="ddlFYear" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-xs-12">
                        <strong>Wings</strong><br />
                        <asp:DropDownList ID="ddlwings" AutoPostBack="true" OnSelectedIndexChanged="ddlwings_SelectedIndexChanged"
                            runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-xs-12">
                        <strong>Circle</strong><br />
                        <asp:DropDownList ID="ddlcircle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcircle_SelectedIndexChanged"
                            CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-xs-12">
                        <strong>Division</strong><br />
                        <asp:DropDownList ID="ddldivision" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-xs-12">
                        <strong>Road Type</strong><br />
                        <asp:DropDownList ID="ddl_roadtype" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-xs-12">
                        </br>
                        <asp:Button ID="Button1" runat="server" Text="Export To Excel" OnClick="btn_export_to_excelClick"
                            CssClass="btn btn-primary" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-xs-12">
                        <strong>Head</strong><br />
                        <asp:DropDownList ID="ddlhead" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-xs-12">
                        <strong>Project Status:</strong><br />
                        <div class="col-md-2 col-xs-12">
                            <asp:DropDownList ID="ddlprojectstatus" runat="server" Width="150px" CssClass="form-control">
                                <asp:ListItem Text="---All---" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Completed" Value="1"></asp:ListItem>
                                <asp:ListItem Text="On-going" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Delayed" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <strong>From Date:</strong><br />
                        <asp:TextBox ID="txtFromDate" runat="server" Width="150px"></asp:TextBox>
                        <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txtFromDate" Format="dd mmm yyyy" />
                    </div>
                    <div class="col-md-2">
                        <strong>To Date:</strong><br />
                        <asp:TextBox ID="txtToDate" runat="server" Width="150px"></asp:TextBox>
                        <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="txtToDate" Format="dd mmm yyyy" />
                    </div>
                    <div class="col-md-1 col-xs-3">
                        <strong>&nbsp;</strong><br />
                        <asp:Button ID="btn_view" Text="View" runat="server" OnClick="btn_view_Click" CssClass="btn btn-info"
                            OnClientClick="javascript:ShowProgressBar()" />
                    </div>
                    
                </div>
            </div>
        </div>
        <h4 style="text-align: center; font-weight: 700; color: maroon;">
            <asp:Label ID="lblerror" runat="server" Text="No Record Found..." Visible="false"></asp:Label></h4>
        <div class="container-fluid" style="padding-top: 12px;">
            <asp:Panel ID="pnlmain" runat="server" Visible="false">
                <div class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align: center; font-weight: 500; font-size: x-large">
                            Road Construction Department, Bihar
                            <h4>
                                Progress Report of Ongoing Road Schemes For The Year
                                <asp:Label ID="lblFYr" runat="server"></asp:Label>
                            </h4>
                        </div>
                        <div class="panel-body">
                            <div class="container-fluid" style="overflow: scroll">
                                <div class="row">
                                    <div class="
    table-responsive ">
                                        <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">
                                            <asp:GridView ID="grdEistingRecord" CssClass="table table-striped table-bordered table text-center"
                                                OnRowCreated="grdEistingRecord_RowCreated" runat="server" Width="100%" AutoGenerateColumns="false"
                                                OnRowDataBound="grdEistingRecord_RowDataBound" ShowFooter="true" OnDataBound="grdEistingRecord_DataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl.No." HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black"
                                                        HeaderStyle-Width="3%">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                        <ItemStyle />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black"
                                                        HeaderStyle-Width="1%" Visible="false">
                                                        <ItemTemplate>
                                                            <br />
                                                            <asp:Label ID="txtDivision" runat="server" Text='<%# Eval("RoadId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Division" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black"
                                                        HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <%--   <asp:Label ID="txtDivision" runat="server" Text='<%# Eval("DivisionName") %>'></asp:Label>--%>
                                                            <%# Eval("DivisionName") %>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name Of Road" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black"
                                                        HeaderStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtName_of_the_Road1" runat="server" Text='<%# Eval("Name_of_the_Road") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Head" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black"
                                                        HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtRoadType" runat="server" Text='<%# Eval("headName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sanctioned Length(km)" HeaderStyle-BackColor="white"
                                                        HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km2" runat="server" onkeypress="return validate(event);"
                                                                Text='<%# Eval("SanctionRoadLength")
    %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount</br>(Rs. In Lac)" HeaderStyle-BackColor="white"
                                                        HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km3" runat="server" onkeypress="return
    validate(event);" Text='<%# Eval("AAamount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Reference" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="txtNew_Total_Length_km" runat="server" onkeypress="return validate(event);"
                                                                Text='<%# Eval("AArefno") %>'></asp:Label>--%>
                                                            <%#Eval("AArefno")%>
                                                            <%--   <br />--%>
                                                            <%--  <span>---------------</span><br />--%>
                                                            <%#Eval("AADate","{0:dd/MM/yyyy}")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name Of Contractor" HeaderStyle-BackColor="white"
                                                        HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km5" runat="server" onkeypress="return validate(event);"
                                                                Text='<%# Eval("ContractorName")
    %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Agreement Amount (Rs. In Lac)" HeaderStyle-BackColor="white"
                                                        HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km6" runat="server" onkeypress="return
    validate(event);" Text='<%# Eval("AgreementAmount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Rate
    on which work is alloted" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km" runat="server" onkeypress="return
    validate(event);" Text='<%# Eval("WorkAllotedRate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Date Of Work
    Order" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km7" runat="server" onkeypress="return validate(event);"
                                                                Text=' <%#Eval("StartDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date Of Actual Comp./Completion as per </br>Agreement or Final Date as Negotiated with Contractor"
                                                        HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km8" runat="server" onkeypress="return validate(event);"
                                                                Text='<%#Eval("EndDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <%--  <asp:TemplateField HeaderText="Period of DLP" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km" runat="server" onkeypress="return
    validate(event);" Text='<%# Eval("periodofDLP") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>--%>
                                                    <%--  <asp:TemplateField HeaderText="Expenditure
    (Rs in Lacs)" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black" HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km" runat="server" onkeypress="return
    validate(event);" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Cumulative Expenditure upto 31.03.2021(Rs. in Lacs)" HeaderStyle-BackColor="white"
                                                        HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km88" runat="server" onkeypress="return validate(event);"
                                                                Text='<%# Eval("cumfinprev") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Expenditure During 2020-21(Rs. in Lacs)" HeaderStyle-BackColor="white"
                                                        HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km55" runat="server" onkeypress="return validate(event);"
                                                                Text='<%# Eval("2021") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Expenditure During 2021-22 upto 14.03.2022 (Rs. in Lacs)" HeaderStyle-BackColor="white"
                                                        HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km44" runat="server" onkeypress="return validate(event);"
                                                                Text='<%# Eval("2122") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Dt.
    of measurement" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km33" runat="server" onkeypress="return validate(event);"
                                                                Text='<%#Eval("UpdatedDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Work Value as Per target (in lacs)" HeaderStyle-BackColor="white"
                                                        HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km22" runat="server" onkeypress="return
    validate(event);" Text='<%# Eval("AgreementAmount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Actual Work done (in Lacs)" HeaderStyle-BackColor="white"
                                                        HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km11" runat="server" onkeypress="return
    validate(event);" Text='<%# Eval("actalTamount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Fine Imposed/date(in lacs)" HeaderStyle-BackColor="white"
                                                        HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km444" runat="server" onkeypress="return
    validate(event);" Text='<%# Eval("ActualWorkDone") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Total Target of Work to be done as per Agreement(In KM)"
                                                        ItemStyle-Width="150px" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <%--<label>E/W:-</label>--%>
                                                            <table class="no-margin">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblew" runat="server" Text="E/W:-" Font-Bold="true"></asp:Label>
                                                            <asp:Label ID="lbl_ew" runat="server" onkeypress="return
    validate(event);" Text='<%# Eval("EW") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblgsb" runat="server" Text="GSB:-" Font-Bold="true"></asp:Label>
                                                            <asp:Label ID="lbl_gsb" runat="server" onkeypress="return validate(event);" Text='<%#
    Eval("GSB") %>'></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td>
                                                                   <asp:Label ID="lblwbm" runat="server" Text="WBM/WMM:-" Font-Bold="true"></asp:Label>
                                                            <asp:Label ID="lbl_wbm" runat="server" onkeypress="return validate(event);" Text='<%# Eval("WBM") %>'></asp:Label>
                                                                      </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td>
                                                                   <asp:Label ID="lblbm" runat="server" Text="BM:-" Font-Bold="true"></asp:Label>
                                                            <asp:Label ID="lbl_bm" runat="server" onkeypress="return validate(event);" Text='<%# Eval("BM") %>'></asp:Label>
                                                                      </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td>
                                                                      <asp:Label ID="lbldbm" runat="server" Text="DBM:-" Font-Bold="true"></asp:Label>
                                                            <asp:Label ID="lbl_dbm" runat="server" onkeypress="return validate(event);" Text='<%# Eval("SDBC_BC_PMC")
    %>'></asp:Label>
                                                                      </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td>
                                                                   <asp:Label ID="lbldlc" runat="server" Text="DLC:-" Font-Bold="true"></asp:Label>
                                                            <asp:Label ID="lbl_dlc" runat="server" onkeypress="return validate(event);" Text='<%# Eval("DLC") %>'></asp:Label>
                                                                      </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td>
                                                                      <asp:Label ID="lblpqc" runat="server" Text="PQC:-" Font-Bold="true"></asp:Label>
                                                            <asp:Label ID="lbl_pqc" runat="server" onkeypress="return validate(event);" Text='<%# Eval("PQC") %>'></asp:Label>
                                                                      </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td>
                                                                      <asp:Label ID="lblsdbc" runat="server" Text="SDBC/BC/PMC:-" Font-Bold="true"></asp:Label>
                                                            <asp:Label ID="lbl_sdbc" runat="server" onkeypress="return validate(event);" Text='<%# Eval("SDBC_BC_PMC") %>'></asp:Label>
                                                                      </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td>
                                                                    <asp:Label ID="lblpcc" runat="server" Text="PCC:-" Font-Bold="true"></asp:Label>
                                                            <asp:Label ID="lbl_pcc" runat="server" onkeypress="return validate(event);" Text='<%# Eval("PCC") %>'></asp:Label>
                                                                      </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td>
                                                                   <asp:Label ID="lblcd" runat="server" Text="CD (In no.):-" Font-Bold="true"></asp:Label>
                                                            <asp:Label ID="lbl_cd" runat="server" onkeypress="return validate(event);" Text='<%# Eval("CDWork") %>'></asp:Label>
                                                                      </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                   <asp:Label ID="lblbridge" runat="server" Text="BRIDGE (In no.):-" Font-Bold="true"></asp:Label>
                                                            <asp:Label ID="lbl_bridge" runat="server" onkeypress="return validate(event);" Text='<%# Eval("Bridge") %>'></asp:Label>
                                                                      </td>
                                                                </tr>
                                                                 <tr>
                                                                    <td>
                                                                    <asp:Label ID="lbldrain" runat="server" Text="DRAIN:-" Font-Bold="true"></asp:Label>
                                                            <asp:Label ID="lbl_drain" runat="server" onkeypress="return
    validate(event);" Text='<%# Eval("Drain") %>'></asp:Label>
                                                                      </td>
                                                                </tr>

                                                            </table>
                                                          
                                                            <%--<label>
                                                                GSB:-</label>--%>
                                                          
                                                            <%--<label>
                                                                WBM/WMM:-</label>--%>
                                                           
                                                            <%-- <label>
                                                                BM:-</label>--%>
                                                          
                                                            <%--<label>
                                                                DBM:-</label>--%>
                                                         
                                                            <%--<label>
                                                                DLC:-</label>--%>
                                                          
                                                            <%-- <label>
                                                                PQC:-</label>--%>
                                                       
                                                            <%--<label>
                                                                SDBC/BC/PMC:-</label>--%>
                                                         
                                                            <%--<label>
                                                                PCC:-</label>--%>
                                                           
                                                            <%--<label>
                                                                CD (In no.):-</label>--%>
                                                          
                                                            <%--<label>
                                                                DRAIN:-</label>--%>
                                                        
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="E/W (In KM)" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label128" runat="server" onkeypress="return validate(event);" Text='<%# Eval("ewc") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="GSB (In KM)" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gsbdf" runat="server" onkeypress="return validate(event);" Text='<%# Eval("GSB_CUMULATIVE") %>'> </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="WBM/WMM (In KM)" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            </label><asp:Label ID="WBM" runat="server" onkeypress="return validate(event);" Text='<%# Eval("WBM_WMM_CUMULATIVE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BM/DBM(In KM)" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblbmc" runat="server" onkeypress="return validate(event);" Text='<%# Eval("BM_CUMULATIVE") %>'></asp:Label></br>
                                                            <asp:Label ID="lbldbmc" runat="server" onkeypress="return validate(event);" Text='<%# Eval("DBM_CUMULATIVE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SDBC/BC/PMC(In KM)" HeaderStyle-BackColor="white"
                                                        HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label288" runat="server" onkeypress="return validate(event);" Text='<%# Eval("SDBC_CUMULATIVE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PCC(In KM)" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label277" runat="server" onkeypress="return validate(event);" Text='<%# Eval("PCC_CUMULATIVE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="CD WORK(no.)" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label7" runat="server" onkeypress="return validate(event);" Text='<%# Eval("CDWORK_CUMULATIVE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BRIDGE WORK(no.)" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label77" runat="server" onkeypress="return validate(event);" Text='<%# Eval("BRIDGE_CUMULATIVE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                   
                                                    <asp:TemplateField HeaderText="Expected
    month of completion" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km555" runat="server" onkeypress="return
    validate(event);" Text='<%#Eval("EndDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_kmttt" runat="server" onkeypress="return
    validate(event);" Text='<%# Eval("COMMENTS") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ACS Remarks" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_kmyyu" runat="server" onkeypress="return
    validate(event);" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <%--
                                                     <asp:TemplateField HeaderText="Remarks Meeting Held" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km" runat="server" onkeypress="return
    validate(event);" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>--%>
                                                    <%--    <asp:TemplateField HeaderText="Remarks Meeting To Be Held" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtNew_Total_Length_km" runat="server" onkeypress="return
    validate(event);" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                                <FooterStyle BackColor="white" />
                                                <HeaderStyle BackColor="white" Font-Bold="True" ForeColor="black" />
                                                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Right" />
                                                <%-- <RowStyle
    BackColor="White" />--%>
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#383838" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
</asp:Content>
