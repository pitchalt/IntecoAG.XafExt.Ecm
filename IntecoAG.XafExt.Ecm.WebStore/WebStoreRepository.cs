using System;
using System.IO;

using DevExpress.Xpo;

namespace IntecoAG.XafExt.Ecm.WebStore {

    [MapInheritance(MapInheritanceType.ParentTable)]
    public class WebStoreRepository: EcmRepository {

        public WebStoreRepository(Session session) : base(session) { }

        public override void AddContent(EcmDocument doc, Stream stream) {
            throw new NotImplementedException();
        }

    }

}