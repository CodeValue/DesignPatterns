using System;

namespace Mod1.Ex1 {
	public class Employee : IEquatable<Employee> {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime HireDate { get; set; }
		public int Id { get; internal set; }
		public decimal BaseSalary { get; set; }

		public virtual decimal TotalSalary {
			get {
				return BaseSalary + CalculateBonus();
			}
		}

		public virtual decimal CalculateBonus() {
			return 0;
		}


		#region IEquatable<Employee> Members

		public bool Equals(Employee other) {
			return Id == other.Id;
		}
		#endregion

		public override bool Equals(object obj) {
			return Equals((Employee)obj);
		}

		public override int GetHashCode() {
			return Id;
		}
	}

}
