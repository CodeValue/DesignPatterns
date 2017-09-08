using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace AddinHost {
	[Export]
	class AddinManager {
		[ImportMany(AllowRecomposition = true)]
		public List<IAddIn> Addins { get; private set; }

		public void InitPlugins() {
			foreach(var addin in Addins)
				addin.Init();
		}

		public void Display() {
			foreach(var addin in Addins)
				Console.WriteLine("Addin: {0}", addin.Name);
		}
	}

	class Program {
		static void Main() {
			DirectoryCatalog dirCat = new DirectoryCatalog(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.dll");
			AggregateCatalog catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()), dirCat);
			CompositionContainer container = new CompositionContainer(catalog);
			AddinManager mgr = container.GetExportedValue<AddinManager>();
			
			// AddinManager mgr = new AddinManager();
			// container.ComposeParts(mgr);

			mgr.InitPlugins();
			mgr.Display();

			Console.WriteLine("Press ENTER to recompose");
			Console.ReadLine();

			// recompose
			dirCat.Refresh();
			mgr.InitPlugins();
			Console.ReadLine();
		}
	}
}
