using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking {
	class VIPCustomer : Customer {
		public VIPCustomer(string name)
			: base(name) {
				BaseLimitFactor = 2.0;
		}
	}
}
