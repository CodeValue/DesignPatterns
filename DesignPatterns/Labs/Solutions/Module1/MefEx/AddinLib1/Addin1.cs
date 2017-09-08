using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.ComponentModel.Composition;

namespace AddinLib1 {
	[Export(typeof(IAddin))]
	public class Addin1 : IAddin {
		#region IAddin Members

		public bool Init() {
			_status.Display("Addin1 initialized");
			return true;
		}

		public void DoWork() {
			_status.Display("Addin1 doing some work...");
		}

		#endregion

		[Import]
		readonly IStatus _status;

		public override string ToString() {
			return "Addin 1";
		}
	}
}
