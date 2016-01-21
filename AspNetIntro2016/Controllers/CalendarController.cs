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
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Calendar(int? year, int? month)
        {

            int y = (null != year) ? (int) year : 2016; //should be a default value of current year
            //int m = (null != month) ? (int) month : 1; //should be a default value of current month
            Models.CalendarFetcher fetcher;

            if(null != month)
            {
                fetcher = new Models.CalendarFetcher(y, (int) month);
                ViewBag.month = month;
            }
            else
            {
                fetcher = new Models.CalendarFetcher(y);
            }
            //ViewBag.data = fetcher.GetCalender();
            ViewBag.data = fetcher.GetJsonString();
            ViewBag.year = year;

            return View();
        }
    }
}