<%@ Page Language="C#" AutoEventWireup="true" CodeFile="showcontractor.aspx.cs" Inherits="showcontractor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
    background
    {
        margin-left:5px;
    }
               .style2
        {
            margin:0px;
            height:65px;
            width:100%;
            background-color:white;
            display:inline-block;
            color:blue;
            font-size:55px;
            font-weight:700;
            text-align:center;
            padding-top:5px;     
        }
    ul
    {
        list-style-type:none;
        margin-bottom:20px;   
        display:block;
        overflow:hidden;
        background:blue;
    }
    li
    {
        display:inline-block;
    }
    li a
    {
        display:block;
        color:White;
        padding:8px;
        text-decoration:none;
        margin-left:10px;
    }
        </style>
</head>
<body>
  <div>
        7<img src="topban.jpg" alt='Image'/>.
    </div>
<ul>
<li><a href="#home"> Home</a></li>
<li><a href="#home"> Master</a></li>
<li><a href="#home"> Project</a></li>
<li><a href="#home"> Report</a></li>
</ul>
    <form id="form1" runat="server">
    <div>
          <div class="style2">
    Contractor Entry Form
    </div>
    <asp:GridView ID="grdshow" runat="server" AutoGenerateColumns="false" 
   >
    <Columns>
          <asp:BoundField ItemStyle-Width="150px" DataField="ContractorName" HeaderText="Contractor Name" />
          <asp:BoundField ItemStyle-Width="150px" DataField="ContractorClass" HeaderText="Class Of Contractor" />
         <asp:BoundField ItemStyle-Width="150px" DataField="RegistrationType" HeaderText="Registration Type" />
         <asp:BoundField ItemStyle-Width="150px" DataField="RegistrationNo" HeaderText="Registration Number" />
        <asp:BoundField ItemStyle-Width="150px" DataField="RegYear" HeaderText="Registration Year" />
        <asp:BoundField ItemStyle-Width="150px" DataField="LetterNo" HeaderText="Letter No." />
        <asp:BoundField ItemStyle-Width="150px" DataField="LetterDate" HeaderText="Letter Date" />
         <asp:BoundField ItemStyle-Width="150px" DataField="PAN" HeaderText="PAN" />
          <asp:BoundField ItemStyle-Width="150px" DataField="DebarYN" HeaderText="Debar" />
            <asp:BoundField ItemStyle-Width="150px" DataField="DebarDate" HeaderText="Debar Date" />
                <asp:BoundField ItemStyle-Width="150px" DataField="BlacklistedYN" HeaderText="Black Listed" />
          <asp:BoundField ItemStyle-Width="150px" DataField="BlacklistDate" HeaderText="Black Listed Date" />
          <asp:BoundField ItemStyle-Width="150px" DataField="Remarks" HeaderText="Remarks" />
            <asp:BoundField ItemStyle-Width="150px" DataField="Address" HeaderText="Address" />
          <asp:BoundField ItemStyle-Width="150px" DataField="Mobile" HeaderText="Mobile" />
          
    </Columns>
</asp:GridView>
        </form>
    </div>    
</body>
</html>
