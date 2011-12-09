using System;

namespace app.infrastructure.containers.basic
{
  public class DependencyFactoryRegistry : IFindDependencyFactories
  {
    public ICreateASingleDependency get_factory_that_can_create(Type dependency)
    {
      throw new NotImplementedException();
    }
  }
}