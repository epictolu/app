using System.Web;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public class WebFormResponseEngine : ResponseEngine
    {
        ViewFactory factory;
        CurrentContextResolver current_context_resolver;

        public WebFormResponseEngine():this(new WebFormViewFactory(),
            () => HttpContext.Current)
        {
        }

        public WebFormResponseEngine(ViewFactory factory, CurrentContextResolver current_context_resolver)
        {
            this.factory = factory;
            this.current_context_resolver = current_context_resolver;
        }

        public void display<ReportModel>(ReportModel model)
        {
            factory.create_view_for(model).ProcessRequest(current_context_resolver());
        }
    }
}