using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.web.core
{
    public class QueryFor<ReportModel> : ApplicationCommand
    {
        ResponseEngine response_engine;
        ItemQuery<ReportModel> query;

        public QueryFor(ItemQuery<ReportModel> query):this(
            new WebFormResponseEngine(),query)
        {
        }

        public QueryFor(ResponseEngine response_engine, ItemQuery<ReportModel> query)
        {
            this.response_engine = response_engine;
            this.query = query;
        }

        public void run(Request request)
        {
            response_engine.display(query(request));
        }
    }
}