using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIntro2016.Models
{
    public class Day
    {
        public string Date { get; }
        public string WeekDay { get; }
        public bool WorkFreeDay { get; }
        public bool RedDay { get; }
        public string Holiday { get; }
        public List<string> NamesDays { get; }

        public Day(string date, string weekDay, string workFreeDay,
            string redDay, string holiday, List<string> namesDays)
        {
            Date = date;
            WeekDay = weekDay;
            WorkFreeDay = workFreeDay.Equals("Ja");
            RedDay = redDay.Equals("Ja");
            Holiday = holiday;
            NamesDays = namesDays;
        }

        public override string ToString()
        {
            StringBuilder strB = new StringBuilder();

            strB.Append("{ Date: ")
                .Append(Date)
                .Append(", WeekDay: ")
                .Append(WeekDay)
                .Append(", WorkFreeDay: ")
                .Append(WorkFreeDay)
                .Append(", RedDay: ")
                .Append(RedDay);

            if (null != Holiday && !Holiday.Equals(String.Empty))
            {
                strB.Append(", Holiday: " + Holiday);
            }

            strB.Append(", NamesDays: [ ");
            bool looped = false;
            foreach (var name in NamesDays)
            {
                if( looped )
                {
                    strB.Append(", ");
                }
                strB.Append(name);
                looped = true;
            }
            strB.Append(" ]");

            strB.Append(" }");

            return strB.ToString();
        }
    }
}