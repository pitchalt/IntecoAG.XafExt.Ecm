using System;
using System.IO;

using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace IntecoAG.XafExt.Ecm
{

    [Persistent("IagXafExtEcmDocument")]
    public class EcmDocument : EcmObject, IFileData {

        
        public String FileName { get; set; }
        public Boolean IsLoaded { get; set; }
        
        [Persistent(nameof(Size))]
        private Int32 _Size;
        [PersistentAlias(nameof(_Size))]
        public Int32 Size {
            get { return _Size; }
            set { SetPropertyValue(nameof(Size), ref _Size, value); }
        }

        [Association]
        [Persistent(nameof(_Repository))]
        private EcmRepository _Repository;
        
        [PersistentAlias(nameof(_Repository))]        
        public EcmRepository Repository {
            get { return _Repository; }
        }

        public override EcmRepository RepositoryCore {
            get { return _Repository; }
        }

        public EcmDocument(Session session) : base(session) { }

        public void LoadFromStream(string fileName, Stream stream) {
            throw new System.NotImplementedException();
        }

        public void SaveToStream(Stream stream) {
            throw new System.NotImplementedException();
        }

        public void Clear() {
            throw new System.NotImplementedException();
        }

    }
    
}