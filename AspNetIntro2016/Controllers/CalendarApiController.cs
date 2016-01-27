﻿using AspNetIntro2016.Models;
using System;
using System.Web.Http;
using System.Collections.Generic;

namespace AspNetIntro2016.Controllers
{
    public class CalendarApiController : ApiController
    {
        [Route("api/days/{year}/{month}")]
        public CalendarViewModel GetDays(int year, int month)
        {
            int y = (IsYear(year)) ? (int)year : DateTime.Now.Year;
            int m = (IsMonth(month)) ? (int)month : DateTime.Now.Month;

            CalendarFetcher fetcher;

            var date = new DateTime(y, m, 1);

            fetcher = new CalendarFetcher(y, m);
            var days = fetcher.GetCalender();

            return new CalendarViewModel(date, days);
        }

        private bool IsYear(int? year)
        {
            return (null != year) && (1 <= year) && (year <= 9999);
        }
        private bool IsMonth(int? month)
        {
            return (null != month) && (1 <= month) && (month <= 12);
        }
    }
}