using System;

namespace Common {
	public interface IAddin {
		bool Init();
		void DoWork();
	}
}
