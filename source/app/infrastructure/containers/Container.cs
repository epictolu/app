using System;

namespace app.infrastructure.containers
{
  public class Container
  {
    public static ContainerFacadeResolver facade_resolver = () =>
    {
      throw new NotImplementedException("The container needs a facade resolver to be set by a startup process");
    };

    public static IFetchDependencies fetch
    {
      get
      {
        return facade_resolver();
      }
    }
  }
}