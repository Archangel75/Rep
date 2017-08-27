using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersBasicStuff.Util
{
    public class HtmlResult : ActionResult
    {
        public string HtmlCode;

        public HtmlResult(string html)
        {
            HtmlCode = html;
        }

        public  override void ExecuteResult(ControllerContext context)
        {
            string fullHtmlCode = "<!DOCTYPE html><html><head>";
            fullHtmlCode += "<title>Главная страница</title>";
            fullHtmlCode += "<meta charset=urf-8 />";
            fullHtmlCode += "</head> <body>";
            fullHtmlCode += HtmlCode;
            fullHtmlCode += "</body></html>";
            context.HttpContext.Response.Write(fullHtmlCode);
        }
    }
}