using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using IntecoAG.XafExt.Ecm.WebStoreService.Logic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IntecoAG.XafExt.Ecm.WebStoreService {

    public class Program {

        public static void Main(string[] args) {
            RegisterEntities();
            var dir_name = StoreLogic.GetDirection();
            if (!Directory.Exists(dir_name))
                Directory.CreateDirectory(dir_name);
            CreateHostBuilder(args).Build().Run();
        }
        private static void RegisterEntities()
        {
            XpoTypesInfoHelper.GetXpoTypeInfoSource();
            XafTypesInfo.Instance.RegisterEntity(typeof(EcmDocument));
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

    }

}