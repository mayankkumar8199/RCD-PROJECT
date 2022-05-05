<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true" CodeFile="RoadMasterReport.aspx.cs" Inherits="RCDPMISNEW_ADM_RoadMasterReport" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid" style="padding-top: 12px;">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-weight: 700; font-size: x-large">Road Construction Department
                    <h4>Road Statistics</h4>
                </div>
                <div class="panel-body">


                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-12 col-xs-12">
                            <%--<p style="float:right"><asp:ImageButton ID="btn_add_contractor" runat="server"    Width="50px"   ImageUrl="~/RCDPMISNEW/images/AddProject1.png" /></p>--%>
                        </div>
                    </div>
                    <div class="row" style="padding-bottom: 10px; padding-top: 7px;">

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
                            <asp:DropDownList ID="ddldivision"  runat="server"
                                CssClass="form-control" >
                             
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2 col-xs-12">
                            <strong>Road Type</strong><br />
                            <asp:DropDownList ID="ddl_roadtype"  runat="server"
                                CssClass="form-control"
                              >
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-1 col-xs-3">
                            <strong>&nbsp;</strong><br />
                            <asp:Button ID="btn_view" Text="View" runat="server" OnClick="btn_view_Click" CssClass="btn btn-info" OnClientClick="javascript:ShowProgressBar()" />

                        </div>
                        <div class="col-md-1 col-xs-3">
                            <%--<strong>&nbsp;</strong>--%></br>
             
                  <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click"
                      runat="server" ImageUrl="~/RCDPMISNEW/images/refresh.png" Width="25px" Height="25px"></asp:ImageButton>

                        </div>
                        <div class="col-md-1">
                            <%-- <p style="padding-top:15px;">  <asp:Button ID="btn_export_to_excel" runat="server" Text="Export To Excel" OnClick="btn_export_to_excel_Click" CssClass="btn-warning" /></p>--%>
                            <p style="float: right; padding-top: 5px;">
                                <asp:ImageButton ID="btn_export_to_excel" runat="server" OnClick="btn_export_to_excel_Click" Width="100px" ImageUrl="~/RCDPMISNEW/images/Excel_img.png" /></p>
                        </div>
                        <div class="col-md-1">
                          <%--  <asp:ImageButton ID="add_RoadMaster" runat="server" OnClick="add_RoadMaster_Click" Width="50px" ImageUrl="~/RCDPMISNEW/images/AddProject1.png" />--%>
                        </div>

                    </div>

                   <h4 style="text-align:center; font-weight:900; color:darkred;"> <asp:Label ID="lblerror" runat="server" Text="Record Not Found...." Visible="false"></asp:Label></h4>

                  

                    <div class="container-fluid">
                        <div class="row">

                            <div class="  table-responsive ">
                                <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">
<%--                                    <asp:GridView ID="grdEistingRecord" CssClass="table table-striped table-bordered table-hover" 
                                        OnRowCreated="grdEistingRecord_RowCreated1" AllowPaging="true" runat="server"
                                        Width="100%" BorderColor="#999999" PageSize="10" AutoGenerateColumns="false"
                                        OnRowDataBound="grdEistingRecord_RowDataBound"
                                        OnPageIndexChanging="grdEistingRecord_PageIndexChanged" ShowFooter="true">--%>
                                   <%-- <table class="table">
                                        <tr>
                                            <td class="text-center text-uppercase"><b> Road Construction Department </b></td>
                                        </tr>
                                    </table>--%>
                               
                                 <%--   <table border="1" style="width:100%;border-collapse:collapse;" class="table table-striped table-bordered table text-center" cellspacing="0" rules="all">
                                        <tr style="color:Black;background-color:White;font-weight:bold; width:100%">
                                            <td style="width:50%" colspan="7" align="center">
                                                <p> Road Construction Department , Road Statistics </p>
                                            </td>
                                            <td colspan="4">
                                                <p></p>
                                            </td>
                                            <td style="width:25%" colspan="4" align="center"><p>Lane Width (m) </p></td>
                                            <td style="width:10%"></td>
                                         
                                        </tr>
                                        <tr style="color:Black;background-color:White;font-weight:bold;width:100%">
                                            <td style="width:50%" colspan="7"><p></p></td>
                                            <td style="width:21%" colspan="4" align="center"> <p> Condition Of Road (in KM) </p></td>
                                            <td style="width:5%" align="center"> <p> Single Lane 3.75m width </p></td>
                                            <td style="width:5%" align="center"> <p> Interme- diate Lane 5.50m width</p> </td>
                                            <td style="width:5%" align="center"> <p> 2 Lane 7.00m width </p></td>
                                            <td style="width:5%" align="center"> <p> More than 7.00m width </p></td>
                                            <td></td>
                                        </tr>

                                    </table>--%>

                            <%--   <h4 style="text-align:center; color:darkred; font-weight:700;"><asp:Label ID="lblerror" Visible="false" Text="No record found" runat="server"></asp:Label></h4>--%>
                                    <asp:GridView ID="grdEistingRecord" CssClass="table table-striped table-bordered table text-center" 
                                        OnRowCreated="grdEistingRecord_RowCreated1" runat="server"
                                        Width="100%"   AutoGenerateColumns="false"
                                        OnRowDataBound="grdEistingRecord_RowDataBound"
                                        ShowFooter="true" OnDataBound="grdEistingDataBound" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found..." EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-ForeColor="#990000">

                                        <Columns>


                                            <asp:TemplateField HeaderText="Sl.No." HeaderStyle-BackColor="white" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger" HeaderStyle-BorderColor="black" HeaderStyle-Width="3%">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>

                                          <%--  <asp:TemplateField HeaderText="Wing" HeaderStyle-BackColor="white" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger"  HeaderStyle-BorderColor="black" HeaderStyle-Width="4%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtAgrNo" runat="server"
                                                        Text='<%# Eval("Wing") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>--%>

                                         <%--   <asp:TemplateField HeaderText="Circle" HeaderStyle-BackColor="white" HeaderStyle-Font-Size="Larger" HeaderStyle-BorderColor="black" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtcircle" runat="server"
                                                        Text='<%# Eval("Circle") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Division" HeaderStyle-BackColor="white" HeaderStyle-Font-Size="Larger" HeaderStyle-BorderColor="black" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtDivision" runat="server"
                                                        Text='<%# Eval("Division") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Road Type" HeaderStyle-BackColor="white" HeaderStyle-Font-Size="Larger" HeaderStyle-BorderColor="black" HeaderStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtRoadType" runat="server"
                                                        Text='<%# Eval("description") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Road Name" HeaderStyle-BackColor="white" HeaderStyle-Font-Size="Larger" HeaderStyle-BorderColor="black" HeaderStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtName_of_the_Road" runat="server"
                                                        Text='<%# Eval("Name_of_the_Road") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Length (km)" HeaderStyle-BackColor="white" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Bold="true" HeaderStyle-BorderColor="black" HeaderStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtNew_Total_Length_km" runat="server" 
                                                        onkeypress="return validate(event);" Text='<%# Eval("New_Total_Length_km") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                  

                                      
                                            <asp:TemplateField HeaderText="Good (Pots less than 2% of the total length)" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black"
                                                HeaderStyle-Width="2%" >
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_Good" runat="server" 
                                                        onkeypress="return validate(event);" Text='<%# Eval("Good") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fair (Pots less than 5% of the total length)" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_Fair" runat="server" 
                                                        Text='<%# Eval("Fair") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Average (Pots 
                                                 Between 5% to 15% of the total length)" HeaderStyle-BackColor="white" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Bold="true" HeaderStyle-BorderColor="black">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_Average" runat="server" 
                                                        Text='<%# Eval("Average") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Bad ( Pots more than 15% of the total length)" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_Bad" runat="server" 
                                                        Text='<%# Eval("Bad") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>



                                               <asp:TemplateField HeaderText="Total Length (KM)" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger" HeaderStyle-BackColor="white"  HeaderStyle-BorderColor="black" >
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_total" runat="server" 
                                                        Text='<%# Eval("totalgfba") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>




                                            <asp:TemplateField HeaderText=" Single Lane 3.75m width Length (Km)" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_SingleLane" runat="server" 
                                                        Text='<%# Eval("SingleLane") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Intermediate Lane 5.50m width Length (Km)" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_Intermediate" runat="server" 
                                                        Text='<%# Eval("Intermediate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" 2 Lane 7.00m width Length (Km)" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_twolane" runat="server" 
                                                        Text='<%# Eval("twolane") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="More than 7.00m width Length (Km)" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger" HeaderStyle-BackColor="white" HeaderStyle-BorderColor="black">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_morethanwidthseven" runat="server" 
                                                        Text='<%# Eval("morethanwidthseven") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>


                                            




                                           
                                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger" HeaderStyle-BackColor="white"  HeaderStyle-BorderColor="black" >
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_Remarks" runat="server" 
                                                        Text='<%# Eval("RoadConversionRemarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                         
                                        </Columns>


                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                       <%-- <FooterStyle BackColor="#CCCCCC" />--%>
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
                               <%-- <p style="font-weight: 700; color: brown;">--%>
                                   <%-- <asp:Label ID="lbltotalcount" runat="server"></asp:Label></p>--%>
                            </div>
                        </div>
                    </div>

        
                </div>
            </div>
        </div>





    </div>
</asp:Content>

