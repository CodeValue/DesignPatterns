using System;
using System.Collections.Generic;

namespace Composite.Sample1 {
	class Program {
		static void Main() {
			// Create a tree structure 
			CompositeElement root = new CompositeElement("Picture");
			root.Add(new PrimitiveElement("Red Line"));
			root.Add(new PrimitiveElement("Blue Circle"));
			root.Add(new PrimitiveElement("Green Box"));

			// Create a branch
			CompositeElement comp = new CompositeElement("Two Circles");
			comp.Add(new PrimitiveElement("Black Circle"));
			comp.Add(new PrimitiveElement("White Circle"));
			root.Add(comp);

			// Add and remove a PrimitiveElement
			PrimitiveElement pe =
				 new PrimitiveElement("Yellow Line");
			root.Add(pe);
			root.Remove(pe);

			// Recursively display nodes
			root.Display(1);

			Console.WriteLine();
		}
	}

	// The 'Component' class
	abstract class DrawingElement {
		public string Name { get; private set; }

		// Constructor
		public DrawingElement(string name) {
			Name = name;
		}

		public abstract void Add(DrawingElement d);
		public abstract void Remove(DrawingElement d);
		public abstract void Display(int indent);
	}

	// The 'Leaf' class
	class PrimitiveElement : DrawingElement {
		// Constructor
		public PrimitiveElement(string name)
			: base(name) {
		}

		public override void Add(DrawingElement c) {
			Console.WriteLine("Cannot add to a PrimitiveElement");
		}

		public override void Remove(DrawingElement c) {
			Console.WriteLine("Cannot remove from a PrimitiveElement");
		}

		public override void Display(int indent) {
			Console.WriteLine(new String('-', indent) + " " + Name);
		}
	}

	// The 'Composite' class
	class CompositeElement : DrawingElement {
		private List<DrawingElement> elements =
			 new List<DrawingElement>();

		// Constructor
		public CompositeElement(string name)
			: base(name) {
		}

		public override void Add(DrawingElement d) {
			elements.Add(d);
		}

		public override void Remove(DrawingElement d) {
			elements.Remove(d);
		}

		public override void Display(int indent) {
			Console.WriteLine(new String('-', indent) + "+ " + Name);

			// Display each child element on this node
			foreach(DrawingElement d in elements) {
				d.Display(indent + 2);
			}
		}
	}
}
