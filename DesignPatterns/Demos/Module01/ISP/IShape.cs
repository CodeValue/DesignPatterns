using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISP {
	public interface IShape {
		void Draw(Canvas canvas);
		ConsoleColor Color { get; set; }

		double Area { get; }
		double Circumference { get; }
	}
}
