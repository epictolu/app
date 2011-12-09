using System;
using System.Linq.Expressions;
using app.web.core;

namespace app
{
    public class IncomingRequest
    {
        public static RequestResolver request_match_resolver;

        public static IBuildRequestMatches was
        {
            get { return request_match_resolver.Invoke(); }
        }
    }

    public delegate IBuildRequestMatches RequestResolver();
}