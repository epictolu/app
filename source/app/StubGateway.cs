using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.web.core;

namespace app
{
    public static class StubGateway
    {
        static public T Create<T>() where T : new()
        {
            return new T();
        }
    }
}
