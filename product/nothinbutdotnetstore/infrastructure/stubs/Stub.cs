namespace nothinbutdotnetstore.infrastructure.stubs
{
    public class Stub
    {
        public static Fake with<Fake>() where Fake : new()
        {
            return new Fake();
        }
    }
}