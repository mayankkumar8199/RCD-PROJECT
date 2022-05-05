<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true" CodeFile="UpdateProjectEntry.aspx.cs" Inherits="RCDPMISNEW_Common_UpdateProjectEntry" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar" Namespace="RJS.Web.WebControl"
    TagPrefix="rjs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
    <div class="container-fluid" style="padding-top:12px;">


  <div class="panel-group">
    <div class="panel panel-primary">
      <div class="panel-heading" style="text-align:center; font-weight:700; font-size:x-large">Update Project Entry</div>
      <div class="panel-body">
        <div class="row" style="padding-top:10px;">

             <div class="col-md-2 col-xs-4">
              <label>Financial Year*:</label>
            </div>
            <div class="col-md-2 col-xs-4">
                 <asp:DropDownList ID="ddl_fyear" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <div class="col-md-2 col-xs-12">
                <label>Wings:</label>
            </div>
            <div class="col-md-2 col-xs-12">
               <asp:DropDownList ID="ddl_wings" runat="server"  CssClass="form-control"  Enabled="false" Font-Bold="true" ForeColor="White" BackColor="#626567" ></asp:DropDownList>
            </div>
             <div class="col-md-2 col-xs-12">
                <label>Circle:</label>
            </div>
            <div class="col-md-2  col-xs-12">
                <asp:DropDownList ID="ddl_circle" runat="server"  CssClass="form-control"  Enabled="false" Font-Bold="true" ForeColor="White" BackColor="#626567" ></asp:DropDownList>
            </div>
             
        </div>

           <div class="row" style="padding-top:10px;">

               <div class="col-md-2  col-xs-12">
                <label>	Division:</label>
            </div>
            <div class="col-md-2  col-xs-12">
               <asp:DropDownList ID="ddl_division" runat="server"  CssClass="form-control" Enabled="false" Font-Bold="true" ForeColor="White" BackColor="#626567" ></asp:DropDownList>
            </div>

               <div class="col-md-2 col-xs-12">
                   <asp:Label ID="lbl_head" runat="server" Text="Head Name*:"></asp:Label>
               </div>
               <div class="col-md-2 col-xs-12">
                   <asp:DropDownList ID="ddl_head" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddl_head_SelectedIndexChanged"  CssClass="form-control"></asp:DropDownList>
               </div>

                <div class="col-md-2 col-xs-12">
                   <asp:Label ID="lbl_subhead" runat="server" Text="Sub-Head*:"></asp:Label>
               </div>
               <div class="col-md-2 col-xs-12">
                   <asp:DropDownList ID="ddl_subhead" runat="server" CssClass="form-control"></asp:DropDownList>
               </div>
                
               </div>

         <div class="row" style="padding-top:10px;">

             <div class="col-md-2 col-xs-12">
                   <asp:Label ID="lbl_project" runat="server" Text="Project*:"></asp:Label>
               </div>
               <div class="col-md-6 col-xs-12">
                  <asp:TextBox ID="txt_project" runat="server" CssClass="form-control"></asp:TextBox>
               </div>


             <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label1" runat="server" Text="Road Type*:"></asp:Label>
               </div>
               <div class="col-md-2 col-xs-12">
                   <asp:DropDownList ID="ddl_roadtype" runat="server" AutoPostBack="true" 
                       OnSelectedIndexChanged="ddl_roadtype_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
               </div>

              
          
             </div>

           <div class="row" style="padding-top:10px;">

                 <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label2" runat="server" Text="	Road Name*:"></asp:Label>
               </div>
               <div class="col-md-10 col-xs-12">
                   <asp:DropDownList ID="ddl_roadname" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_roadname_SelectedIndexChanged"></asp:DropDownList>
               </div>
           </div>


         <div class="row" style="padding-top:10px;">

                 <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label3" runat="server" Text="Length of Sanction Road*(in km):"></asp:Label>
               </div>
               <div class="col-md-2 col-xs-12">
                   <asp:TextBox ID="txt_lengthofroad" runat="server" placeholder="(in km)" CssClass="form-control"></asp:TextBox>
               </div>
             <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label4" runat="server" Text="Nature Of Work*:"></asp:Label>
               </div>
               <div class="col-md-2 col-xs-12">
                   <asp:DropDownList ID="ddl_natureofwork" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_natureofwork_SelectedIndexChanged">
                      
                   </asp:DropDownList>
               </div>
             <div class="col-md-2 col-xs-12">
                   <asp:Label ID="lbl_work_type" runat="server" Text="Type:" Visible="true" ></asp:Label>
               </div>
              <div class="col-md-2 col-xs-12">
                   <asp:DropDownList ID="ddl_tyoe_of_work" runat="server"  CssClass="form-control" Visible="true" AutoPostBack="true"  OnSelectedIndexChanged="ddl_tyoe_of_work_SelectedIndexChanged" >
                      
                   </asp:DropDownList>
               </div>
          
             </div>

          <div class="row" style="padding-top:10px;">

                <div class="col-md-2 col-xs-12">
                   <asp:Label ID="lbl_sub_type" runat="server" Text="Sub-Type:" Visible="true" ></asp:Label>
               </div>
              <div class="col-md-2 col-xs-12">
                   <asp:DropDownList ID="ddl_sub_type" runat="server" CssClass="form-control" Visible="true"   ></asp:DropDownList>
               </div>


             <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label5" runat="server" Text="Administrative Approval Reference No.*:"></asp:Label>
                 
               </div>
               <div class="col-md-2 col-xs-12">
                   <asp:TextBox ID="txt_adaproval" runat="server" CssClass="form-control"></asp:TextBox>
               </div>

                <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label6" runat="server" Text="	Administrative Approval Amount*(in Lakh):"></asp:Label>
               </div>
               <div class="col-md-2 col-xs-12">
                  <asp:TextBox ID="txt_admaprovalamount" runat="server" CssClass="form-control" placeholder="(In Lakh)"></asp:TextBox>
               </div>
            
             </div>
         <div class="row" style="padding-top:10px;">

                <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label7" runat="server" Text="Administrative Approval Date*:"></asp:Label>
               </div>
               <div class="col-md-2 col-xs-12">
                   <asp:TextBox ID="txt_admin_approval_date" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
               </div>
              <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label9" runat="server" Text="Start date*:"></asp:Label>
               </div>
              <div class="col-md-2 col-xs-12">
                   <asp:TextBox ID="txt_strtdate" runat="server" CssClass="form-control" TextMode="date"></asp:TextBox>
               </div>
              <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label10" runat="server" Text="End date*:"></asp:Label>
               </div>
              <div class="col-md-2 col-xs-12">
                   <asp:TextBox ID="txt_enddate" runat="server" CssClass="form-control" TextMode="date"></asp:TextBox>
               </div>
          
             </div>

         <div class="row" style="padding-top:10px;">
                <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label11" runat="server" Text="Agreement Amount :(In Lakh)"></asp:Label>
               </div>
              <div class="col-md-2 col-xs-12">
                   <asp:TextBox ID="txt_aggrment_amount" runat="server"  CssClass="form-control"></asp:TextBox>
               </div>
              <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label12" runat="server" Text="Add Contractor:"></asp:Label>
               </div>
              <div class="col-md-2 col-xs-12">
                  <asp:DropDownList ID="ddl_conductor" runat="server" CssClass="form-control"></asp:DropDownList>
               </div>
        
               <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label13" runat="server" Text="Work Program Submitted:"></asp:Label>
               </div>
              <div class="col-md-2 col-xs-12">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Text="Yes"  Value="1"></asp:ListItem>
            <asp:ListItem Text="No" Value="0"></asp:ListItem>
        </asp:RadioButtonList>
               </div>
             

             </div>

         <div class="row" style="padding-top:10px;">
              <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label14" runat="server" Text="Status:"></asp:Label>
               </div>
              <div class="col-md-2 col-xs-12">
                  <asp:DropDownList ID="ddl_status" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddl_status_SelectedIndexChanged" CssClass="form-control" 
                      ></asp:DropDownList>
               </div>
               <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label15" runat="server" Text="Completion Date :" Visible="false"></asp:Label>
               </div>
              <div class="col-md-2 col-xs-12">
                 <asp:TextBox ID="txt_completiondate" runat="server"  CssClass="form-control" TextMode="date" Visible="false"></asp:TextBox>
               </div>
             <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label16" runat="server" Text="Completion Certificate :" Visible="false"></asp:Label>
               </div>
              <div class="col-md-2 col-xs-12">
                   <asp:FileUpload  ID="file_upload" accept=".pdf" runat="server"  Visible="false" CssClass="form-control" />
                  
                    <asp:HyperLink ID="lnkfilecompletioncertificate" runat="server" Visible="false">View</asp:HyperLink>
               </div>

              
             </div>
               <div class="row" style="padding-top:10px;">
              <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label8" runat="server" Text="Extension Of Date 1:"></asp:Label>
               </div>
              <div class="col-md-1 col-xs-12">
                  <asp:TextBox ID="txtExtensiondate1" runat="server"  CssClass="form-control" Width="125px"  Visible="true"></asp:TextBox>
                  </div>
                   <div class="col-md-1 col-xs-12">
                    <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="txtExtensiondate1" Format="dd mmm yyyy" />
               </div>
               <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label17" runat="server" Text="Extension Of Date 2: :" Visible="true"></asp:Label>
               </div>
              <div class="col-md-1 col-xs-12">
                 <asp:TextBox ID="txtExtensiondate2" runat="server"  CssClass="form-control"  Width="125px" Visible="true"></asp:TextBox>
                  </div>
                   <div class="col-md-1 col-xs-12">
                    <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txtExtensiondate2" Format="dd mmm yyyy" />
               </div>
             <div class="col-md-2 col-xs-12">
                   <asp:Label ID="Label18" runat="server" Text="Extension Of Date 3 : :" Visible="true"></asp:Label>
               </div>
              <div class="col-md-1 col-xs-12">
                   <asp:TextBox ID="txtExtensiondate3" runat="server"  CssClass="form-control"  Width="125px" Visible="true"></asp:TextBox>
                    </div>
                   <div class="col-md-1 col-xs-12">
                    <rjs:PopCalendar ID="PopCalendar3" runat="server" Control="txtExtensiondate3" Format="dd mmm yyyy" />
               </div>

              
             </div>
          <div class="row" style="padding-top:10px;">
             <div class="col-md-4"></div>
               <div class="col-md-4"></div>
              <div class="col-md-2">
                  <asp:Label ID="lblcertificate" runat="server" Text="View Completion Certificate:" Visible="false"></asp:Label>
              </div>
               <div class="col-md-2">
                   <asp:HyperLink ID="hl_certificate" Target="_blank" runat="server" Visible="false">View Document</asp:HyperLink>
              </div>
             </div>

        <div class="row" style="padding-top:10px; padding-bottom:10px;">
            <div class="col-md-5 col-xs-6"></div>
            <div class="col-md-6 col-xs-6">
             
                <asp:Button ID="btn_update" runat="server" Text="Update"  OnClick="btn_update_Click"  CssClass="btn btn-primary " Width="80px" />
                 <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="80px"  OnClick="btnDelete_Click" CssClass="btn btn-danger"  
                                   OnClientClick="return confirm('Are you sure to delete Project Details?');" Visible="false"  />
                 <%--<asp:Button ID="btn_reset" runat="server" Width="80px" Text="Reset" OnClick="btn_reset_Click"  CssClass="btn btn-danger " />--%>
            </div>
      

            </div>
      </div>
    </div>
      </div>
         








       


        </div>


</asp:Content>

