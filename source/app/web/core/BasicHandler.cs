﻿using System.Web;
using app.infrastructure.containers;

namespace app.web.core
{
  public class BasicHandler : IHttpHandler
  {
    IProcessRequests front_controller;
    ICreateControllerRequests request_factory;

    public BasicHandler(IProcessRequests front_controller, ICreateControllerRequests request_factory)
    {
      this.front_controller = front_controller;
      this.request_factory = request_factory;
    }

    public BasicHandler() : this(Container.fetch.a<IProcessRequests>(),
                                 Container.fetch.a<ICreateControllerRequests>())
    {
    }

    public void ProcessRequest(HttpContext context)
    {
      front_controller.process(request_factory.create_request_from(context));
    }

    public bool IsReusable
    {
      get { return true; }
    }
  }
}