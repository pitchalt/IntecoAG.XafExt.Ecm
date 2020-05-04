using System.IO;

using DevExpress.Xpo;

namespace IntecoAG.XafExt.Ecm.DbStore {

    public class EcmDbStoreRepository: EcmRepository {

        public EcmDbStoreRepository(Session session):base(session) {
            
        }

        public override void AddContent(EcmDocument doc, Stream stream) {
            throw new System.NotImplementedException();
        }

    }

}