using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetIntro2016.Models;

namespace AspNetIntro2016.Models
{
    public class ExportCalendarViewModel
    {
        public string Str { get; }

        public ExportCalendarViewModel(string str)
        {
            this.Str = str;
        }
        
    }
}