using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbsentManagement.Areas.Home.Data.Enums
{
    public class AbsentLogStatusEnum
    {

        public const int PENDING = 0;
        public const int APPROVED = 1;
        public const int REJECT = 2;

        public static string getKey(int absentValue)
        {
            switch (absentValue)
            {
                case PENDING:
                    return "PENDING";
                case APPROVED:
                    return "APPROVED";
                case REJECT:
                    return "REJECT";
                default:
                    throw new Exception("Key does not exist");
            }
        }

        public static int getValue(String absentValue)
        {
            switch (absentValue)
            {
                case "PENDING":
                    return PENDING;
                case "APPROVED":
                    return APPROVED;
                case "REJECT":
                    return REJECT;
                default:
                    throw new Exception("Key does not exist");
            }
        }
    }
}