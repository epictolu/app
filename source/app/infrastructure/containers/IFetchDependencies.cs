using System;

namespace app.infrastructure.containers
{
  public interface IFetchDependencies
  {
    Dependency a<Dependency>();
    object a(Type dependency);
  }
}