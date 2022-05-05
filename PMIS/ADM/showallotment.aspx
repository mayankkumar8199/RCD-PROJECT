<%@ Page Language="C#" AutoEventWireup="true" CodeFile="showallotment.aspx.cs" Inherits="showallotment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowAllotment</title>
     <style type="text/css">
    background
    {
        margin-left:5px;
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
    <asp:GridView ID="grdshow" runat="server" AutoGenerateColumns="false" 
   >
    <Columns>
          <asp:BoundField ItemStyle-Width="150px" DataField="WingName" HeaderText="Wings" />
          <asp:BoundField ItemStyle-Width="150px" DataField="CircleName" HeaderText="Circle" />
           <asp:BoundField ItemStyle-Width="150px" DataField="DivisionName" HeaderText="Division" />    
         <asp:BoundField ItemStyle-Width="150px" DataField="headName" HeaderText="Head Name" />
           <asp:BoundField ItemStyle-Width="150px" DataField="SubHeadID" HeaderText="Sub Head Name" />
        <asp:BoundField ItemStyle-Width="150px" DataField="AllotmentAmount" HeaderText="A Approval Amount" />
         <asp:BoundField ItemStyle-Width="150px" DataField="AllotmentDate" HeaderText="A.A Date" />
       
 
          
    </Columns>
</asp:GridView>
         </div>
        </form>
</body>
</html>
