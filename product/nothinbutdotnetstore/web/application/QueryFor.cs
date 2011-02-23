using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class QueryFor<ReportModel> : ApplicationCommand
    {
        ResponseEngine response_engine;
        ItemQuery<ReportModel> query;

        public QueryFor(ItemQuery<ReportModel> query):this(Stub.with<StubResponseEngine>(),
            query)
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