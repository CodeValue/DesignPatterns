using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailSystem {
	public class MailArrivedEventArgs : EventArgs {
		private readonly string _title;
		private readonly string _body;

		internal MailArrivedEventArgs(string title, string body) {
			_title = title; _body = body;
		}

		public string Title { get { return _title; } }
		public string Body { get { return _body; } }
	}

	public class MailManager {
		public event EventHandler<MailArrivedEventArgs> MailArrived;

		protected virtual void OnMailArrived(MailArrivedEventArgs e) {
			if(MailArrived != null)
				MailArrived(this, e);
		}

		private int _count = 0;
		internal void SimulateMailArrived() {
			_count++;
			OnMailArrived(new MailArrivedEventArgs("Some title", 
				"some body " + _count.ToString()));
		}
	}
}
