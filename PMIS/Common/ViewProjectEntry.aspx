<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true"
    CodeFile="ViewProjectEntry.aspx.cs" Inherits="RCDPMISNEW_Common_ViewProjectEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css" media="screen">
        .print
        {
            background-color: #fff;
        }
        .printdraft img
        {
            visibility: hidden;
        }
    </style>
    <style type="text/css" media="print">
        .printdraft img
        {
            visibility: visible;
        }
    </style>
    <style type="text/css" media="all">
        .printfinal img
        {
            visibility: hidden;
        }
    </style>
    <style type="text/css" media="print">
        .pageBreak
        {
            page-break-before: always;
        }
    </style>
    <style type="text/css">
        .grid td, th
        {
            padding: 4px;
        }
        
        
        
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid" style="padding-top: 10px;">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align: center; font-weight: 700; color: blue;">
                View Project Entry</div>
            <div class="panel-body">
                <center>
                    <asp:Chart ID="charttxt" runat="server" CssClass="shadow" Height="300px" Width="600px"
                        ToolTip="Physical Progress Graph">
                        <Titles>
                            <asp:Title ShadowOffset="2" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series ChartArea="ChartArea1" Legend="Default" Name="Target">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" ChartType="StackedColumn" Legend="Default" Name="Achieved">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" Area3DStyle-Enable3D="true" Area3DStyle-IsClustered="true"
                                Area3DStyle-PointDepth="10">
                                <Area3DStyle />
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                    <asp:Chart ID="Chart1" runat="server" CssClass="shadow" Height="300px" Width="600px"
                        ToolTip="Physical Progress Graph">
                        <Titles>
                            <asp:Title ShadowOffset="2" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="Target">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" ChartType="StackedColumn" Name="Achieved">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true" Area3DStyle-IsClustered="true"
                                Area3DStyle-PointDepth="10">
                                <Area3DStyle />
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </center>
                <hr />
                <div class="row">
                    <div class="col-md-2">
                        <label>
                            Project No:</label>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lbl_prno" runat="server" BackColor="#ffff00" Font-Bold="true"></asp:Label>
                    </div>
                </div>
                <div class="row" style="padding-top: 5px">
                    <div class="col-md-2">
                        <label>
                            Project Name:</label>
                    </div>
                    <div class="col-md-10">
                        <%-- <asp:Label ID="lbl_project_name" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="lbl_project_name" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="padding-top: 5px">
                    <div class="col-md-2">
                        <label>
                            Head:</label>
                    </div>
                    <div class="col-md-2">
                        <%--  <asp:Label ID="lbl_head_name" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="lbl_head_name" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label>
                            Sub-Head:</label>
                    </div>
                    <div class="col-md-2">
                        <%--<asp:Label ID="lbl_sub_head" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="lbl_sub_head" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label>
                            RoadType:</label>
                    </div>
                    <div class="col-md-2">
                        <%-- <asp:Label ID="lblroadtype" runat="server"></asp:Label>  --%>
                        <asp:TextBox ID="lblroadtype" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="padding-top: 5px">
                    <div class="col-md-2">
                        <label>
                            Road Name:</label>
                    </div>
                    <div class="col-md-10">
                        <%--<asp:Label ID="lblroadname" runat="server"></asp:Label> --%>
                        <asp:TextBox ID="lblroadname" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="padding-top: 5px">
                    <div class="col-md-2">
                        <label>
                            Length of Sanction Road (in km):</label>
                    </div>
                    <div class="col-md-2">
                        <%--<asp:Label ID="lbl_length_of_section" runat="server"></asp:Label> --%>
                        <asp:TextBox ID="lbl_length_of_section" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label>
                            Nature of Work:</label>
                    </div>
                    <div class="col-md-2">
                        <%-- <asp:Label ID="lblnatureofwork" runat="server"></asp:Label> --%>
                        <asp:TextBox ID="lblnatureofwork" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label>
                            Type:</label>
                    </div>
                    <div class="col-md-2">
                        <%--<asp:Label ID="lblworktype" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="lblworktype" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="padding-top: 5px">
                    <div class="col-md-2">
                        <label>
                            Admin. Approval Ref. No.:</label>
                    </div>
                    <div class="col-md-2">
                        <%--  <asp:Label ID="lbl_adminaproval_refno" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="lbl_adminaproval_refno" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label>
                            Admin. Approval Amount (in Lakh):</label>
                    </div>
                    <div class="col-md-2">
                        <%--<asp:Label ID="lbl_admin_approvalamt" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="lbl_admin_approvalamt" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label>
                            Admin. Approval Date:</label>
                    </div>
                    <div class="col-md-1">
                        <%-- <asp:Label ID="lbl_adminaprovaldate" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="lbl_adminaprovaldate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="padding-top: 5px">
                    <div class="col-md-2">
                        <label>
                            Start Date:</label>
                    </div>
                    <div class="col-md-2">
                        <%--<asp:Label ID="lblstartdate" runat="server"></asp:Label><br />--%>
                        <asp:TextBox ID="lblstartdate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label>
                            End Date:</label>
                    </div>
                    <div class="col-md-2">
                        <%-- <asp:Label ID="lblenddate" runat="server"></asp:Label><br />--%>
                        <asp:TextBox ID="lblenddate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label>
                            Agreement Amount (in Lakh):</label>
                    </div>
                    <div class="col-md-2">
                        <%-- <asp:Label ID="lblagrementamt" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="lblagrementamt" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="padding-top: 5px">
                    <div class="col-md-2">
                        <label>
                            Contractor/PAN:</label>
                    </div>
                    <div class="col-md-2">
                        <%--  <asp:Label ID="lblcontractor" runat="server"></asp:Label><br />--%>
                        <asp:TextBox ID="lblcontractor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label>
                            Work Program Submitted:</label>
                    </div>
                    <div class="col-md-2">
                        <%-- <asp:Label ID="lblworkprogram" runat="server"></asp:Label><br />--%>
                        <asp:TextBox ID="lblworkprogram" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label>
                            Status:</label>
                    </div>
                    <div class="col-md-2">
                        <%-- <asp:Label ID="lblstatus" runat="server"></asp:Label><br />--%>
                        <asp:TextBox ID="lblstatus" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="padding-top: 5px" id="divcompletion" runat="server">
                    <div class="col-md-2">
                        <label>
                            Completion Date:</label>
                    </div>
                    <div class="col-md-2">
                        <%-- <asp:Label ID="lblcomplectiondate" runat="server"></asp:Label><br />--%>
                        <asp:TextBox ID="lblcomplectiondate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label>
                            Completion Certificate:</label>
                    </div>
                    <div class="col-md-3">
                        <%--<asp:Label ID="lblcomplectioncertificate" runat="server"></asp:Label><br />--%>
                        <asp:TextBox ID="lblcomplectioncertificate" runat="server" CssClass="form-control"
                            Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <%--  image --%>
        <div class="panel panel-default" runat="server" id="pnlimage" visible="false">
            <div class="panel-heading">
                <h3 class="panel-title">
                    Image Section</h3>
            </div>
            <div class="panel-body">
                <div class="row" style="padding-top: 5px">
                    <div class="col-md-2">
                        <label>
                        </label>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-2">
                        <label>
                            Image Type:</label>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlimageshow" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlimageshow_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <label>
                        </label>
                    </div>
                    <div class="col-md-2">
                    </div>
                </div>
                <center>
                <div class="row" style="padding-top: 5px">
                    <div class="col-lg-12 preview12 form-group">
                        <asp:Image ID="img1" runat="server" class="d-block w-100" Height="250" Width="350"  Visible="false"/>
                            <asp:Image ID="img2" runat="server" class="d-block w-250" Height="250" Width="350" Visible="false" />
                      
                    </div>
                </div>
                 <div class="row" style="padding-top: 5px">
                    <div class="col-lg-12 preview12 form-group" runat="server" id="pnldesc" visible="false">
                      <label style="color: darkred; margin-left:auto">
                         Road Component 1:-</label>
                       <asp:Label ID="lblDescription1" runat="server" ForeColor="black" Visible="false"></asp:Label>
                        <label style="color: darkred; margin-left:auto">
                          Road Component 2:-</label><asp:Label ID="lblDescription2" runat="server" ForeColor="black" Visible="false"></asp:Label>
                    </div>
                </div>
                </center>
            </div>
        </div>
    </div>
</asp:Content>
