// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoDevelop.Deployment {
    
    
    public partial class DeployFileListWidget {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Label label1;
        
        private Gtk.ScrolledWindow scrolledwindow1;
        
        private Gtk.TreeView fileList;
        
        private Gtk.HBox hbox2;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize();
            // Widget MonoDevelop.Deployment.DeployFileListWidget
            Stetic.BinContainer.Attach(this);
            this.Name = "MonoDevelop.Deployment.DeployFileListWidget";
            // Container child MonoDevelop.Deployment.DeployFileListWidget.Gtk.Container+ContainerChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.Xalign = 0F;
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("The following files will be included in the package:");
            this.vbox2.Add(this.label1);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox2[this.label1]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.scrolledwindow1 = new Gtk.ScrolledWindow();
            this.scrolledwindow1.CanFocus = true;
            this.scrolledwindow1.Name = "scrolledwindow1";
            this.scrolledwindow1.VscrollbarPolicy = ((Gtk.PolicyType)(1));
            this.scrolledwindow1.HscrollbarPolicy = ((Gtk.PolicyType)(1));
            this.scrolledwindow1.ShadowType = ((Gtk.ShadowType)(1));
            // Container child scrolledwindow1.Gtk.Container+ContainerChild
            this.fileList = new Gtk.TreeView();
            this.fileList.CanFocus = true;
            this.fileList.Name = "fileList";
            this.fileList.RulesHint = true;
            this.scrolledwindow1.Add(this.fileList);
            this.vbox2.Add(this.scrolledwindow1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.scrolledwindow1]));
            w3.Position = 1;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            this.vbox2.Add(this.hbox2);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox2[this.hbox2]));
            w4.Position = 2;
            w4.Expand = false;
            w4.Fill = false;
            this.Add(this.vbox2);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
        }
    }
}
