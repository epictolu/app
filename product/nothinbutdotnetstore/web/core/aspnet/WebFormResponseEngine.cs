using System;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public class WebFormResponseEngine : ResponseEngine
    {
        public WebFormResponseEngine(ViewLocator locator)
        {
            
        }

        public void display<ReportModel>(ReportModel model)
        {
            //View view = locator.locate_view_for(model);
            //ViewContext context= new ViewContext()
            //context.save( //some context information)
            //view.Render();
            throw new NotImplementedException();
        }
    }
}