﻿using System;
using System.IO;
using System.Web;

namespace app.specs.utility
{
  public class ObjectFactory
  {
    public class web
    {
      public static HttpContext create_http_context()
      {
        return new HttpContext(create_request(), create_response());
      }

      static HttpRequest create_request()
      {
        return new HttpRequest("blah.aspx", "http://localhost/blah.asxp", String.Empty);
      }

      static HttpResponse create_response()
      {
        return new HttpResponse(new StringWriter());
      }
    }
  }
}