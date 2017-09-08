using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace HostApp {
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application {
		protected override void OnStartup(StartupEventArgs e) {
			using(var addinDirCatalog = new DirectoryCatalog(@"..\..\..\Addins", "*.dll")) {
				var catalog = new AggregateCatalog(addinDirCatalog, new AssemblyCatalog(Assembly.GetExecutingAssembly()));
				var container = new CompositionContainer(catalog);
				AddinManager mgr = container.GetExportedValue<AddinManager>();
				MainWindow win = new MainWindow(mgr);
				win.Show();
			}
		}
	}
}
