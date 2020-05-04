using System.Net.Mime;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;

using IntecoAG.XafExt.Ecm.DbStore;

using Xunit;

namespace IntecoAG.XafExt.Ecm.Tests {

    public class EcmUseCaseBaseTests {

        protected readonly TestApplication Application;
        protected readonly IObjectSpaceProvider ObjectSpaceProvider;

        protected IObjectSpace CreateObjectSpace() {
            return Application.CreateObjectSpace();
        }

        public EcmUseCaseBaseTests() {
            ObjectSpaceProvider = new XPObjectSpaceProvider(new MemoryDataStoreProvider());
            Application = new TestApplication();
            IagXafExtEcmModule module = new IagXafExtEcmModule();
            Application.Modules.Add(module);
            Application.Setup("TestApplication", ObjectSpaceProvider);
        }

        [Fact]
        public void FirstTest() {
            using (IObjectSpace os = CreateObjectSpace()) {
                var repository = os.CreateObject<EcmDbStoreRepository>();
                os.CommitChanges();
            }                        
        }


    }

}