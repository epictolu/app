namespace app.web.core.stubs
{
  public class StubMissingCommand:IProcessOneRequest
  {
    public void run(IProvideDetailsForACommand request)
    {
    }

    public bool can_handle(IProvideDetailsForACommand request)
    {
      return false;
    }
  }
}