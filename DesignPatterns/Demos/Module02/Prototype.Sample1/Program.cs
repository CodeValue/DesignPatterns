using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace Prototype.Sample1 {
	[Serializable]
	abstract class Widget {
		public int Height { get; set; }
		public int Width { get; set; }
		public string ID { get; set; }
		public abstract Widget Clone();
	}

	[Serializable]
	class Button : Widget {
		public override Widget Clone() {
			// make a shallow copy
			return MemberwiseClone() as Widget;
		}

		public override string ToString() {
			return string.Format("Button ID={0}, Width={1}, Height={2}", ID, Width, Height);
		}
	}

	[Serializable]
	class Border : Widget {
		Widget _content;

		public Border(Widget content) {
			_content = content;
		}

		public override Widget Clone() {
			// make a deep copy
			Widget clone = null;
			using(var stm = new MemoryStream()) {
				var formatter = new BinaryFormatter();
				formatter.Serialize(stm, this);
				stm.Position = 0;
				clone = (Widget)formatter.Deserialize(stm);
			}
			return clone;
		}

		public override string ToString() {
			return string.Format("Border ID={0}, Width={1}, Height={2}\n\tContent={3}",
				ID, Width, Height, _content);
		}
	}

	class Window {
		HashSet<Widget> _widgets = new HashSet<Widget>();

		public void Add(Widget widget) {
			_widgets.Add(widget);
		}

		public void Dump() {
			foreach(var widget in _widgets)
				Console.WriteLine(widget);
		}

	}

	class WindowManager {
		public Window CreateUI() {
			var win = new Window();
			Button b1 = new Button { ID = "b1", Width = 100, Height = 30 };
			win.Add(b1);
			Button b2 = new Button { ID = "b2", Width = 120, Height = 50 };
			Widget b3;
			win.Add(b3 = b1.Clone());
			Border b4 = new Border(new Button { ID = "b4", Width = 60, Height = 80 }) {
				Height = 30,
				Width = 300,
				ID = "bor1"
			};
			win.Add(b4);
			win.Add(b4.Clone());

			return win;
		}
	}

	class Program {
		static void Main() {
			var mgr = new WindowManager();
			var win = mgr.CreateUI();
			win.Dump();
		}

		public static object DeepCopy(object prototype) {
			using(var stm = new MemoryStream()) {
				var formatter = new BinaryFormatter();
				formatter.Serialize(stm, prototype);
				stm.Position = 0;
				return formatter.Deserialize(stm);
			}
		}
	}

}
