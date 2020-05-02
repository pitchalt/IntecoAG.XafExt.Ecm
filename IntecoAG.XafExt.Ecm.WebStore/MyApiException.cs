using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClientApp
{
    public class ApiException:IRequestResult
    {
        public  String Message { get; set; }
    }
}
