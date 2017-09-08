using System;
using System.Collections.Generic;

namespace Mediator.Sample1 {
	class Program {
		/// <summary>
		/// Entry point into console application.
		/// </summary>
		static void Main() {
			// Create chatroom participants
			Participant George = new Beatle { Name = "George" };
			Participant Paul = new Beatle { Name = "Paul" };
			Participant Ringo = new Beatle { Name = "Ringo" };
			Participant John = new Beatle { Name = "John" };
			Participant Yoko = new NonBeatle { Name = "Yoko" };

			// Create chatroom and register participants
			var chatroom = new Chatroom();
			chatroom.Register(George);
			chatroom.Register(Paul);
			chatroom.Register(Ringo);
			chatroom.Register(John);
			chatroom.Register(Yoko);

			// Chatting participants
			Yoko.Send("John", "Hi John!");
			Paul.Send("Ringo", "All you need is love");
			Ringo.Send("George", "My sweet Lord");
			Paul.Send("John", "Can't buy me love");
			John.Send("Yoko", "My sweet love");

		}
	}

	// The 'Mediator' interface
	interface IChatroom {
		void Register(Participant participant);
		void Send(string from, string to, string message);
	}

	// The 'ConcreteMediator' class
	class Chatroom : IChatroom {
		private Dictionary<string, Participant> _participants =
			 new Dictionary<string, Participant>();

		public void Register(Participant participant) {
			if(!_participants.ContainsKey(participant.Name)) {
				_participants.Add(participant.Name, participant);
			}

			participant.Chatroom = this;
		}

		public void Send(string from, string to, string message) {
			var participant = _participants[to];
			if(participant != null) {
				participant.Receive(from, message);
			}
		}
	}

	// The 'AbstractColleague' class
	class Participant {
		// Gets or sets participant name
		public string Name { get; set; }

		// Gets or sets chatroom
		public Chatroom Chatroom { get; set; }

		// Send a message to given participant
		public void Send(string to, string message) {
			Chatroom.Send(Name, to, message);
		}

		// Receive message from participant
		public virtual void Receive(
			 string from, string message) {
			Console.WriteLine("{0} to {1}: '{2}'",
				 from, Name, message);
		}
	}

	// A 'ConcreteColleague' class
	class Beatle : Participant {
		public override void Receive(string from, string message) {
			Console.Write("To a Beatle: ");
			base.Receive(from, message);
		}
	}

	// A 'ConcreteColleague' class
	class NonBeatle : Participant {
		public override void Receive(string from, string message) {
			Console.Write("To a non-Beatle: ");
			base.Receive(from, message);
		}
	}
}
