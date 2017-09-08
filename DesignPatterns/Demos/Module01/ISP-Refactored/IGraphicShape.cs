using System;

namespace ISP {
	interface IGraphicShape {
		ConsoleColor Color { get; set; }
		void Draw(Canvas canvas);
	}
}
