using System;

namespace app.infrastructure.containers.basic
{
  public interface ICreateASingleDependency
  {
    object create();
    bool can_create(Type type);
  }
}