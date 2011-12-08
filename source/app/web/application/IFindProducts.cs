using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.web.application.models;

namespace app.web.application
{
    public interface IFindProducts
    {
        IEnumerable<ProductItem> GetProductList(DepartmentItem departmentItem);
    }
}
