<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationControl.ascx.cs" Inherits="PetShop.Web.NavigationControl" %>
<%@ OutputCache Duration="100000" VaryByParam="*" %>
<asp:ListView ID="lvCategories" runat="server">
    <LayoutTemplate>
        <table cellspacing="0" border="0" style="border-collapse: collapse;">
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <tr>
            <td class="rsstd"><a href='<%# string.Format("FeedService.svc/GetProducts?category={0}", Eval("Id")) %>'><img src="Comm_Images/rssbutton.gif" alt="" style="border:0px;" /></a></td>
            <td class="<%= ControlStyle %>"><asp:HyperLink runat="server" ID="lnkCategory"  NavigateUrl='<%# string.Format("~/Products.aspx?page=0&categoryId={0}", Eval("Id")) %>' Text='<%# Eval("Name") %>' /><asp:HiddenField runat="server" ID="hidCategoryId" Value='<%# Eval("Id") %>' /></td>
        </tr>
    </ItemTemplate>
</asp:ListView>
