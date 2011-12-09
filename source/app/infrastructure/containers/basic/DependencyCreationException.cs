using System;

namespace app.infrastructure.containers.basic
{
  public class DependencyCreationException : Exception

  {
    public DependencyCreationException(Exception innerException, Type type_that_could_not_be_created)
      : base(String.Empty, innerException)
    {
      this.type_that_could_not_be_created = type_that_could_not_be_created;
    }

    public Type type_that_could_not_be_created { get; private set; }
  }
}