using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class ServiceXPObjectSpaceProvider : IServiceProvider
    {
        XPObjectSpaceProvider XPObjectSpaceProvider;
        String ConnectionString;
        public ServiceXPObjectSpaceProvider(String connectionString)
        {
            ConnectionString = connectionString;
            XPObjectSpaceProvider = new XPObjectSpaceProvider(ConnectionString);
        }
        public object GetService(Type serviceType)
        {
            if (serviceType.Name != typeof(IObjectSpace).Name)
            {
                throw new ArgumentException();
            }
            return XPObjectSpaceProvider.CreateObjectSpace();
        }
    }
}
