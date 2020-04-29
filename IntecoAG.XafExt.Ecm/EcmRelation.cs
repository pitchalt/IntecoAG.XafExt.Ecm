using DevExpress.Xpo;

namespace IntecoAG.XafExt.Ecm
{
    [Persistent("IagXafExtEcmRelation")]
    public class EcmRelation : EcmObject {

        [Association]
        [Persistent(nameof(_Repository))]
        private EcmRepository _Repository;
        [PersistentAlias(nameof(_Repository))]        
        public override EcmRepository Repository {
            get { return _Repository; }
        }

        public EcmRelation(Session session) : base(session) { }

    }
}