using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking {
	class NameCustomerFactory : ICustomerFactory {
		#region ICustomerFactory Members

		public Customer CreateCustomer(string name) {
			if(name.Split(' ').Length >= 3)
				return new VIPCustomer(name);
			return new Customer(name);
		}

		#endregion
	}
}
