using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace SimpleMEF {
	public class Bank {
		[Import]
		public IAccount Account { get; set; }
	}
}
