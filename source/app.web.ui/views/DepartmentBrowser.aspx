<%@ MasterType VirtualPath="App.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="app.web.ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="App.master" %>
<%@ Import Namespace="app.web.application.models" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
              <% foreach (var department in this.report_model)
                 {%>
              <tr class="ListItem">
               <td><a href="#"><%= department.name %></a></td>
           	  </tr>        
              <% } %>
      	    </table>            
</asp:Content>
