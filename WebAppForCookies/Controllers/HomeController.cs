using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;

namespace WebAppForCookies.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var context = Request.GetOwinContext();
            ViewData["SameAsRequest"] = context.Request.Cookies["SameAsRequest"];
            ViewData["Never"] = context.Request.Cookies["Never"];
            ViewData["Always"] = context.Request.Cookies["Always"];
            return View();
        }

        [HttpPost]
        public ActionResult WriteCookies(string value)
        {
            var context = Request.GetOwinContext();
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = context.Request.IsSecure
            };
            context.Response.Cookies.Append("SameAsRequest", value, cookieOptions);

            cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false
            };
            context.Response.Cookies.Append("Never", value, cookieOptions);

            cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true
            };
            context.Response.Cookies.Append("Always", value, cookieOptions);

            return RedirectToAction("Index");
        }
	}
}