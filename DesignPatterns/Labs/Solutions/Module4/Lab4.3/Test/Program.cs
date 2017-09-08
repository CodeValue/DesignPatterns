using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paragraphs;

namespace Test {
	class Program {
		static void Main(string[] args) {
			var para = new Paragraph();
			var counter = new CharCounter();
			para.Attach(counter);
			string[] text = { "hello", "this", "is", "a", "test", "of", "paragpraphs" };
			foreach(var s in text)
				para.Add(s);
			Console.WriteLine(para);
		}
	}
}
