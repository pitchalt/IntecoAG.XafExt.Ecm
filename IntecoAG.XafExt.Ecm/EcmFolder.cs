using DevExpress.Xpo;

namespace IntecoAG.XafExt.Ecm
{
    [Persistent("IagXafExtEcmFolder")]
    public class EcmFolder : EcmObject {

        [Association]
        [Persistent(nameof(_Repository))]
        private EcmRepository _Repository;
        [PersistentAlias(nameof(_Repository))]        
        public override EcmRepository Repository {
            get { return _Repository; }
        }

        public EcmFolder(Session session) : base(session) { }

    }

}