namespace nothinbutdotnetstore.infrastructure
{
    public class Stub
    {
        public static Fake with<Fake>() where Fake : new()
        {
            return new Fake();
        }
    }
}