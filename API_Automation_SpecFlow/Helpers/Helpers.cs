using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Automation_SpecFlow.Helpers
{
    public static class Helpers
    {
        public static string getBaseURL()
        {

            return "https://reqres.in/";
        }
        public static string getListUserUrl()
        {
            return "api/users?page=2";
        }
        public static string getSingleUserUrl()
        {
            return "api/users/2";
        }
        public static string createUserReq()
        {
            return "api/users";
        }

        public static string updateUserReq()
        {
            return "api/users/2";
        }
    }
}
