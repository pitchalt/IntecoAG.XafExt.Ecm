using DevExpress.ExpressApp.Xpo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class ServiceXPObjectSpaceProvider : XPObjectSpaceProvider
    {
        public ServiceXPObjectSpaceProvider(string connectionString): base(connectionString)
        {

        }
        public ServiceXPObjectSpaceProvider(IDbConnection connection) : base(connection)
        {

        }
    }
}
