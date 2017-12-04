using System;
using System.Linq;
using System.Web.Mvc;
using WeatherApi.Models;
using static System.StringComparison;
using static System.Web.Mvc.JsonRequestBehavior;
using static WeatherApi.Helper;
using static WeatherApi.Global;

namespace WeatherApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(ObjectSuccess(Cities),AllowGet);
        }

        public JsonResult Add(string cityName, string cityKey, string countryCode)
        {
            var checkDuplicate = Cities.SingleOrDefault(_ => _.Name.Equals(cityName, OrdinalIgnoreCase));
            if (checkDuplicate != null) return Json(ObjectError($"{cityName} city is already attached."), AllowGet);

            var city = new City
            {
                Name = cityName,
                Key = cityKey,
                CountryCode = countryCode
            };
            Cities.Add(city);
            return Json(ObjectSuccess(city, "The new city has been successfully added."), AllowGet);
        }

        public JsonResult Delete(Guid? Id)
        {
            var city = Cities.SingleOrDefault(_ => _.GuidId == Id);
            if (city != null)
            {
                Cities.Remove(city);
            }
            else
            {
                return Json(ObjectError("No Records Found!"), AllowGet);
            }

            return Json(ObjectSuccess(city, "City is deleted."), AllowGet);
        }

        public JsonResult Edit(City data)
        {
            var city = (City) data;

            var checkDuplicate = Cities.SingleOrDefault(_ => _.Name.Equals(city.Name,OrdinalIgnoreCase));
            if (checkDuplicate != null) return Json(ObjectError($"{city.Name} city already exists."), AllowGet);

            var updateCity = Cities.SingleOrDefault(_ => _.GuidId == city.GuidId);

            if (updateCity != null)
            {
                updateCity.Name = city.Name;
                updateCity.Key = city.Key;
                updateCity.CountryCode = city.CountryCode;
            }
            else
            {
                return Json(ObjectError("No Records Found!"), AllowGet);
            }

            return Json(ObjectSuccess(updateCity, "City is updated."), AllowGet);
        }

        public JsonResult Search(City city)
        {
            Session["srcValue"] = city;
            return Json(ObjectSuccess(null), AllowGet);
        }

    }
}