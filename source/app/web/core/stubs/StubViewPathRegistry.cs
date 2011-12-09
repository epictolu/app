using System;
using System.Collections.Generic;
using app.web.application.models;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
  public class StubViewPathRegistry:IFindPathsToViews
  {
    public string get_path_to_view_that_can_display<ReportModel>()
    {
      var paths = new Dictionary<Type, string>();
      paths.Add(typeof(IEnumerable<DepartmentItem>),"DepartmentBrowser");
      paths.Add(typeof(IEnumerable<ProductItem>),"ProductBrowser");

      return string.Format("~/views/{0}.aspx", paths[typeof(ReportModel)]);
    }
  }
}