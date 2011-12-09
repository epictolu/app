using System;
using System.Diagnostics;
using app.infrastructure.containers;

namespace app.infrastructure.logging
{
  public class Log
  {
    public static ILogInformation an
    {
      get { return Container.fetch.a<ICreateLoggers>().create_logger_bound_to(get_the_calling_type()); }
    }

    static Type get_the_calling_type()
    {
      return new StackFrame(2).GetMethod().DeclaringType;
    }
  }
}