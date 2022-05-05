<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true" CodeFile="ViewRoadMaster.aspx.cs" Inherits="RCDPMISNEW_ADM_ViewRoadMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        function goBack() {
            window.history.back();
        }
    </script>

    <script>
        function CloseWindow() {
            window.close();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">
     
        <div class="row">
            <%-- <p style="float:right; padding-top:5px;"><asp:Button ID="lnkback" runat="server" OnClick="lnkback_Click" Text="Back" Width="150px" CssClass="btn btn-primary btn " /></p>--%>
             <p style="float:right; padding-top:5px;">
               <%--  <button onclick="window.history.back()">
                     <img src="/RCDPMISNEW/images/back_image.png"  width="150px"  alt="a" />
                 </button>--%>
                 <asp:ImageButton ID="lnkback" runat="server"  OnClick="lnkback_Click" Width="45px"   ImageUrl="~/RCDPMISNEW/images/close.png"  />
               <%--  <asp:Button ID="btnCancle" runat="server" Text="Close" UseSubmitBehavior="true" Font-Bold="true" CssClass="btn-danger" Width="80px"  OnClick="btnCancle_Click"
                            ValidationGroup="s" Visible="true" />--%>
           
             

             </p>
           <%-- <div class="col-sm-12">
                <h4 style="text-align: center; color: blue;">View Road Master Details
                   
                </h4>
            </div>--%>
        </div>
       


    </div>
   <%-- <hr style="border: 1px solid black" />--%>
     <div class="panel panel-primary">
      <div class="panel-heading" style="text-align:center; color:white; font-weight:700; font-size:x-large">View Road Master </div>
    <div class="container-fluid">


        <div class="row" style="padding-top: 10px;">
            <div class="col-md-1 col-xs-12">
                <label>Wings:</label>
            </div>
            <div class="col-md-2 col-xs-12">
                <%--<asp:Label ID="lblwing" Text="Wing" runat="server"></asp:Label>--%>
                 <asp:TextBox ID="txtwing" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-1 col-xs-12">
                <label>Circle:</label>
            </div>
            <div class="col-md-2 col-xs-12">
               <%-- <asp:Label ID="lblcircle" Text="Circle" runat="server"></asp:Label>--%>
                 <asp:TextBox ID="txtcircle" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-1 col-xs-12">
                <label>Division:</label>
            </div>
            <div class="col-md-2 col-xs-12">
              <%--  <asp:Label ID="lbldivision" Text="Division" runat="server"></asp:Label>--%>
                  <asp:TextBox ID="txtdivision" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-1 col-xs-12">
                <%--<asp:Label ID="lbl_rdtype" runat="server" Text="Road Type:"></asp:Label>--%>
                  <label>Road Type:</label>
            </div>
            <div class="col-md-2 col-xs-12">
                <%--<asp:Label ID="lblroadtype" Text="Road Type" runat="server"></asp:Label>--%>
                 <asp:TextBox ID="txtroadtype" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="row" style="padding-top: 10px;">
             <div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_rdtype" runat="server" Text="SubRoad Type:"></asp:Label>
                 
            </div>
            <div class="col-md-2 col-xs-12">
                 <asp:TextBox ID="txt_subroadtype" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>



            <div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_notr" runat="server" Text="Road Name:"></asp:Label>
            </div>
             <div class="col-md-6 col-xs-12">
                <asp:TextBox ID="txt_nameoftheroad" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_ntlk" runat="server" Text="Total Length km:"></asp:Label>
            </div>
            <div class="col-md-1 col-xs-12">
                <asp:TextBox ID="txt_ntlength_km" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>


            </div>

         <div class="row" style="padding-top: 10px;">
             <div class="col-md-2 col-xs-12">
                <asp:Label ID="lblconversionifany" runat="server" Text="Road Conversion(If Any):"></asp:Label>
            </div>
            <div class="col-md-3 col-xs-12">      
                 <asp:RadioButtonList ID="radioyesno" CssClass="FormatRadioButtonList" runat="server" RepeatDirection="Horizontal" Enabled="false" >
                                     <asp:ListItem Value="2" >No </asp:ListItem>
                                    <asp:ListItem Value="1">Yes &nbsp;&nbsp;</asp:ListItem>
                                                                  
                                </asp:RadioButtonList><br />
            </div>

             <div class="col-md-2 col-xs-12">
                                
                                 <asp:Label ID="lblconversiontype" runat="server" Text="Conversion Type:" Font-Bold="true" Visible="false"></asp:Label>
                              
                            </div>
                            <div class="col-md-4 col-xs-12">
                                <asp:RadioButtonList ID="radioroadconversion" CssClass="FormatRadioButtonList" runat="server" RepeatDirection="Horizontal" Visible="false"
                                     Enabled="false" >
                                     <asp:ListItem Value="1" >Partial Conversion </asp:ListItem>
                                    <asp:ListItem Value="2">Full Conversion &nbsp;&nbsp;</asp:ListItem> 
                                                                      
                                </asp:RadioButtonList><br />
                            </div>

         </div>


        <asp:Panel ID="pnlconvertedroaddetails" runat="server" Visible="false">
          <div class="row" style="padding-top: 10px;">
               <FIELDSET>  
                <legend >Converted Road Details</legend> 
                
                <div class="col-md-2 col-xs-12">
                <asp:Label ID="lbl_converted_Road_length" runat="server" Text="Converted Road Length km:"></asp:Label>
            </div>
            <div class="col-md-1 col-xs-12">
                <asp:TextBox ID="txt_converted_total_length" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
               <%--<div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_conversiontype" runat="server" Text="Conversion Type:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txt_conversion_type" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>--%>

               <div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_approval_letter" runat="server" Text="Approval Letter:"></asp:Label>
            </div>
            <div class="col-md-4 col-xs-12">
                <%--<asp:TextBox ID="lblApprovalLetter" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>--%>
                 <%--<a href="viewuploaddocument.aspx" target="_blank"><asp:Label ID="lblfileuploadpath" runat="server"></asp:Label> </a>--%>
                <asp:Button ID="btnapprovalletter" runat="server" CssClass="btn btn-link" OnClick="btnapprovalletter_Click" />
              
            </div>
                </FIELDSET>

              </div>

        </asp:Panel>
        <div class="row" style="padding-top: 10px;">
          
            <FIELDSET>  
                <legend >Road Conditions</legend> 
                  <div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_good" runat="server" Text="Good:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txt_good" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
                 <div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_fair" runat="server" Text="Fair:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txt_fair" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
                 <div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_average" runat="server" Text="Average:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txt_average" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
                  <div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_bad" runat="server" Text="Bad:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txt_bad" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>


                </FIELDSET>
            
         
        </div>

         <asp:Panel ID="pnlconvertedroadcondition" runat="server" Visible="false">
        <div class="row" style="padding-top: 10px;">
          
            <FIELDSET>  
                <legend >Converted Condition of the Road</legend> 
                  <div class="col-md-1 col-xs-12">
                <asp:Label ID="lblcgood" runat="server" Text="Converted Good:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtcgood" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
                 <div class="col-md-1 col-xs-12">
                <asp:Label ID="lblcfair" runat="server" Text=" ConvertedFair:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtcfair" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
                 <div class="col-md-1 col-xs-12">
                <asp:Label ID="lblcavg" runat="server" Text="Converted Average:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtcavg" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
                  <div class="col-md-1 col-xs-12">
                <asp:Label ID="lblcbad" runat="server" Text="Converted Bad:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtcbad" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>



                </FIELDSET>
            
         
        </div>

              </asp:Panel>



                <div class="row" style="padding-top: 10px;">

                      <FIELDSET>  
                <legend >Lane Width</legend> 
               <div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_SingleLane" runat="server" Text="SingleLane:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txt_SingleLane" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>


               <div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_Intermediate" runat="server" Text="Intermediate:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txt_Intermediate" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
              <div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_twolane" runat="server" Text="Two Lane:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txt_twolane" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
                 <div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_morethanwithseven" runat="server" Text="More Than Seven:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txt_morethanwithseven" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
             
</FIELDSET>


        </div>


        <asp:Panel ID="pnlconvertedlanwidth" runat="server" Visible="false">

        <div class="row" style="padding-top: 10px;">

           <FIELDSET>  
                <legend >Converted Lane Width</legend> 
               <div class="col-md-1 col-xs-12">
                <asp:Label ID="lblcsingle" runat="server" Text="Converted SingleLane:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtcsingle" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>


               <div class="col-md-1 col-xs-12">
                <asp:Label ID="lblcinter" runat="server" Text="Converted Intermediate:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtcinter" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
              <div class="col-md-1 col-xs-12">
                <asp:Label ID="lblc2lane" runat="server" Text="Converted Two Lane:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtc2lane" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
                 <div class="col-md-1 col-xs-12">
                <asp:Label ID="lblcmorethan7" runat="server" Text="Converted More Than Seven:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtcmorethan7" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
             
</FIELDSET>


        </div>

         </asp:Panel>

          <%--<div class="row" >
               <div class="col-md-1 col-xs-12">
                <asp:Label ID="lbl_remarks" runat="server" Text="Remarks:"></asp:Label>
            </div>
            <div class="col-md-4 col-xs-12">
                <asp:TextBox ID="txt_remarks" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
                 <div class="col-md-2 col-xs-12 ">
                <asp:Label ID="lbl_change_remarks" runat="server" Text="Change Remarks:"></asp:Label>
            </div>
            <div class="col-md-4 col-xs-12">
                <asp:TextBox ID="txt_change_remarks" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

          </div>--%>

        


        
       <br />


         <div class="row" style="padding-top: 10px;">
               <FIELDSET>  
                <legend >Reason For Bad & Fair Condition of Road</legend> 
            <div class="col-md-1 col-xs-12">
                <asp:Label ID="Label1" runat="server" Text="Reason:"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtreason" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

              <div class="col-md-1 col-xs-12">
                <asp:Label ID="lblotherremarks" runat="server" Text="Other Reason:" Visible="false"></asp:Label>
            </div>
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtotherreason" runat="server"  CssClass="form-control" Enabled="false" Visible="false"></asp:TextBox>
            </div>

             
           </FIELDSET>
         
        </div>
       <br />
          <div class="row" style="padding-top: 10px;">
                <FIELDSET>  
                     <legend >Issue of attention with HQ/Chief Office</legend> 
                     <div class="col-md-2 col-xs-12">
                <asp:Label ID="Label3" runat="server" Text="Description of issue:"></asp:Label>
            </div>
            <div class="col-md-8 col-xs-12">
                <asp:TextBox ID="txtdescription" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

                </FIELDSET>
          </div><br />
        


    </div>

         </div>

    <br />
    

        <asp:Panel ID="pnlroadconversion" runat="server">

            <div class="row">
                  <asp:Label ID="lbl_initial" runat="server" style="color:maroon; font-weight:bold" Visible="true">Initial Total Road Length:-</asp:Label> <asp:Label ID="lbl_TotalLength" runat="server" Visible="true" ></asp:Label>
            </div>
            
             <div class="row">
                  
                            <div class="table-responsive">
                                <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">      
                                   <p style="text-align:center; font-weight:700; color:maroon;"> <asp:Label ID="lblerror" runat="server" Text="No Record Found.." Visible="false"></asp:Label>     </p>
                                                
                                    <asp:GridView ID="grdEistingRecordConvert" CssClass="table table-striped table-bordered table text-center" 
                                        runat="server"
                                        Width="100%"   AutoGenerateColumns="false"                                      
                                       ShowHeaderWhenEmpty="True" EmptyDataText="No records Found..." EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-ForeColor="#990000">
                                        
                                        <Columns>

                                            
                                            <asp:TemplateField HeaderText="Sl.No."  HeaderStyle-BackColor="#008abc"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <ItemStyle />
                                                 <HeaderStyle Font-Bold="false" Width="1%" />
                                            </asp:TemplateField>
                                          <%--  <asp:TemplateField HeaderText="RoadId" HeaderStyle-BackColor="white" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger"  HeaderStyle-BorderColor="black" HeaderStyle-Width="4%">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtAgrNo" runat="server"
                                                        Text='<%# Eval("RoadId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>--%>

                                             <asp:TemplateField HeaderText="Road Conversion Remarks"  HeaderStyle-BackColor="#008abc"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
                                                <ItemTemplate>
                                                    <asp:Label ID="txtDivision" runat="server"
                                                        Text='<%# Eval("RoadConversionRemarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                 <HeaderStyle Font-Bold="true" Font-Size="small" Width="12%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Conversion Type"  HeaderStyle-BackColor="#008abc"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
                                                <ItemTemplate>
                                                    <asp:Label ID="txtDivision" runat="server"
                                                        Text='<%# Eval("ConvertedName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                 <HeaderStyle Font-Bold="true" Font-Size="small" Width="12%" />
                                            </asp:TemplateField>

                                           

                                              <asp:TemplateField HeaderText="Total Length"  HeaderStyle-BackColor="#008abc"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
                                                <ItemTemplate>
                                                    <asp:Label ID="txtcircle" runat="server"
                                                        Text='<%# Eval("Totallength") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                   <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Conv. Good"  HeaderStyle-BackColor="#008abc"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtcircle" runat="server"
                                                        Text='<%# Eval("ConvertedGood") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                 <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
                                            </asp:TemplateField>

                                               <asp:TemplateField HeaderText="Conv. Bad"  HeaderStyle-BackColor="#008abc"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
                                                <ItemTemplate>
                                                    <asp:Label ID="txtcircle" runat="server"
                                                        Text='<%# Eval("ConvertedBad") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Conv. Fair"  HeaderStyle-BackColor="#008abc" HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
                                                <ItemTemplate>
                                                    <asp:Label ID="txtcircle" runat="server"
                                                        Text='<%# Eval("ConvertedFair") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Conv. Average"  HeaderStyle-BackColor="#008abc"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
                                                <ItemTemplate>
                                                    <asp:Label ID="txtcircle" runat="server"
                                                        Text='<%# Eval("ConvertedAverage") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Conv. Single"  HeaderStyle-BackColor="#008abc"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
                                                <ItemTemplate>
                                                    <asp:Label ID="txtcircle" runat="server"
                                                        Text='<%# Eval("ConvertedSingle") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Conv. Intermediate"  HeaderStyle-BackColor="#008abc" HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
                                                <ItemTemplate>
                                                    <asp:Label ID="txtcircle" runat="server"
                                                        Text='<%# Eval("ConvertedIntermediate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Conv. 2Lane"  HeaderStyle-BackColor="#008abc"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
                                                <ItemTemplate>
                                                    <asp:Label ID="txtcircle" runat="server"
                                                        Text='<%# Eval("ConvertedTwoLane") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Conv. More Than 7"  HeaderStyle-BackColor="#008abc"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
                                                <ItemTemplate>
                                                    <asp:Label ID="txtcircle" runat="server"
                                                        Text='<%# Eval("ConvertedMoreThanSeven") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Document"  HeaderStyle-BackColor="#008abc" HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="roadletter" runat="server" Target="_blank" NavigateUrl='<%# "~/RCDPMISNEW/Approval_latter/"+ Eval("RoadConversionLetter") %>' Text="Document" ></asp:HyperLink>
                                                   <%-- <asp:Label ID="txtcircle" runat="server"
                                                        Text='<%# Eval("RoadConversionLetter") %>'></asp:Label>--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                  <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
                                            </asp:TemplateField>
                                            
                                            
                                        </Columns>
                                        

                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <HeaderStyle BackColor="white" Font-Bold="True" ForeColor="black" />
                                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Right" />
                                     
                                        <SelectedRowStyle BackColor="#000099"  ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#808080" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#383838" />
                                      
                                    </asp:GridView>

                                </asp:Panel>
                              
                            </div>
                        </div>
           

        </asp:Panel>

</asp:Content>

