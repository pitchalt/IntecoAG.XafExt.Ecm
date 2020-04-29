using System;

using DevExpress.Xpo;

using PortCMIS.Client.Impl;

using Session = DevExpress.Xpo.Session;

namespace IntecoAG.XafExt.Ecm {

    [NonPersistent]
    public abstract class EcmObject : XPObject {

        public abstract EcmRepository Repository { get; }

        private String _ObjectId;
        public String ObjectId {
            get { return _ObjectId; }
            set { SetPropertyValue(nameof(ObjectId), ref _ObjectId, value); }
        }
        protected EcmObject(Session session) : base(session) { }

    }

}