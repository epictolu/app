using System.Collections.Generic;
using System.Web;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubResponseEngine : ResponseEngine
    {
        public void display<ReportModel>(ReportModel model)
        {
            HttpContext.Current.Items.Add("blah", model);

            if (model is IEnumerable<Department>) HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx",true);
            HttpContext.Current.Server.Transfer("~/views/ProductBrowser.aspx",true);
        }
    }
}