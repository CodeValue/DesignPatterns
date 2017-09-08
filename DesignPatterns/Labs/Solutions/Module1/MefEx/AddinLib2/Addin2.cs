using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Common;

namespace AddinLib2 {
	[Export(typeof(IAddin))]
	public class Addin2 : IAddin {
		#region IAddin Members

		public bool Init() {
			_status.Display("Addin2 initialized");
			return true;
		}

		public void DoWork() {
			_status.Display("Addin2 doing some work...");
		}

		#endregion

		[Import]
		IStatus _status;

		public override string ToString() {
			return "Addin 2";
		}
	}
}
