using System;
using System.Collections.Generic;

namespace Flyweight.Sample1 {
	class Program {
		/// <summary>
		/// Entry point into console application.
		/// </summary>
		static void Main() {
			// Build a document with text
			string document = "AAZZBBZB";
			char[] chars = document.ToCharArray();

			var factory = new CharacterFactory();

			// extrinsic state
			int pointSize = 10;

			// For each character use a flyweight object
			foreach(char c in chars) {
				var character = factory[c];
				character.Display(++pointSize);
			}
		}
	}

	// The 'FlyweightFactory' class
	class CharacterFactory {
		private Dictionary<char, Character> _characters = new Dictionary<char, Character>();

		// Character indexer
		public Character this[char key] {
			get {
				// Uses "lazy initialization" -- i.e. only create when needed.
				Character character = null;
				if(_characters.ContainsKey(key)) {
					character = _characters[key];
				}
				else {
					// Instead of a case statement with 26 cases (characters).
					// First, get qualified class name, then dynamically create instance 
					string name = this.GetType().Namespace + "." +
										  "Character" + key.ToString();
					character = (Character)Activator.CreateInstance
										  (Type.GetType(name));
				}

				return character;
			}
		}
	}

	// The 'Flyweight' class
	class Character {
		protected char symbol;
		protected int width;
		protected int height;
		protected int ascent;
		protected int descent;

		public void Display(int pointSize) {
			Console.WriteLine(this.symbol +
						 " (pointsize " + pointSize + ")");
		}

	}

	// A 'ConcreteFlyweight' class
	class CharacterA : Character {
		public CharacterA() {
			this.symbol = 'A';
			this.height = 100;
			this.width = 120;
			this.ascent = 70;
			this.descent = 0;
		}
	}

	// A 'ConcreteFlyweight' class
	class CharacterB : Character {
		public CharacterB() {
			this.symbol = 'B';
			this.height = 100;
			this.width = 140;
			this.ascent = 72;
			this.descent = 0;
		}
	}

	// ... C, D, E, etc.

	// A 'ConcreteFlyweight' class
	class CharacterZ : Character {
		public CharacterZ() {
			this.symbol = 'Z';
			this.height = 100;
			this.width = 100;
			this.ascent = 68;
			this.descent = 0;
		}
	}
}
