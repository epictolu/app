using System;

namespace app.infrastructure.logging
{
  public interface ICreateLoggers
  {
    ILogInformation create_logger_bound_to(Type type_that_requested_logging);
  }
}