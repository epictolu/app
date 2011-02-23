using System;

namespace nothinbutdotnetstore.infrastructure
{
    public class Stub
    {
        public static Fake with<Fake>()
        {
            throw new NotImplementedException();
        }
    }
}