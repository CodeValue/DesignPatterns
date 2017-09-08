using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAttributes {
	[CodeReview("Peter Parker", "11/2/2007", true)]
	[CodeReview("Bart Simpson", "1/1/2008", false)]
	[CodeReview("Clark Kent", "1/1/2000", true)]
	[Serializable]
	public class A {
	}

	[CodeReview("Donald Duck", "1/3/2002", true)]
	public struct B {
	}

	[CodeReview("Winnie the Pooh", "3/12/2005", false)]
	[CodeReview("Micky Mouse", "3/3/3000", true)]
	public class C {
	}

	public struct D {
	}
}
