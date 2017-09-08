using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISP {
	public interface IGeometricShape {
		double Area { get; }
		double Circumference { get; }
	}
}
