using System;
using System.Linq;
using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;
using WeatherApi.Models;
using static System.Web.Mvc.JsonRequestBehavior;
using static WeatherApi.Global;
using static WeatherApi.Helper;

namespace WeatherApi.Controllers
{
    public class CacheController : Controller
    {
        // GET: Cache
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCacheList()
        {
            return Json(ObjectSuccess(CacheList), AllowGet);
        }

        public JsonResult Delete(Guid? Id)
        {
            var cache = CacheList.SingleOrDefault(_ => _.GuidId == Id);
            if (cache != null)
            {
                if (System.IO.File.Exists(cache.FullPath))
                {
                    System.IO.File.Delete(cache.FullPath);
                }
                CacheList.Remove(cache);
            }
            else
            {
                return Json(ObjectError("No Records Found!"), AllowGet);
            }

            return Json(ObjectSuccess(cache, "Cache is deleted."), AllowGet);
        }
    }
}