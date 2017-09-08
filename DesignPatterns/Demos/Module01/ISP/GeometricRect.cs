using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISP {
	class GeometricRect : IShape {
		public double Width { get; set; }
		public double Height { get; set; }

		#region IShape Members

		public void Draw(Canvas canvas) {
			throw new NotImplementedException();
		}

		public ConsoleColor Color {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public double Area {
			get { return Width * Height; }
		}

		public double Circumference {
			get { return 2 * (Width + Height); }
		}

		#endregion
	}
}
