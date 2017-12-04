using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using WeatherApi.Models;
using static System.StringComparison;
using static System.Web.Mvc.JsonRequestBehavior;
using static WeatherApi.Helper;
using static WeatherApi.Global;

namespace WeatherApi.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            var city = Session["srcValue"] as City;
            return city == null ? Json(ObjectSuccess(null), AllowGet) : Search(city.Name, city.CountryCode);
        }

        public JsonResult GetLangList()
        {
            return Json(ObjectSuccess(Global.LanguageResponse.languages), AllowGet);
        }

        public JsonResult Search(string name, string culture = "TR")
        {
            try
            {
                Session["srcValue"] = "";
                string url = $"http://autocomplete.wunderground.com/aq?query={name}&c={culture}";
                string path = $"aq_query_{name}_c_{culture}.json";
                var cityResponse = GetResponse<CityResponse>(url, path);
                foreach (var res in cityResponse.RESULTS)
                {
                    res.url = $"https://www.google.com/maps/embed/v1/place?q={res.lat}%2C{res.lon}&key={GoogleMapApiKey}";
                }

                return Json(cityResponse.RESULTS.Count == 0 ? ObjectError("No Records Found!") : ObjectSuccess(cityResponse.RESULTS), AllowGet);
            }
            catch (Exception e)
            {
                return Json(ObjectError($"Exception:{e.Message}\n Detail:{e.InnerException.Message}"));
            }
        }

        public JsonResult Edit(RESULT city)
        {
            string nameWithoutCountry = city.name.Split(',')[0];
            var check = Cities.SingleOrDefault(_ => _.Name.Equals(nameWithoutCountry, OrdinalIgnoreCase));
            if (check == null)
            {
                var newCity = new City
                {
                    Name = nameWithoutCountry,
                    Key = city.zmw,
                    CountryCode = city.c
                };
                Cities.Add(newCity);
                return Json(ObjectSuccess(newCity, "The new city has been successfully added."), AllowGet);
            }
            else
            {
                check.Key = city.zmw;
                check.CountryCode = city.c;
                return Json(ObjectSuccess(check, "City is updated."), AllowGet);
            }
        }
    }
}