using app.web.core;

namespace app
{
    public class RequestMatchBuilder : IBuildRequestMatches
    {
        public RequestMatch made_for<TRequest>()
        {
            return x => x.GetType() == typeof (TRequest);
        }
    }
}
