using app.web.application.models;
using app.web.application.stubs;
using app.web.core;

namespace app.web.application
{
  public class ViewProductsInADepartment : ISupportAStory
               
  {
      private IFindProducts product_repository;
      private IDisplayReports display_engine;

      public ViewProductsInADepartment(IFindProducts productRepository, IDisplayReports displayEngine)
      {
          product_repository = productRepository;
          display_engine = displayEngine;
      }

      public void run(IProvideDetailsForACommand request)
      {
          var department_item = request.map<DepartmentItem>();

          var product_list = product_repository.GetProductList(department_item);

          display_engine.display(product_list);
      }
  }
}