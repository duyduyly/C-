using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbsentManagement.Areas.Home.Data.Enums
{
    public class PersonEnum
    {
        public const int STUDENT = 0;
        public const int TEACHER = 1;


        public static String getKey(int value)
        {
            switch (value)
            {
                case STUDENT:
                    return "STUDENT";
                case TEACHER:
                    return "TEACHER";
                default: throw new Exception("Key does not found");
            }
        }

        public static int getValue(string key)
        {
            switch (key)
            {
                case "STUDENT":
                    return STUDENT;
                case "TEACHER":
                    return TEACHER;
                default: throw new Exception("Key does not found");
            }
        }
    }
}