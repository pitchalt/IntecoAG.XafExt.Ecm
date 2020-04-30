using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntecoAG.XafExt.Ecm.WebStoreService.Logic
{
    public static class StoreLogic
    {
        public static String GetDirection()
        {
            return $@"{Environment.CurrentDirectory}\FileDataSource";
        }

        public static String GetFullName(String fullName)
        {
            var curr = GetDirection() + @"\" + fullName;
            return curr;
        }
    }
}
