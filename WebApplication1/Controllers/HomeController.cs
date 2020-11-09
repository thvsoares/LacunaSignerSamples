using Lacuna.Signer.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Api()
        {
            var message = new HttpRequestMessage(HttpMethod.Get, "https://signer-lac.azurewebsites.net/api/folders?Q=Sample");
            message.Headers.Add("X-Api-Key", "API Sample App|43fc0da834e48b4b840fd6e8c37196cf29f919e5daedba0f1a5ec17406c13a99");
            var client = new HttpClient();
            var response = client.SendAsync(message).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            return Content(content);

        }

        public ActionResult Lacuna()
        {
            var client = new Lacuna.Signer.Client.SignerClient("https://signer-lac.azurewebsites.net", "API Sample App|43fc0da834e48b4b840fd6e8c37196cf29f919e5daedba0f1a5ec17406c13a99");
            var info = client.ListFoldersPaginatedAsync(new Lacuna.Spa.Api.PaginatedSearchParams() { Q = "Sample" }, null).Result;
            return Json(info, JsonRequestBehavior.AllowGet);
        }
    }
}