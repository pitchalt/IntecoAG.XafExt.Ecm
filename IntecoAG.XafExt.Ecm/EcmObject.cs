using System;
using System.ComponentModel;

using DevExpress.Xpo;

using PortCMIS.Client.Impl;

using Session = DevExpress.Xpo.Session;

namespace IntecoAG.XafExt.Ecm {

    [NonPersistent]
    public abstract class EcmObject : XPObject {

        [Browsable(false)]
        public abstract EcmRepository RepositoryCore { get; }

        private String _ObjectId;
        public String ObjectId {
            get { return _ObjectId; }
            set { SetPropertyValue(nameof(ObjectId), ref _ObjectId, value); }
        }
        protected EcmObject(Session session) : base(session) { }

    }

}