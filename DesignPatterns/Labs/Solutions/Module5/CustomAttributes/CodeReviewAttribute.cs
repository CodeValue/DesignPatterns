using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAttributes {
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	public sealed class CodeReviewAttribute : Attribute {
		private readonly string _name;
		public string Name {
			get { return _name; }
		}

		private readonly DateTime _reviewDate;
		public DateTime ReviewDate {
			get { return _reviewDate; }
		}

		private readonly bool _approved;
		public bool Approved {
			get { return _approved; }
		}

		public CodeReviewAttribute(string name, string date, bool approved) {
			_name = name;
			_reviewDate = DateTime.Parse(date);
			_approved = approved;
		}

	}

}
