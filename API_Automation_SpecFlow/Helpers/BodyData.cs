using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Automation_SpecFlow.Helpers
{
    public class BodyData
    {
        public static string createRequestData(string name, string job)
        {
            var js = "{\"name\": \""+name+"\", \"job\": \""+ job+"\"}";                      
            return js;
        }

    }
}
