using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbsentManagement.Areas.Admin.Utils
{
    public class DateUtils
    {
        public static string parseString(string pattern, DateTime dateTime)
        {
           return dateTime.ToString(pattern);
        }
    }
}