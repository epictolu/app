namespace nothinbutdotnetstore.web.core.aspnet
{
    public interface ViewFactory
    {
        ViewFor<ReportModel> create_view_for<ReportModel>(ReportModel model);
    }
}