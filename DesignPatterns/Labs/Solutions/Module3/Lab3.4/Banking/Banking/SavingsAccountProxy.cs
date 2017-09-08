using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking {
	class SavingsAccountProxy : SavingsAccount {
		SavingsAccount _realAccount;
		readonly Guid _number;

		public SavingsAccountProxy(Guid number) : base(number) {
			_number = number;
		}

		public override void Deposit(decimal amount) {
			CreateAccount();
			_realAccount.Deposit(amount);
		}

		public override void Withdraw(decimal amount) {
			CreateAccount();
			_realAccount.Withdraw(amount);
		}

		public override decimal Balance {
			get {
				CreateAccount();
				return _realAccount.Balance;
			}
			protected internal set {
				CreateAccount();
				_realAccount.Balance = value;
			}
		}
		private void CreateAccount() {
			if(_realAccount == null)
				_realAccount = new SavingsAccount(_number);
		}
	}
}
