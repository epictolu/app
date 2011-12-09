using System;

namespace app.infrastructure.containers.basic
{
  public interface IFindDependencyFactories
  {
    ICreateASingleDependency get_factory_that_can_create(Type dependency);
  }
}