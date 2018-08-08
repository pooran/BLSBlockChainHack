using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conveniente.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var client = new RestClient("https://node1.neocompiler.io/getstorage");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "448540d5-8fb8-b1bd-793c-4d19c1210b5a");
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("undefined", "{\r\n  \"jsonrpc\": \"2.0\",\r\n  \"method\": \"getstorage\",\r\n  \"params\": [\"5c1c465535a695b8a327116721179a51267fb103\", \"50496431\"],\r\n  \"id\": 15\r\n}", ParameterType.RequestBody);
            var response =  client.Execute(request);
            var x = JsonConvert.DeserializeObject(response.Content);
            var y = ((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JToken)x).Root).Last;
            
            return View();
        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
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
    }
}