using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mod4.Ex6 {
	class Deck {
		List<Card> _cards = new List<Card>(52);

		public Deck() {
			foreach(CardSuit suit in Enum.GetValues(typeof(CardSuit)))
				foreach(CardValue value in Enum.GetValues(typeof(CardValue)))
					_cards.Add(new Card(suit, value));
		}

		public void Shuffle() {
			var rnd = new Random();
			for(int i = 0; i < _cards.Count; ++i) {
				int n1 = rnd.Next(_cards.Count), n2 = rnd.Next(_cards.Count);
				Card t = _cards[n1];
				_cards[n1] = _cards[n2];
				_cards[n2] = t;
			}
		}

		public Card Remove() {
			Card card = _cards[_cards.Count - 1];
			_cards.RemoveAt(_cards.Count - 1);
			return card;
		}
	}
}
