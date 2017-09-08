using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mod1.Ex1 {
	public class Manager : Employee {
		public double SalesPercentage { get; set; }

		public Manager(int id)
			: base(id) {
		}

		public override decimal CalculateBonus() {
			return BaseSalary * (decimal)SalesPercentage;
		}

		public override void Display() {
			Console.WriteLine("Manager: {0}: {1}, {2}", Id, LastName, FirstName);
		}
	}
}
