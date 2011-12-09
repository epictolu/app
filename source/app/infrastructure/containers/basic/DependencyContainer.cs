using System;

namespace app.infrastructure.containers.basic
{
  public class DependencyContainer : IFetchDependencies
  {
    IFindDependencyFactories dependency_finder;

    public DependencyContainer(IFindDependencyFactories dependency_finder)
    {
      this.dependency_finder = dependency_finder;
    }

    public Dependency a<Dependency>()
    {
      return (Dependency) a(typeof(Dependency));
    }

    public object a(Type dependency)
    {
      try
      {
        return dependency_finder.get_factory_that_can_create(dependency).create();
      }
      catch (Exception exception)
      {
        throw new DependencyCreationException(exception, dependency);
      }
    }
  }
}