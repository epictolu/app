using System;
using System.Collections.Generic;
using System.Linq;

namespace app.infrastructure.containers.basic
{
  public class DependencyFactoryRegistry : IFindDependencyFactories
  {
    IEnumerable<ICreateASingleDependency> factories;

    public DependencyFactoryRegistry(IEnumerable<ICreateASingleDependency> factories)
    {
      this.factories = factories;
    }

    public ICreateASingleDependency get_factory_that_can_create(Type dependency)
    {
      return factories.First(x => x.can_create(dependency));
    }
  }
}