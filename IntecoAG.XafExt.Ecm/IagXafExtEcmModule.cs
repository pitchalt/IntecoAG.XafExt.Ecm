using System;
using System.Collections.Generic;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;

namespace IntecoAG.XafExt.Ecm {

    public class IagXafExtEcmModule : ModuleBase {

        public IagXafExtEcmModule() { }

        protected override IEnumerable<Type> GetDeclaredExportedTypes() {
            var list = new List<Type> {
                                              typeof(EcmRepository), 
                                              typeof(EcmDocument),
                                              typeof(EcmRelation),
                                              typeof(EcmFolder)
                                      };
            return list;
        }

        protected override IEnumerable<Type> GetRegularTypes() {
            return new List<Type>(0);
        }

    }

}