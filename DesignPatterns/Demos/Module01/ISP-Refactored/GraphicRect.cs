using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISP {
	class GraphicRect : IGraphicShape {
		#region IGraphicShape Members

		public ConsoleColor Color { get; set; }

		public void Draw(Canvas canvas) {
			//...
		}

		#endregion
	}
}
