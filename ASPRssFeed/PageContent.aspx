<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageContent.aspx.cs" Inherits="ASPRssFeed.PageContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>RSS Content from "Flipboard"</h3>

    <div>
    <asp:GridView ID="gv_Rss" runat="server" AutoGenerateColumns="false" ShowHeader="false" BorderWidth="0">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table border="0" style="padding:0; border-spacing:5px;">
                        <tr>
                            <td>
                                <h3 style="color:#3E7CFF"><%#Eval("Title") %></h3>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                 <%#Eval("Content") %>
                            </td>
                        </tr>
                     </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
     </asp:GridView>
</div>
</asp:Content>
