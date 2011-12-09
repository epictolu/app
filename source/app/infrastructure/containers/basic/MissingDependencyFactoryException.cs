using System;

namespace app.infrastructure.containers.basic
{
  public delegate Exception MissingDependencyFactoryException(Type type_that_has_no_dependency_factory);
}