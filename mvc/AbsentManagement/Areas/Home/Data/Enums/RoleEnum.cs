using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbsentManagement.Areas.Home.Data.Enums
{
    public class RoleEnum
    {
        public const int USER = 0;
        public const int ADMIN = 1;


        public static String getKey(int value)
        {
            switch (value)
            {
                case ADMIN:
                    return "ADMIN";
                case USER:
                    return "USER";
                default: throw new Exception("Key does not found");
            }
        }

        public static int getValue(string key)
        {
            switch (key)
            {
                case "ADMIn":
                    return ADMIN;
                case "USER":
                    return USER;
                default: throw new Exception("Key does not found");
            }
        }
    }
}