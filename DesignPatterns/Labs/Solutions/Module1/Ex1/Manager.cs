using System;

namespace Mod1.Ex1 {
	public class Manager : Employee {
		public double SalesPercentage { get; set; }

		public override decimal CalculateBonus() {
			return BaseSalary * (decimal)SalesPercentage;
		}

	}
}
