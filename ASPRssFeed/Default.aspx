<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPRssFeed._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>RSS Feed from "Flipboard"</h3>

<div>
    <asp:GridView ID="gv_Rss" runat="server" AutoGenerateColumns="false" ShowHeader="false" BorderWidth="0">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table border="0" style="padding:0; border-spacing:5px;">
                        <tr>
                            <td>
                                <h3 style="color:#3E7CFF"><a href="PageContent.aspx" target="_blank"><%#Eval("Title") %></a></h3>
                            </td>
                            <td style="width:300px; text-align:right;">
                                 <%#Eval("PublishDate") %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <hr />
                                 <%#Eval("Description") %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                Autor: <%#Eval("Author") %>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                Kategooria: <%#Eval("Category") %>
                            </td>
                            <td style="text-align:right;">
                                <a href='<%#Eval("Link") %>' target="_blank">Loe edasi...</a>
                             </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
     </asp:GridView>
</div>
</asp:Content>
