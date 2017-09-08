using System;

namespace Mod1.Ex1 {
	public static class DisplayFactory {
		readonly static IEmployeeDisplay _managerDisplay = new ManagerDisplay();
		readonly static IEmployeeDisplay _employeeDisplay = new EmployeeDisplay();

		public static IEmployeeDisplay CreateDisplay(Type employeeType) {
			IEmployeeDisplay display = null;
			if(typeof(Manager).IsAssignableFrom(employeeType))
				display = _managerDisplay;
			else // employee
				display = _employeeDisplay;
			return display;
		}

		public static IEmployeeDisplay CreateDisplay(Employee employee) {
			return CreateDisplay(employee.GetType());
		}
	}
}
