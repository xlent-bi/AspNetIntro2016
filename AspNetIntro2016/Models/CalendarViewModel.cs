using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetIntro2016.Models;

namespace AspNetIntro2016.Models
{
    public class CalendarViewModel
    {
        public DateTime Date { get; }
        public List<Day> Days { get; }

        public CalendarViewModel(DateTime date, List<Day> days)
        {
            this.Date = date;
            this.Days = days;
        }

        public String[] DaysToString()
        {
            String[] strs = new String[Days.Count];
            for(int i = 0; i < strs.Length; ++i)
            {
                strs[i] = Days.ElementAt(i).ToString();
            }
            return strs;
        }
    }
}