<%@ Page Title="" Language="C#" MasterPageFile="~/RCDPMIS/SiteMaster.master" AutoEventWireup="true"
    CodeFile="IMap.aspx.cs" Inherits="IMapMobile" %>


<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <title></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        
        <table border="1" width="100%" style="border: 2px solid #fb4e00; background-color: White">
            <tr>
                <td colspan="3">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr style="background-color: #006699">
                            <td>
                                <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <asp:Label ID="Label2" runat="server"></asp:Label>
</asp:Content>
