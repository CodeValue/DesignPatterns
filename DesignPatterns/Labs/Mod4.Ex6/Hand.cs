using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mod4.Ex6 {
	class Hand {
		List<Card> _cards = new List<Card>();

		public void AddCard(Card card) {
			_cards.Add(card);
		}

		public Card this[int index] {
			get { return _cards[index]; }
		}
	}
}
