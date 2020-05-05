using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Xpo;
using DevExpress.XtraPrinting.Native;

namespace IntecoAG.XafExt.Ecm.Tests {

    public class TestApplication : XafApplication {

        public TestApplication() : base() {
            CheckCompatibilityType = CheckCompatibilityType.DatabaseSchema;
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            DatabaseVersionMismatch += OnDatabaseVersionMismatch;
        }
        
        protected override LayoutManager CreateLayoutManagerCore(bool simple) {
            return null;
        }
        
        private void OnDatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        }
        
    }
}