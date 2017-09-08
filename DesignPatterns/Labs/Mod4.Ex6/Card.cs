using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mod4.Ex6 {
	enum CardSuit {
		Spades, Hearts, Clubs, Diamonds
	}

	enum CardValue {
		Ace = 1,
		Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
		Jack, Queen, King
	}

	class Card {
		public CardSuit Suit { get; private set; }
		public CardValue Value { get; private set; }

		public Card(CardSuit suit, CardValue value) {
			Suit = suit; Value = value;
		}
	}
}
