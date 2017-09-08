using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mod1.Ex1 {
	public class Employee {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime HireDate { get; set; }
		public int Id { get; private set; }
		public decimal BaseSalary { get; set; }

		public Employee(int id) {
			Id = id;
		}

		public virtual decimal TotalSalary {
			get {
				return BaseSalary + CalculateBonus();
			}
		}

		public virtual decimal CalculateBonus() {
			return 0;
		}

		public virtual void Display() {
			Console.WriteLine("Employee: {0}: {1}, {2}", Id, LastName, FirstName);
		}
	}
}
