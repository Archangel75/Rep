using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersBasicStuff.Controllers
{
    public class MyController : IController
    {
        public void Execute(System.Web.Routing.RequestContext requestContext)
        {
            string ip = requestContext.HttpContext.Request.UserHostAddress;
            var responce = requestContext.HttpContext.Response;
            responce.Write("<h2>Ваш ip: " + ip + "</h2>");            
        }
    }
}