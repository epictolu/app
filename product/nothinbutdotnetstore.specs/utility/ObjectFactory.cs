using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace nothinbutdotnetstore.specs.utility
{
    public delegate T ObjectFactory<out T>();

    public class ObjectFactory
    {
        public static IEnumerable<T> create_a_set_of<T>(int number,
                                                        ObjectFactory<T> factory)
        {
            return Enumerable.Range(1, number).Select(x => factory());
        }

        public class Web
        {
            public static HttpContext create_http_context()
            {
                return new HttpContext(create_request(), create_response());
            }

            static HttpResponse create_response()
            {
                return new HttpResponse(new StringWriter());
            }

            static HttpRequest create_request()
            {
                return new HttpRequest("blah.aspx","http://localhost/blah.aspx",String.Empty);
            }
        }
    }
}