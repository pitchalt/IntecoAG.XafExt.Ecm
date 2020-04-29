using System.ComponentModel;
using System.IO;

using DevExpress.Xpo;

namespace IntecoAG.XafExt.Ecm {

    [Persistent("IagXafExtEcmRepository")]
    public abstract class EcmRepository: XPObject {

        [Association, Aggregated]
        [Browsable(false)]
        public XPCollection<EcmDocument> Documents {
            get { return GetCollection<EcmDocument>(nameof(Documents)); }
        }
        [Association, Aggregated]
        [Browsable(false)]
        public XPCollection<EcmFolder> Folders {
            get { return GetCollection<EcmFolder>(nameof(Folders)); }
        }
        [Association, Aggregated]
        [Browsable(false)]
        public XPCollection<EcmRelation> Relations {
            get { return GetCollection<EcmRelation>(nameof(Relations)); }
        }
        protected EcmRepository(Session session): base(session) { }

        public abstract void AddContent(EcmDocument doc, Stream stream);

    }

}