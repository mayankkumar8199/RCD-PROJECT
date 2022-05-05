<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true"
    CodeFile="RoadMasterData.aspx.cs" Inherits="RCDPMISNEW_ADM_RoadMasterData" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar" Namespace="RJS.Web.WebControl"
    TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <%--<script type="text/javascript">
    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
        }, 200);
    }
    $(document).ready ( function(){
        ShowProgress() ;
    });​
</script>--%>
    <script type="text/javascript">

        function ShowProgressBar() {
            document.getElementById('dvProgressBar').style.visibility = 'visible';
        }

        function HideProgressBar() {
            document.getElementById('dvProgressBar').style.visibility = "hidden";
        }
    </script>

    <style type="text/css">
        .modal {
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

        .loading {
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

        .grid-sltrow {
            background: #ddd;
            font-weight: bold;
        }

        .SubTotalRowStyle {
            border: solid 1px Black;
            background-color: #D8D8D8;
            font-weight: bold;
        }

        .GrandTotalRowStyle {
            border: solid 1px Gray;
            background-color: #000000;
            color: #ffffff;
            font-weight: bold;
        }

        .GroupHeaderStyle {
            border: solid 1px Black;
            background-color: #4682B4;
            color: #ffffff;
            font-weight: bold;
        }

        .serh-grid {
            width: 85%;
            border: 1px solid #6AB5FF;
            background: #fff;
            line-height: 14px;
            font-size: 11px;
            font-family: Verdana;
        }


        .dropdown-icon {
            color: red;
        }

        .table table tbody tr td a,
        .table table tbody tr td span {
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

        .table table > tbody > tr > td > span {
            z-index: 3;
            color: #fff;
            cursor: default;
            background-color: #337ab7;
            border-color: #337ab7;
        }

        .table table > tbody > tr > td:first-child > a,
        .table table > tbody > tr > td:first-child > span {
            margin-left: 0;
            border-top-left-radius: 4px;
            border-bottom-left-radius: 4px;
        }

        .table table > tbody > tr > td:last-child > a,
        .table table > tbody > tr > td:last-child > span {
            border-top-right-radius: 4px;
            border-bottom-right-radius: 4px;
        }




        .table table > tbody > tr > td > a:hover,
        .table table > tbody > tr > td > span:hover,
        .table table > tbody > tr > td > a:focus,
        .table table > tbody > tr > td > span:focus {
            z-index: 2;
            color: #23527c;
            background-color: #eee;
            border-color: #ddd;
        }
   
        fieldset {
            border: 1px solid #0f2c62;
            border-radius: 3px;
            padding: 10px;
            background-color: White;
        }

        legend {
            background-color: #014e9c;
            color: #fff;
            padding: 3px 6px;
            font-weight: 100;
            text-align: center;
        }

        .grid th {
            background-color: #3393ff;
            color: White;
            border-collapse: collapse;
            padding: 10px;
            border-color: Black;
        }

        .grid tr {
            background-color: White;
            color: Black;
            border-collapse: collapse;
            padding: 10px;
        }

        .grid td {
            text-align: center;
        }

        .grid th:first-child {
            background-color: #3393ff;
            -moz-border-radius-topleft: 14px;
            -webkit-border-top-left-radius: 14px;
            border-top-left-radius: 14px;
            border-collapse: collapse;
            cellpadding: 0px;
            cellspacing: 0px;
        }

        .grid th:last-child {
            background-color: #3393ff;
            -moz-border-radius-topright: 14px;
            -webkit-border-top-right-radius: 14px;
            border-top-right-radius: 14px;
        }

        .grid tr:hover {
            background-color: #EEE5CE;
        }

        .grid tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .grid tr:hover {
            background-color: #ddd;
        }
    </style>
    <script type="text/javascript">

        /*The following function(java script) will restrict to assign only numeric value in the text box of phone / mobile number*/

        function validate(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            //            if (charCode > 31 && (charCode < 48 || charCode > 57))
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46) {
                alert("Enter numerals only in this field.");
                return false;
            }
            return true;


        }
    </script>
  

    <script type="text/javascript">
function PostToNewWindow()
{
    originalTarget = document.forms[0].target;
    document.forms[0].target='_blank';
    window.setTimeout("document.forms[0].target=originalTarget;",300);
    return true;
}
</script>






</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <div class="container-fluid" style="padding-top: 12px;">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-weight: 700; font-size: x-large">Road Master Details</div>
                <div class="panel-body">

                    <div class="row">
                                
                            <div class="col-md-9"></div>
                                 <div class="col-md-2"></div>
                            <div class="col-md-1">
                                <%--<asp:ImageButton ID="add_RoadMaster" runat="server" OnClick="add_RoadMaster_Click" Width="50px" ImageUrl="~/RCDPMISNEW/images/AddProject1.png" Visible="false" />--%>
                            </div>                     

                            </div>
                 
                    <div class="panel panel-info">
                        <div class="panel-heading" style="text-align:center; font-weight:600;">Filter Road Master Data</div>
                        <div class="panel-body">
                            <div class="row" style="padding-bottom: 10px;">
                                 <div class="col-md-1 col-xs-12"></div>

                                <div class="col-md-2 col-xs-12">
                                    <strong>Wings</strong><br />
                                    <asp:DropDownList ID="ddlwings" AutoPostBack="true" OnSelectedIndexChanged="ddlwings_SelectedIndexChanged" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2 col-xs-12">
                                    <strong>Circle</strong><br />
                                    <asp:DropDownList ID="ddlcircle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcircle_SelectedIndexChanged" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2 col-xs-12">
                                    <strong>Division</strong><br />
                                    <asp:DropDownList ID="ddldivision" AutoPostBack="true" runat="server"
                                        CssClass="form-control"
                                        OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2 col-xs-12">
                                    <strong>Road Type</strong><br />
                                    <asp:DropDownList ID="ddl_roadtype" AutoPostBack="true" runat="server"
                                        CssClass="form-control"
                                        OnSelectedIndexChanged="ddl_roadtype_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1 col-xs-3">
                                    <strong>&nbsp;</strong><br />
                                    <asp:Button ID="btn_view" Text="Search" runat="server" OnClick="btn_view_Click" CssClass="btn btn-info" OnClientClick="javascript:ShowProgressBar()" />

                                </div>
                                <div class="col-md-1 col-xs-3">
                                    <%--<strong>&nbsp;</strong>--%></br>
             
                  <%--<asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click"
                      runat="server" ImageUrl="~/RCDPMISNEW/images/refresh.png" Width="25px" Height="25px"></asp:ImageButton>--%>

                                </div>
                                <%-- <div class="col-md-1">
                            
                            <p style="float: right; padding-top: 5px;">
                                <asp:ImageButton ID="btn_export_to_excel" runat="server" OnClick="btn_export_to_excel_Click" Width="100px" ImageUrl="~/RCDPMISNEW/images/Excel_img.png" /></p>
                        </div>--%>
                                <%--<div class="col-md-1">
                            <asp:ImageButton ID="add_RoadMaster" runat="server" OnClick="add_RoadMaster_Click" Width="50px" ImageUrl="~/RCDPMISNEW/images/AddProject1.png" Visible="false" />
                        </div>--%>
                            </div>

                          <%--  <p style="text-align:center;"><label>OR</label></p>--%>
                            <%--<div class="row" style="padding-bottom: 10px;">
                                 <div class="col-md-1 col-xs-12"></div>

                                <div class="col-md-2 col-xs-12">
                                    <strong>Road Name</strong><br />                                   
                                </div>                              
                               
                                <div class="col-md-6 col-xs-12">
                                    <asp:TextBox ID="txtroadnamesearch" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="SearchRoadMaster"
    MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
    TargetControlID="txtroadnamesearch" FirstRowSelected="false">
</cc1:AutoCompleteExtender>
                                </div>
                                <div class="col-md-1 col-xs-3">
                                    
                                    <asp:Button ID="btn_roadsearch" Text="Search" runat="server" OnClick="btn_roadsearch_Click" CssClass="btn btn-info" OnClientClick="javascript:ShowProgressBar()" />

                                </div>
                               
                            </div>--%>

                        </div>
                    </div>

                   



                    <%--   Search Area start--%>

                    <%-- <div class="row"  >
            <div class="col-md-2"></div>
             <div class="col-md-8">
                <fieldset>
                    <legend style="background-color:burlywood; color:white;">Search Here</legend>
                    <div class="col-sm-1"></div>
                    <div class="col-sm-2">
                        <label>Road Name</label>
                    </div>
                      <div class="col-sm-4">
                        <asp:DropDownList ID="ddl_search" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                     <div class="col-sm-2">
                     <asp:Button ID="btnsearch" runat="server" CssClass="btn-info" Width="80px" Text="Search" />
                    </div>
                </fieldset>
             </div>
           <div class="col-md-2"></div>
        </div><br />--%>

                    <%--  Search Area End--%>
                     <h4 style="text-align:center; font-weight:900; color:darkred;"> <asp:Label ID="lblerror" runat="server" Text="Record Not Found...." Visible="false"></asp:Label></h4>

                    <div class="container-fluid">
                        
                        <div class="row">

                            <div class="  table-responsive ">
                                <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">

                                    <asp:GridView ID="grdEistingRecord" CssClass="table table-striped table-bordered table-hover" 
                                        OnRowCreated="grdEistingRecord_RowCreated1" AllowPaging="true" runat="server"
                                        Width="100%" BorderColor="#999999" PageSize="10" AutoGenerateColumns="false"
                                         OnRowCommand="grdEistingRecord_RowCommand" 
                                        OnRowDataBound="grdEistingRecord_RowDataBound" DataKeyNames="ActionEdit,ActionDelete"
                                        OnPageIndexChanging="grdEistingRecord_PageIndexChanged" ShowFooter="true" ShowHeaderWhenEmpty="True" emptydatatext="No Record Found.">
                                        <Columns>


                                            <asp:TemplateField HeaderText="Sl.No." HeaderStyle-BackColor="#008abc" HeaderStyle-Width="3%">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Wing" HeaderStyle-BackColor="#008abc" HeaderStyle-Width="4%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtAgrNo" runat="server"
                                                        Text='<%# Eval("Wing") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Circle" HeaderStyle-BackColor="#008abc" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtcircle" runat="server"
                                                        Text='<%# Eval("Circle") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division" HeaderStyle-BackColor="#008abc" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtDivision" runat="server"
                                                        Text='<%# Eval("Division") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Road Type" HeaderStyle-BackColor="#008abc" HeaderStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtRoadType" runat="server"
                                                        Text='<%# Eval("description") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Road Name" HeaderStyle-BackColor="#008abc" HeaderStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtName_of_the_Road" runat="server"
                                                        Text='<%# Eval("Name_of_the_Road") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Length(km)" HeaderStyle-BackColor="#008abc" HeaderStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtNew_Total_Length_km" runat="server" 
                                                        onkeypress="return validate(event);" Text='<%# Eval("New_Total_Length_km") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-BackColor="#008abc" HeaderStyle-Width="6%">
                                                <ItemTemplate>

                                                  <%--  <asp:LinkButton ID="lnk_view" runat="server" CommandName="View" Font-Bold="true" ToolTip="Click Here To View" CommandArgument='<%#Eval("RoadId")%>'  >
                                        <i class="fa fa-eye" aria-hidden="true"  style="color:cornflowerblue"></i>
                                                    </asp:LinkButton>&nbsp;&nbsp;--%>

                                                    <a href='ViewRoadMaster.aspx?roadid=<%#Eval("RoadID")%>' target="_blank"><i class="fa fa-eye" aria-hidden="true"></i></a>&nbsp;&nbsp;
                                                    <%-- <a href='ViewRoadDetails.aspx?roadid=<%#Eval("RoadID")%>' target="_blank"><i class="fa fa-eye" aria-hidden="true"></i></a>&nbsp;&nbsp;--%>

                                <%--    <asp:LinkButton ID="lnk_update" runat="server" ToolTip="Click Here To Update" CommandName="Modify" Font-Bold="true" OnClientClick="return PostToNewWindow();"
                                         CommandArgument='<%#Eval("RoadId")%>' Visible='<%# (Session["UserID"].ToString()=="Admin1" || Session["Role"].ToString()=="SUPERADMIN" || Session["ActionEdit"].ToString() == "Y" || Session["Role"].ToString()=="DIVADM")?true:false %>'>
                                          <i class="fa fa-pencil-square-o" aria-hidden="true" style="color:darkgreen"></i>
                                    </asp:LinkButton>&nbsp;&nbsp;
                                                   --%>
                                                    
                                                    

                                  <%--  <asp:LinkButton ID="lnk_delete" runat="server"   ToolTip="Click Here To Delete" OnClientClick="javascript:return confirm('Are You Sure Want To Delete?');" 
                                        CommandName="remove" Font-Bold="true" CommandArgument='<%#Eval("RoadId")%>' Visible='<%# (Session["UserID"].ToString()=="Admin1" || Session["UserID"].ToString()=="SUPERADMIN" || Session["ActionDelete"].ToString() == "Y")?true:false %>' >
                                     <i class="dropdown-icon  fa fa-trash-alt" style="color:red"></i><span></span>
                                    </asp:LinkButton>--%>

                                                    
                                    <asp:LinkButton ID="lnk_update" runat="server" ToolTip="Click Here To Update" CommandName="Modify" Font-Bold="true" OnClientClick="return PostToNewWindow();"
                                         CommandArgument='<%#Eval("RoadId")%>'>
                                          <i class="fa fa-pencil-square-o" aria-hidden="true" style="color:darkgreen"></i>
                                    </asp:LinkButton>&nbsp;&nbsp;
                                                   
                                                    
    <asp:LinkButton ID="lnk_delete" runat="server"   ToolTip="Click Here To Delete" OnClientClick="javascript:return confirm('Are You Sure Want To Delete?');" 
                                        CommandName="remove" Font-Bold="true" CommandArgument='<%#Eval("RoadId")%>' >
                                     <i class="dropdown-icon  fa fa-trash-alt" style="color:red"></i><span></span>
                                    </asp:LinkButton>
                                                    

                                



                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>


                                      
                                            <asp:TemplateField HeaderText="Good" HeaderStyle-BackColor="#008abc" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_Good" runat="server" 
                                                        onkeypress="return validate(event);" Text='<%# Eval("Good") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fair" HeaderStyle-BackColor="#008abc" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_Fair" runat="server" 
                                                        Text='<%# Eval("Fair") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Average" HeaderStyle-BackColor="#008abc" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_Average" runat="server" 
                                                        Text='<%# Eval("Average") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Bad" HeaderStyle-BackColor="#008abc" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_Bad" runat="server" 
                                                        Text='<%# Eval("Bad") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Single Lane" HeaderStyle-BackColor="#008abc" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_SingleLane" runat="server" 
                                                        Text='<%# Eval("SingleLane") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Intermediate" HeaderStyle-BackColor="#008abc" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_Intermediate" runat="server" 
                                                        Text='<%# Eval("Intermediate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="2 Lane" HeaderStyle-BackColor="#008abc" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_twolane" runat="server" 
                                                        Text='<%# Eval("twolane") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="More than width seven" HeaderStyle-BackColor="#008abc" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_morethanwidthseven" runat="server" 
                                                        Text='<%# Eval("morethanwidthseven") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-BackColor="#008abc" Visible="False" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_Remarks" runat="server" 
                                                        Text='<%# Eval("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                         
                                        </Columns>


                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <HeaderStyle BackColor="#008abc" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Right" />
                                        <%-- <RowStyle BackColor="White" />--%>
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#808080" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#383838" />
                                    </asp:GridView>

                                </asp:Panel>
                                <p style="font-weight: 700; color: brown;">
                                    <asp:Label ID="lbltotalcount" runat="server" Visible="true"></asp:Label></p>
                            </div>
                        </div>
                    </div>

                    <%-- 
        <div class="loading" align="center">
    Loading. Please wait.<br />
    <br />
    <img src="loader.gif" alt="" />
</div>--%>

                    <%--<div ID="dvProgressBar" style="float:left;visibility: hidden;" >
      <img src="../images/loader.gif" style="width:80px; height:auto" />  please wait...
  </div>--%>
                </div>
            </div>
        </div>





    </div>
</asp:Content>
