using System;
using System.ComponentModel.Composition;
using Common;
using System.Collections.ObjectModel;

namespace HostApp {
	[Export, Export(typeof(IStatus))]
	public class AddinManager : IStatus {
		public AddinManager() {
			MessageLog = new ObservableCollection<string>();
		}

		[ImportMany]
		public ObservableCollection<IAddin> Addins { get; private set; }

		#region IStatus Members

		public void Display(string msg) {
			MessageLog.Add(string.Format("{0}: {1}", DateTime.Now.ToLongTimeString(), msg));
		}

		#endregion

		public ObservableCollection<string> MessageLog { get; private set; }

		public void InitAddins() {
			foreach(var addin in Addins)
				addin.Init();
		}

		public void DoWork() {
			foreach(var addin in Addins)
				addin.DoWork();
		}
	}
}
