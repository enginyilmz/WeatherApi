using System;
using System.Linq;
using System.Web.Mvc;
using WeatherApi.Models;
using static System.Web.Mvc.JsonRequestBehavior;
using static WeatherApi.Helper;
using static WeatherApi.Global;
using System.Collections.Generic;
using WebGrease.Css.Extensions;

namespace WeatherApi.Controllers
{
    public class ForecastController : Controller
    {
        // GET: Forecast
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(ObjectSuccess(Cities.ToArray()), AllowGet);
        }

        public JsonResult GetLangList()
        {
            return Json(ObjectSuccess(Global.LanguageResponse.languages), AllowGet);
        }

        public JsonResult GetIconList()
        {
            return Json(ObjectSuccess(IconSet), AllowGet);
        }

        public JsonResult GetTenForecast(string key, string lang = "TR")
        {
            try
            {
                string url = $"http://api.wunderground.com/api/{WeatherApiKey}/forecast10day/lang:{lang}/q/zmw:{key}.json";
                string path = $"forecast10day_lang_{lang}_q_zmw_{key}.json";
                var tenDaysForecast = GetResponse<CityTenDaysForecast>(url, path);

                if (tenDaysForecast.response.error != null && tenDaysForecast.response.error.type == "querynotfound")
                    return Json(ObjectError($"No Records Found!\n{tenDaysForecast.response.error.description}"), AllowGet);

                return Json(ObjectSuccess(tenDaysForecast.forecast), AllowGet);
            }
            catch (Exception e)
            {
                var inEx = e.InnerException?.Message ?? string.Empty;
                return Json(ObjectError($"Exception:{e.Message}\n Detail:{inEx}"));
            }
        }

        public JsonResult GetYearForecast(string cityName, string countryCode = "TR")
        {
            try
            {
                //var dateRange = "12011231";
                var cityPlannerList = new List<CityPlanner>();
                foreach (var dateRange in DateRanges)
                {
                    string url = $"http://api.wunderground.com/api/{WeatherApiKey}/planner_{dateRange}/q/{countryCode}/{cityName}.json";
                    string path = $"planner_{dateRange}_q_{countryCode}_{cityName}.json"; 
                    var cityPlanner = GetResponse<CityPlanner>(url,path);
                    cityPlanner.SetColorRangeClass();
                    if (cityPlanner.response.error == null)
                        cityPlannerList.Add(cityPlanner);
                }
 
                if (cityPlannerList.Count <= 0)
                    return Json(ObjectError($"No Records Found!"), AllowGet);

                return Json(ObjectSuccess(cityPlannerList), AllowGet);
            }
            catch (Exception e)
            {
                var inEx = e.InnerException?.Message ?? string.Empty;
                return Json(ObjectError($"Exception:{e.Message}\n Detail:{inEx}"));
            }
        }
    }
}