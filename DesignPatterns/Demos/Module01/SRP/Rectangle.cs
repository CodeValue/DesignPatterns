using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRP {
	public class Rectangle {
		public double Width { get; set; }
		public double Height { get; set; }

		public void Draw(Canvas canvas) {
			//...
		}

		public double Area {
			get { return Width * Height; }
		}
	}
}
