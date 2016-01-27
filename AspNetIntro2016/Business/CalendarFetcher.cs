using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace AspNetIntro2016.Models
{
    public class CalendarFetcher
    {

        static public string JsonWeb = "http://api.dryg.net/dagar/v2.1/";

        private string Link;

        public CalendarFetcher(int year, int month)
        {
            StringBuilder strB = new StringBuilder(CalendarFetcher.JsonWeb);
            strB.Append(year.ToString())
                .Append("/")
                .Append(month.ToString());

            this.Link = strB.ToString();
        }
        public CalendarFetcher(int year)
        {
            StringBuilder strB = new StringBuilder(CalendarFetcher.JsonWeb);
            strB.Append(year.ToString());

            this.Link = strB.ToString();
        }

        public String GetJsonString()
        {
            var jsonData = String.Empty;

            using (WebClient wc = new WebClient())
            {
                try
                {
                    jsonData = wc.DownloadString(Link);
                }
                catch (Exception e) //needs to capture a more precise exception
                {
                    System.Console.WriteLine("JSON problems");
                    System.Console.WriteLine(e.StackTrace);
                    System.Console.ReadKey();
                }
            }
            Console.WriteLine(jsonData);
            return jsonData;
        }

        public List<Day> GetCalender()
        {
            var jsonData = String.Empty;
            var days = new List<Day>();

            using (WebClient wc = new WebClient())
            {
                try
                {
                    jsonData = wc.DownloadString(Link); //move to GetJsonString?
                    //insert the catch here instead?
                    var jsonObj = JObject.Parse(jsonData);

                    //like this
                    //JArray jsonDaysArr = (JArray)jsonObj["dagar"];
                    //var jsonDays = jsonDaysArr.Children();
                    //or like this
                    var jsonDs = jsonObj["dagar"].Children();

                    foreach (var dayObj in jsonDs)
                    {
                        days.Add(new Day(
                           date: dayObj["datum"].ToString(),
                           weekDay: dayObj["veckodag"].ToString(),
                           workFreeDay: dayObj["arbetsfri dag"].ToString(),
                           redDay: dayObj["r\u00F6d dag"].ToString(),
                           holiday: (null != dayObj["helgdag"]) ? dayObj["helgdag"].ToString() : null, //if dayObj["helgdag"] exists then holiday should be set to it. Null otherwise
                           namesDays: dayObj["namnsdag"].Children().Values<string>().ToList<string>()
                        ));
                        var v = dayObj["namnsdag"].Children().Values<string>().ToList<string>();
                    }
                }
                catch (Exception e) //needs to capture a more precise exception
                {
                    System.Console.WriteLine("JSON problems");
                    System.Console.WriteLine(e.StackTrace);
                }

                return days;
            }
        }

    }
}