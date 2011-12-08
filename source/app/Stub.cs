namespace app
{
  public static class Stub
  {
    public static StubType with<StubType>() where StubType : new()
    {
      return new StubType();
    }
  }
}