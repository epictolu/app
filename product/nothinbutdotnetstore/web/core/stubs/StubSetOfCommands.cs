using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<RequestCommand>
    {
        public IEnumerator<RequestCommand> GetEnumerator()
        {
            yield return create_command_to_view(
                new StoreCatalogQueries().get_departments_belonging_to_department);
            yield return create_command_to_view(
                new StoreCatalogQueries().get_products_belonging_to_department);

            yield return create_command_to_view(
                new StoreCatalogQueries().get_main_departments);
        }

        RequestCommand create_command_to_view<ReportModel>(ItemQuery<ReportModel> query)
        {
            return new DefaultRequestCommand(x => true,
                                             new QueryFor<ReportModel>(query));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}