<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true"
    CodeFile="ProjectEntryDetails.aspx.cs" Inherits="RCDPMISNEW_Common_ProjectEntryDetails" %>

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
    <div class="panel panel-default" style="padding-top: 12px;">
        <div class="panel-heading" style="font-weight: bold; text-align: center">
           <h4>Project Entry Details</h4></div>
        <div class="panel-body">
            <asp:Panel ID="pnl_main_search" runat="server">
                <asp:GridView ID="grdEistingRecord" CssClass="table table-striped table-bordered table text-center"
                    runat="server" Width="100%" AutoGenerateColumns="false" ShowFooter="true" ShowHeaderWhenEmpty="True"
                    EmptyDataText="No records Found..." EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-ForeColor="#990000"
                    DataKeyNames="Projectno,TargetID" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdEistingRecord_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Sl.No." HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"
                            HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                            HeaderStyle-Width="1%">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Name/No." HeaderStyle-BackColor="#008abc"
                            HeaderStyle-ForeColor="White" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="small"
                            HeaderStyle-BorderColor="black" HeaderStyle-Width="4%">
                            <ItemTemplate>
                                <label style="font-weight: 400; color: maroon;">
                                    Project Name:-</label><asp:Label ID="lblprojectname" runat="server" Text='<%# Eval("ProjectName") %>'></asp:Label><br />
                                <label style="font-weight: 400; color: maroon;">
                                    Project No.:-</label>
                                <asp:Label ID="lblprojectno" runat="server" Text='<%# Eval("Projectno") %>'></asp:Label><br />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Head/SubHead Name" HeaderStyle-BackColor="#008abc"
                            HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                            HeaderStyle-Width="3%">
                            <ItemTemplate>
                                <label style="font-weight: 400; color: maroon;">
                                    Name:-</label><asp:Label ID="lblhead" runat="server" Text='<%# Eval("headName") %>'></asp:Label><br />
                                <label style="font-weight: 400; color: maroon;">
                                    Sub Head Name:-</label>
                                <asp:Label ID="lblsubhead" runat="server" Text='<%# Eval("SubHeadName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Road Type" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"
                            HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black" HeaderStyle-Width="1%">
                            <ItemTemplate>
                                <asp:Label ID="lblroadtype" runat="server" Text='<%# Eval("RoadType") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Road Name" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"
                            HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black" HeaderStyle-Width="3%">
                            <ItemTemplate>
                                <asp:Label ID="lblroadname" runat="server" Text='<%# Eval("Name_of_the_Road") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nature Of Work" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"
                            HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black" HeaderStyle-Width="3%">
                            <ItemTemplate>
                                <asp:Label ID="lblnow" runat="server" Text='<%# Eval("NatOfWorkName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Length Of Sanction Road(in km)" HeaderStyle-BackColor="#008abc"
                            HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                            HeaderStyle-Width="2%">
                            <ItemTemplate>
                                <asp:Label ID="lbllosr" runat="server" Text='<%# Eval("SanctionRoadLength") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Admin Approval Amount" HeaderStyle-BackColor="#008abc"
                            HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                            HeaderStyle-Width="2%">
                            <ItemTemplate>
                                <asp:Label ID="lblaaa" runat="server" Text='<%# Eval("ApprovalAmount") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agreement Amount" HeaderStyle-BackColor="#008abc"
                            HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                            HeaderStyle-Width="2%">
                            <ItemTemplate>
                                <asp:Label ID="lblaa" runat="server" Text='<%# Eval("AgreementAmount") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Start Date/End Date" HeaderStyle-BackColor="#008abc"
                            HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                            HeaderStyle-Width="3%">
                            <ItemTemplate>
                                <label style="font-weight: 400; color: maroon;">
                                    Start Date:-</label><asp:Label ID="lblsdate" runat="server" Text='<%# Eval("StartDate") %>'></asp:Label><br />
                                <label style="font-weight: 400; color: maroon;">
                                    End Date:-</label>
                                <asp:Label ID="lblenddate" runat="server" Text='<%# Eval("EndDate") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Status" HeaderStyle-BackColor="#008abc"
                            HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                            HeaderStyle-Width="3%">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("status") %>'></asp:Label><br />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Target Set" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"
                            HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black" HeaderStyle-Width="4%">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSetTarget" runat="server" Font-Underline="false" Text="Set Target"
                                    CommandName="Select" ForeColor="Blue" OnClick="lnkSetTarget_Click">1. Set Target</asp:LinkButton>
                                <p>
                                </p>
                                <asp:LinkButton ID="lnkCdType" runat="server" Font-Underline="false" Text="CD Type"
                                    Width="150px" CommandName="Select" ForeColor="Blue" OnClick="lnkCdType_Click">2. CD Type</asp:LinkButton>
                                 <p>
                                </p>
                                <p>
                                </p>
                                <asp:LinkButton ID="lnkOthTarget" runat="server" Font-Underline="false" Text="Other Target"
                                    Width="70px" CommandName="Select" ForeColor="Blue" OnClick="lnkOthTarget_Click" Visible="false">Other Target</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="7%" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"
                            HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black" HeaderStyle-Width="1%">
                            <ItemTemplate>
                               
                                <%-- <asp:LinkButton ID="lnkphysicalprgs" runat="server" Font-Underline="false" Text="Physical Progress"
                                                                    Width="70px" CommandName="Select" ForeColor="Blue" 
                                                                     OnClick="lnkphysicalprgs_Click">Physical Progress</asp:LinkButton><br />--%>
                                <a href='PhysicalProgress.aspx?TargetID=<%#Eval("TargetID")%>&ProjectNo=<%#Eval("Projectno")%>'
                                    target="_blank" style="color:Blue">1. Physical Progress</a><br />
                                <%-- <a href="#" target="_blank">Physical Progress</a><br/>--%>
                                <%-- <a href='ViewProjectEntry.aspx?ProjectNo=<%#Eval("Projectno")%>' target="_blank"><i class="fa fa-eye" aria-hidden="true"></i></a>--%>
                                <a href='ViewProjectEntry.aspx?TargetID=<%#Eval("TargetID")%>&ProjectNo=<%#Eval("Projectno")%>'
                                    target="_blank" style="color:Blue">2. View</a><br />
                                <a href='UpdateProjectEntry.aspx?ProjectNo=<%#Eval("Projectno")%>' target="_blank" style="color:Blue">3. Edit</a><br />
                                <%--  <a href='PhysicalProgress.aspx?ProjectNo=<%#Eval("Projectno")%>' target="_blank">View</a>--%>
                                <%--<a href='FinancialEntry.aspx?ProjectNo=<%#Eval("Projectno")%>' target="_blank">Financial Progress</a><br />--%>
                            <asp:LinkButton ID="lnkFinancial" runat="server" Font-Underline="False" Visible="true"  Text="Financial Progress" CommandArgument='<%#Eval("Projectno")%>'
                                                                    ForeColor="blue"  OnClick="lnkFinancial_Click"  ></i>4. Financial Progress</asp:LinkButton>
                               
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="7%" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="white" Font-Bold="True" ForeColor="black" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Right" />
                    <%-- <RowStyle BackColor="White" />--%>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </asp:Panel>
            <%-- Target Set--%>
            <asp:Panel ID="pnlWTarget" runat="server" Width="100%" BorderStyle="None" BorderWidth="1pt"
                BorderColor="Black" Visible="false">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center; font-weight: 600; color: blue;">
                        <h5>Target Entry</h5></div>
                    <div class="panel-body">
                        <table width="100%">
                            <%-- <tr>
                            <td colspan="10" align="center" style="font-size: medium; font-weight: bold; background-color: #C0C0C0">
                             
                                Target Entry
                            </td>
                        </tr>--%>
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
                            <tr>
                                <td align="left" colspan="10" class="style2">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 6%">
                                    E/ W:
                                </td>
                                <td align="left" style="width: 12%">
                                    <asp:TextBox ID="txtEW" runat="server" Width="60px" onkeypress="return validate(event)"
                                        onfocus="if(this.value=='0'){this.value=''}" onblur="if(this.value==''){this.value='0'}"
                                        Text="0"></asp:TextBox>
                                    <asp:Label ID="Label8" runat="server" Text="(in Km)" Font-Bold="true" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left" style="width: 8%">
                                    GSB:
                                </td>
                                <td align="left" style="width: 12%">
                                    <asp:TextBox ID="txtGSB" runat="server" Width="60px" onkeypress="return validate(event)"
                                        onfocus="if(this.value=='0'){this.value=''}" onblur="if(this.value==''){this.value='0'}"
                                        Text="0"></asp:TextBox>
                                    <asp:Label ID="lblGSB" runat="server" Text="(in Km)" Font-Bold="true" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left" style="width: 9%">
                                    WBM/ WMM:
                                </td>
                                <td align="left" style="width: 12%">
                                    <asp:TextBox ID="txtWBM" runat="server" Width="60px" onkeypress="return validate(event)"
                                        onfocus="if(this.value=='0'){this.value=''}" onblur="if(this.value==''){this.value='0'}"
                                        Text="0"></asp:TextBox>
                                    <asp:Label ID="Label17" runat="server" Text="(in Km)" Font-Bold="true" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left" style="width: 11%">
                                    BUSG:
                                </td>
                                <td align="left" style="width: 12%">
                                    <asp:TextBox ID="txtBUSG" runat="server" Width="60px" onkeypress="return validate(event)"
                                        onfocus="if(this.value=='0'){this.value=''}" onblur="if(this.value==''){this.value='0'}"
                                        Text="0"></asp:TextBox>
                                    <asp:Label ID="Label18" runat="server" Text="(in Km)" Font-Bold="true" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left" style="width: 4%">
                                    BM:
                                </td>
                                <td align="left" style="width: 12%">
                                    <asp:TextBox ID="txtBM" runat="server" Width="60px" onkeypress="return validate(event)"
                                        onfocus="if(this.value=='0'){this.value=''}" onblur="if(this.value==''){this.value='0'}"
                                        Text="0"></asp:TextBox>
                                    <asp:Label ID="Label19" runat="server" Text="(in Km)" Font-Bold="true" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    DBM:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDBM" runat="server" Width="60px" onkeypress="return validate(event)"
                                        onfocus="if(this.value=='0'){this.value=''}" onblur="if(this.value==''){this.value='0'}"
                                        Text="0"></asp:TextBox>
                                    <asp:Label ID="Label20" runat="server" Text="(in Km)" Font-Bold="true" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left">
                                    Prime Coat:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPriCoat" runat="server" Width="60px" onfocus="if(this.value=='0'){this.value=''}"
                                        onblur="if(this.value==''){this.value='0'}" Text="0"></asp:TextBox>
                                    <asp:Label ID="Label21" runat="server" Text="(in Km)" Font-Bold="true" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left">
                                    Teak Coat:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtTeakCoat" runat="server" Width="60px" onfocus="if(this.value=='0'){this.value=''}"
                                        onblur="if(this.value==''){this.value='0'}" Text="0"></asp:TextBox>
                                    <asp:Label ID="Label22" runat="server" Text="(in Km)" Font-Bold="true" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left">
                                    SDBC/ BC/ PMC:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSDBC" runat="server" Width="60px" onkeypress="return validate(event)"
                                        onfocus="if(this.value=='0'){this.value=''}" onblur="if(this.value==''){this.value='0'}"
                                        Text="0"></asp:TextBox>
                                    <asp:Label ID="Label23" runat="server" Text="(in Km)" Font-Bold="true" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left">
                                    PCC:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPCC" runat="server" Width="60px" onkeypress="return validate(event)"
                                        onfocus="if(this.value=='0'){this.value=''}" onblur="if(this.value==''){this.value='0'}"
                                        Text="0"></asp:TextBox>
                                    <asp:Label ID="Label24" runat="server" Text="(in Km)" Font-Bold="true" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    DLC
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDLC" runat="server" Width="60px" onfocus="if(this.value=='0'){this.value=''}"
                                        onblur="if(this.value==''){this.value='0'}" Text="0"></asp:TextBox>
                                    <asp:Label ID="Label25" runat="server" Font-Bold="true" Font-Size="Small" Text="(in Km)"></asp:Label>
                                </td>
                                <td align="left">
                                    PQC
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPQC" runat="server" Width="60px" onfocus="if(this.value=='0'){this.value=''}"
                                        onblur="if(this.value==''){this.value='0'}" Text="0"></asp:TextBox>
                                    <asp:Label ID="Label26" runat="server" Font-Bold="true" Font-Size="Small" Text="(in Km)"></asp:Label>
                                </td>
                                <td align="left">
                                    Drain
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDrain" runat="server" Width="60px" onfocus="if(this.value=='0'){this.value=''}"
                                        onblur="if(this.value==''){this.value='0'}" Text="0"></asp:TextBox>
                                    <asp:Label ID="Label27" runat="server" Font-Bold="true" Font-Size="Small" Text="(in Km)"></asp:Label>
                                </td>
                                <td align="left">
                                    Mastic Asphalt
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtmasticasphalt" runat="server" Width="60px" onfocus="if(this.value=='0'){this.value=''}"
                                        onblur="if(this.value==''){this.value='0'}" Text="0"></asp:TextBox>
                                    <asp:Label ID="Label28" runat="server" Font-Bold="true" Font-Size="Small" Text="(in Km)"></asp:Label>
                                </td>
                                <td align="left">
                                    Shoulder :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtshoulder" runat="server" Width="60px" onfocus="if(this.value=='0'){this.value=''}"
                                        onblur="if(this.value==''){this.value='0'}" Text="0"></asp:TextBox>
                                    <asp:Label ID="Label29" runat="server" Font-Bold="true" Font-Size="Small" Text="(in Km)"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    CD Work:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCDWork" runat="server" onkeypress="return validate(event)" Width="60px"
                                        onfocus="if(this.value=='0'){this.value=''}" onblur="if(this.value==''){this.value='0'}"
                                        Text="0" Enabled="false"></asp:TextBox>
                                    <asp:Label ID="Label30" runat="server" Font-Bold="true" Font-Size="Small" Text="(in No.)"></asp:Label>
                                </td>
                                <td>
                                    Bridge:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtbridge" runat="server" onkeypress="return validate(event)" Width="60px"
                                        onfocus="if(this.value=='0'){this.value=''}" onblur="if(this.value==''){this.value='0'}"
                                        Text="0" Enabled="false"></asp:TextBox>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="Small" Text="(in No.)"></asp:Label>
                                </td>
                                <td align="left">
                                    Protection Work:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtprotectionwok" runat="server" Width="60px" onfocus="if(this.value=='0'){this.value=''}"
                                        onblur="if(this.value==''){this.value='0'}" Text="0"></asp:TextBox>
                                    <asp:Label ID="Label31" runat="server" Font-Bold="true" Font-Size="Small" Text="(in Km)"></asp:Label>
                                </td>
                                <td align="left">
                                    Bolder Picth
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtbolderpitch" runat="server" Width="60px" onfocus="if(this.value=='0'){this.value=''}"
                                        onblur="if(this.value==''){this.value='0'}" Text="0"></asp:TextBox>
                                    <asp:Label ID="Label32" runat="server" Font-Bold="true" Font-Size="Small" Text="(in Km)"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="10">
                                    <asp:Button ID="btnTarSave" runat="server" Text="Save" OnClientClick="return confirm('Are you sure ?');"
                                        OnClick="btnTarSave_Click" Width="80px" CssClass="btn btn-primary" />
                                    <asp:Button ID="btnTarUpdate" runat="server" Text="Update" Visible="false" OnClientClick="return confirm('Are you sure ?');"
                                        OnClick="btnTarUpdate_Click" Width="80px" />
                                    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Width="80px"
                                        CssClass="btn btn-info" /><asp:Label ID="Label33" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
            <%-- Target Set--%>
            <%--  Cd Type Work--%>
            <asp:Panel ID="pnlCDType" runat="server" Width="100%" BorderStyle="None" BorderWidth="1pt"
                BorderColor="Black" Visible="false">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center; font-weight: 600; color: blue;">
                        CD Work Type</div>
                    <div class="panel-body">
                        <%-- <div class="row" style="padding-top:10px;">

                      </div>--%>
                        <table width="100%">
                            <tr>
                                <td align="left" colspan="10">
                                    <strong>Project Name/ No. :</strong>&nbsp;&nbsp;
                                    <asp:Label ID="lblCDTypeProjNo" runat="server" Text="" ForeColor="#800000"></asp:Label><strong>
                                        / {</strong><asp:Label ID="lblCDTypeProjName" runat="server" Text="" ForeColor="#800000"></asp:Label><strong>}</strong>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 6%">
                                    CD Type:
                                </td>
                                <td align="left" style="width: 12%">
                                    <asp:DropDownList ID="ddlCDType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCDType_SelectedIndexChanged"
                                        Width="120px" Height="16px" CssClass="form-control-static">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 3%">
                                    <asp:Label ID="lblCdTypeNo" runat="server" Text="No.:" Visible="false"></asp:Label>
                                </td>
                                <td align="left" style="width: 10%">
                                    <asp:TextBox ID="txtCdTypeNo" runat="server" Visible="false" Width="100px" onkeypress="return validate(event)"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 3%">
                                    <asp:Label ID="lblcdSize" runat="server" Text="Size:" Visible="false"></asp:Label>
                                </td>
                                <td align="left" style="width: 10%">
                                    <asp:TextBox ID="txtcdSize" runat="server" Visible="false" Width="100px"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 8%">
                                    <asp:Label ID="lblSpanLength" runat="server" Text="Span Length:" Visible="false"></asp:Label>
                                </td>
                                <td align="left" style="width: 10%">
                                    <asp:TextBox ID="txtSpanLength" runat="server" onkeypress="return validate(event)"
                                        Visible="false" Width="60px"></asp:TextBox>
                                    <asp:Label ID="lblInM" runat="server" Font-Bold="true" Font-Size="Small" Text="(in m)"
                                        Visible="false"></asp:Label>
                                </td>
                                <td align="left" style="width: 5%">
                                    <asp:Label ID="lblLength" runat="server" Text="Length:" Visible="false"></asp:Label>
                                </td>
                                <td align="left" style="width: 33%">
                                    <asp:TextBox ID="txtLength" runat="server" onkeypress="return validate(event)" Visible="false"
                                        Width="60px"></asp:TextBox>
                                    <asp:Label ID="lblInKM" runat="server" Font-Bold="True" Font-Size="Small" Text="(in m)"
                                        Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="10">
                                    <asp:Button ID="Button1" runat="server" Text="Save" OnClientClick="return confirm('Are you sure ?');"
                                        Width="60px" OnClick="Button1_Click" CssClass="btn btn-primary" />
                                    <asp:Button ID="Button2" runat="server" Text="Update" Visible="false" OnClientClick="return confirm('Are you sure ?');"
                                        Width="60px" OnClick="Button2_Click" CssClass="btn btn-primary" />
                                    <asp:Button ID="btnCDDelete" runat="server" Text="Delete" Visible="false" OnClientClick="return confirm('Are you sure ?');"
                                        Width="60px" OnClick="btnCDDelete_Click" CssClass="btn btn-danger" />
                                    <asp:Button ID="Button3" runat="server" Text="Back" Width="60px" OnClick="Button3_Click"
                                        CssClass="btn btn-info" />
                                    <asp:Label ID="Label43" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td align="center" colspan="10" style="padding-top: 25px">
                                    <asp:GridView ID="gvCDType" runat="server" AutoGenerateColumns="false" DataKeyNames="slno"
                                        Width="100%" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found!" AutoGenerateSelectButton="True"
                                        HeaderStyle-BackColor="#C0C0C0" OnSelectedIndexChanged="gvCDType_SelectedIndexChanged"
                                        CssClass="table table-striped table-bordered table text-center">
                                        <RowStyle VerticalAlign="Top" Wrap="true" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl. No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1+"." %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CD Type Name">
                                                <ItemTemplate>
                                                    <%#Eval("CDTypeName")%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No.">
                                                <ItemTemplate>
                                                    <%#Eval("CDTypeNo")%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Size">
                                                <ItemTemplate>
                                                    <%#Eval("Size")%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Span Length">
                                                <ItemTemplate>
                                                    <%#Eval("SpanLengh")%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Length">
                                                <ItemTemplate>
                                                    <%#Eval("lengh")%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
            <%--   cd type work--%>
            <%-- Other Target--%>
            <asp:Panel ID="pnlOtherType" runat="server" Width="100%" BorderStyle="None" BorderWidth="1pt"
                BorderColor="Black" Visible="false">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center; font-weight: 600; color: blue;">
                        Other Target</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-2 col-xs-3">
                                <strong>Project Name/ No. :</strong>
                            </div>
                            <div class="col-md-4 col-xs-8">
                                <asp:Label ID="Label10" runat="server" Text="" ForeColor="#800000"></asp:Label><strong>
                                    / {</strong><asp:Label ID="Label11" runat="server" Text="" ForeColor="#800000"></asp:Label><strong>}</strong>
                            </div>
                        </div>
                        <div class="row" style="padding-top: 10px;">
                            <div class="col-md-2 col-xs-2">
                                <strong>Name:</strong>
                            </div>
                            <div class="col-md-3 col-xs-4">
                                <asp:TextBox ID="txtOthTypeName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-xs-1">
                                <asp:Label ID="Label36" runat="server" Text="No.:"></asp:Label>
                            </div>
                            <div class="col-md-1 col-xs-4">
                                <asp:TextBox ID="txtOthType_No" runat="server" onkeypress="return validate(event)"
                                    CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-xs-12">
                                <asp:Button ID="btnOth_Save" runat="server" Text="Save" OnClientClick="return confirm('Are you sure ?');"
                                    Width="70px" OnClick="btnOth_Save_Click" CssClass="btn btn-primary" />
                                <asp:Button ID="btnOth_Update" runat="server" Text="Update" Visible="false" OnClientClick="return confirm('Are you sure ?');"
                                    Width="70px" OnClick="btnOth_Update_Click" CssClass="btn btn-primary" />
                                <asp:Button ID="btnOth_Delete" runat="server" Text="Delete" Visible="false" OnClientClick="return confirm('Are you sure ?');"
                                    Width="70px" OnClick="btnOth_Delete_Click" CssClass="btn btn-danger" />
                                <asp:Button ID="btnOth_Reset" runat="server" Text="Back" Width="70px" OnClick="btnOth_Reset_Click"
                                    CssClass="btn btn-info" />&nbsp;
                                <asp:Label ID="Label37" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="padding-top: 10px;">
                            <div class="col-md-12 col-xs-12">
                                <asp:GridView ID="gvOthType" runat="server" AutoGenerateColumns="false" DataKeyNames="slno"
                                    Width="100%" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found!" AutoGenerateSelectButton="True"
                                    HeaderStyle-BackColor="#C0C0C0" OnSelectedIndexChanged="gvOthType_SelectedIndexChanged"
                                    CssClass="table table-striped table-bordered table text-center">
                                    <RowStyle VerticalAlign="Top" Wrap="true" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl. No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1+"." %>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <%#Eval("OthType_Name")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="55%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No.">
                                            <ItemTemplate>
                                                <%#Eval("OthType_No")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="25%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <%--  Other Target--%>
            <%-- Physical Progress--%>
            <asp:Panel ID="pnlphysicalprogress" runat="server" Visible="false">
                <div class="col-md-2">
                </div>
                <div class="col-md-8">
                    <asp:GridView ID="grdtarget" CssClass="table table-striped table-bordered table text-center"
                        runat="server" Width="50%" OnRowDataBound="grdtarget_RowDataBound" AutoGenerateColumns="false"
                        ShowFooter="true" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found..."
                        EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-ForeColor="#990000" DataKeyNames="id">
                        <Columns>
                            <asp:TemplateField HeaderText="Target Name" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"
                                HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                                HeaderStyle-Width="2%">
                                <ItemTemplate>
                                    <asp:Label ID="lbltargetname" runat="server" Text='<%# Eval("TargetName") %>'></asp:Label><br />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Target(In KM)" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"
                                HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                                HeaderStyle-Width="2%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txttargetnameff" runat="server" Text='<%# Eval("Target") %>' Enabled="false"></asp:TextBox><br />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cumulative (In KM)" HeaderStyle-BackColor="#008abc"
                                HeaderStyle-ForeColor="White" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="small"
                                HeaderStyle-BorderColor="black" HeaderStyle-Width="2%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCumulative" runat="server"></asp:TextBox><br />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Previous Update(In KM)" HeaderStyle-BackColor="#008abc"
                                HeaderStyle-ForeColor="White" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="small"
                                HeaderStyle-BorderColor="black" HeaderStyle-Width="2%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPreviousUpdate" runat="server"></asp:TextBox><br />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Today (In KM)" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"
                                HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="small" HeaderStyle-BorderColor="black"
                                HeaderStyle-Width="2%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txttoday" runat="server"></asp:TextBox><br />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="white" Font-Bold="True" ForeColor="black" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Right" />
                        <%-- <RowStyle BackColor="White" />--%>
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                    <div class="col-md-2">
                        <asp:Label ID="lblcomment" Text="Comment" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtcomment" Placeholder="Enter Your Comment" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn bg-orange"
                            Width="150px" />
                    </div>
                </div>
            </asp:Panel>
            <%--Physical Progress--%>
        </div>
    </div>
</asp:Content>
