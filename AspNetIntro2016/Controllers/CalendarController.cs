using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetIntro2016.Models;

namespace AspNetIntro2016.Controllers
{
    public class CalendarController : Controller
    {
        private bool IsYear(int? year)
        {
            return (null != year) && (1 <= year) && (year <= 9999);
        }
        private bool IsMonth(int? month)
        {
            return (null != month) && (1 <= month) && (month <= 12);
        }
        // GET: Calendar
        public ActionResult Index(int? year, int? month)
        {

            int y = (IsYear(year)) ? (int)year : DateTime.Now.Year;
            int m = (IsMonth(month)) ? (int)month : DateTime.Now.Month;

            Models.CalendarFetcher fetcher;

            var date = new DateTime(y, m, 1);

            fetcher = new Models.CalendarFetcher(y, m);
            var days = fetcher.GetCalender();

            var vmodel = new CalendarViewModel(date, days);

            return View(vmodel);
        }
    }
}