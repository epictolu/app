using System.Web.Compilation;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.stubs;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public class WebFormViewFactory : ViewFactory
    {
        ViewPathRegistry view_path_registry;
        PageFactory page_factory;

        public WebFormViewFactory():this(Stub.with<StubViewPathRegistry>(),BuildManager.CreateInstanceFromVirtualPath)
        {
        }

        public WebFormViewFactory(ViewPathRegistry view_path_registry, PageFactory page_factory)
        {
            this.view_path_registry = view_path_registry;
            this.page_factory = page_factory;
        }

        public ViewFor<ReportModel> create_view_for<ReportModel>(ReportModel model)
        {
            var view = (ViewFor<ReportModel>) page_factory(view_path_registry.get_path_to_view_for<ReportModel>(),
                                                           typeof(ViewFor<ReportModel>));

            view.report_model = model;
            return view;
        }
    }
}