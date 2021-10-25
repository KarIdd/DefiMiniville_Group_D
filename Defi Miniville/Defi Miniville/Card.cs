using System;
using System.Collections.Generic;

namespace Defi_Miniville
{
	public class Card
	{
		public static List<CardsInfo> deck = new List<CardsInfo>();

		public Card()
        {

        }

		public void AddCard(int Id, string Color, int Cost, string Name, int Number, string Effect, int MinDice, int MaxDice, int Gain)
		{
			deck.Add(new CardsInfo(Id, Color, Cost, Name, Number, Effect, MinDice, MaxDice, Gain));
		}

		public CardsInfo GetCard(int Id)
		{
			return (deck[Id]);
		}

		public void CreateDeck()
        {
			Card card = new Card();
			card.AddCard(0, "Blue", 1, "Wheat field", 6, "Get 1 coin", 1, 1, 1);
			card.AddCard(1, "Blue", 2, "Farm", 6, "Get 1 coin", 1, 1, 1);
			card.AddCard(2, "Green", 1, "Baker's shop", 6, "Get 1 coin", 1, 1, 1);
			card.AddCard(3, "Red", 2, "Café", 6, "Get 1 coin", 1, 1, 1);
			card.AddCard(4, "Green", 2, "Wheat field", 6, "Get 1 coin", 1, 1, 1);
			card.AddCard(5, "Blue", 2, "Wheat field", 6, "Get 1 coin", 1, 1, 1);
			card.AddCard(6, "Red", 4, "Wheat field", 6, "Get 1 coin", 1, 1, 1);
			card.AddCard(7, "Blue", 6, "Wheat field", 6, "Get 1 coin", 1, 1, 1);
		}
	}
}