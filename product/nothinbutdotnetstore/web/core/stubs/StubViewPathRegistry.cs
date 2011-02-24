using System.Collections.Generic;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubViewPathRegistry : ViewPathRegistry
    {
        public string get_path_to_view_for<ReportModel>()
        {
            if (typeof(ReportModel).Equals(typeof(IEnumerable<Department>))) return create_view_to("DepartmentBrowser");
            return create_view_to("ProductBrowser");
        }

        string create_view_to(string view_name)
        {
            return string.Format("~/views/{0}.aspx", view_name);
        }
    }
}