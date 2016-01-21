using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIntro2016.Models
{
    public class Day
    {
        public string Date { get; set; }
        public string WeekDay { get; set; }
        public string WorkFreeDay { get; set; }
        public string RedDay { get; set; }
        public string Holiday { get; set; }
        public List<string> NamesDays { get; set; }
        public override string ToString()
        {
            StringBuilder strB = new StringBuilder();

            strB.Append("{ ")
                .Append(Date)
                .Append(", ")
                .Append(WeekDay)
                .Append(", ")
                .Append(WorkFreeDay)
                .Append(", ")
                .Append(RedDay);

            if( null != Holiday && !Holiday.Equals(String.Empty) )
            {
                strB.Append(", " + Holiday);
            }

            foreach (var name in NamesDays)
            {
                strB.Append(String.Format(", {0}", name));
            }
            strB.Append(" }");

            return strB.ToString();
        }
    }
}