<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true" CodeFile="UpdateContractor.aspx.cs" Inherits="RCDPMISNEW_Common_UpdateContractor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="container-fluid" style="padding-top:12px;">

         
 
  <div class="panel-group">
    <div class="panel panel-primary">
      <div class="panel-heading" style="text-align:center; font-weight:700; font-size:x-large">Update Contractor Details</div>
      <div class="panel-body">
          
       
        <div class="row">
            <div class="col-sm-12" style="padding-top:10px;">
                <div class="col-sm-3"></div>
                <div class="col-sm-6">
                    
              
                </div>
                <div class="col-sm-3"><%-- <asp:Button ID="lnkback" runat="server"   OnClick="lnkback_Click" Text="Back" Width="150px" CssClass="btn btn-primary btn " /></p>--%>
                     <p style="float:right">  <asp:ImageButton ID="lnkback" runat="server"  OnClick="lnkback_Click" Width="45px"   ImageUrl="~/RCDPMISNEW/images/back_image.png"  />  </p>
                </div>
               
              
            </div>
        </div>

           <div class="row" style="padding-top: 10px;">
         
            <div class="col-md-3 col-sm-12 form-group">
                <label>ContractorID:</label>
                <%--<asp:Label ID="lblwing" Text="Wing" runat="server"></asp:Label>--%>
                 <asp:TextBox ID="txtcontId" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
            </div>
            <div class="col-md-3 col-sm-12 form-group">
                    <label>Name of Firm / Contractor:</label>
               <%-- <asp:Label ID="lblcircle" Text="Circle" runat="server"></asp:Label>--%>
                 <asp:TextBox  ID="txt_firmName" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
          
            <div class="col-md-3 col-sm-12 form-group">
              <label>Contractor Class:</label>
                    <%--  <asp:Label ID="lbldivision" Text="Division" runat="server"></asp:Label>--%>
                  <asp:TextBox ID="txt_contr_class" runat="server" CssClass="form-control" Enabled="false"  ></asp:TextBox>
            </div>
              <div  class="col-md-3 col-sm-12 form-group">
                 <asp:Label ID="lbl_TypeofContractor" runat="server" Text="Type of Contractor:"></asp:Label>
             
                 <asp:TextBox ID="txt_typeofcontr" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
            </div>
            
        </div>

        <div class="row" >
            <div class="col-md-3 col-sm-12 form-group">
                  <asp:Label ID="lbl_Registration_No" runat="server" Text="Registration No.:"></asp:Label>
               <%-- <asp:Label ID="lblshmdr" Text="SH MDR" runat="server"></asp:Label>--%>
                <asp:TextBox ID="txt_regNo" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
            </div>
       
            <div class="col-md-3 col-sm-12 form-group">
                 <asp:Label ID="lbl_yearofreg" runat="server" Text="Year of Registration:"></asp:Label>
                <asp:TextBox ID="txt_yrofreg" runat="server" CssClass="form-control" Enabled="false"  ></asp:TextBox>
            </div>
             <div class="col-md-3 col-sm-12 form-group">
                   <asp:Label ID="lbl_letterno" runat="server" Text="	Letter No."></asp:Label>
                <asp:TextBox ID="txt_letterno" runat="server" CssClass="form-control"   ></asp:TextBox>
            </div>
             <div class="col-md-3 col-sm-12 form-group">
                <asp:Label ID="lbl_letterdate" runat="server" Text="Letter Date:"></asp:Label>
                <asp:TextBox ID="txt_letterdate" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
             
        </div>


         <div class="row">
             
            <div class="col-md-4 col-sm-12 form-group">
                 <asp:Label ID="lbl_address" runat="server" Text="Address"></asp:Label>
                <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" CssClass="form-control"   ></asp:TextBox>
            </div>
             
            <div class="col-md-3 col-sm-12 form-group">
                   <asp:Label ID="lbl_mobile" runat="server" Text="Mobile"></asp:Label>
                <asp:TextBox ID="txt_mobile" runat="server"  CssClass="form-control"   ></asp:TextBox>
            </div>
              <div class="col-md-3 col-sm-12 form-group">
                 <asp:Label ID="lbl_pan" runat="server" Text="PAN No:"></asp:Label>
                <asp:TextBox ID="txt_pan" runat="server" CssClass="form-control"   ></asp:TextBox>
            </div>
             
             
             </div>

        <div class="row">
              <div class="col-md-6 col-sm-12 form-group"></div>
            <div class="col-md-4 col-sm-12 form-group">
                 <asp:Button ID="btnupdate" runat="server" Text="Update" Font-Bold="True" 
                    OnClick="btnupdate_Click"  CssClass="btn btn-primary"  />
            </div>
        </div>
        

    </div>
    
    


      </div>
    </div>
      </div>
              


     
</asp:Content>

