<%@ MasterType VirtualPath="App.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="app.web.ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="App.master" %>
<%@ Import Namespace="app.web.application" %>
<%@ Import Namespace="app.web.application.models" %>
<%@ Import Namespace="app.web.core.stubs" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
              <% foreach (var department in this.report_model)
                 {%>
              <tr class="ListItem">
                
               <td><a href="<%= Url.to.run<ViewProductsRequest>()
                                      .or_else<ViewSubDepartmentsRequest>()
                                      .based_on(department.has_products)
                                       %>"><%= department.name %></a></td>
           	  </tr>        
              <% } %>
      	    </table>            
</asp:Content>
