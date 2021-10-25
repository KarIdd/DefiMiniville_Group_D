using System.Collections.Generic;

namespace Defi_Miniville
{
	public class Card
	{
		public static Dictionary<int, CardsInfo> deck = new Dictionary<int, CardsInfo>();

		public void AddCard(int Id, string Color, int Cost, string Name, int Number, string Effect, int MinDice, int MaxDice, int Gain)
		{
			deck.Add(Id, new CardsInfo(Id, Color, Cost, Name, Number, Effect, MinDice, MaxDice, Gain));
		}

		public static CardsInfo GetCard(int Id)
		{
			return deck[Id];
		}

		public void CreateDeck(Card card)
		{
			card.AddCard(0, "Blue", 1, "Wheat field", 6, "Get 1 coin", 1, 1, 1);
			card.AddCard(1, "Blue", 2, "Farm", 6, "Get 1 coin", 1, 1, 2);
			card.AddCard(2, "Green", 1, "Baker's shop", 6, "Get 2 coins", 2, 3, 2);
			card.AddCard(3, "Red", 2, "Café", 6, "Get 1 coin from the player that rolled the die", 3, 3, 1);
			card.AddCard(4, "Green", 2, "Grocery", 6, "Get 3 coins", 4, 4, 3);
			card.AddCard(5, "Blue", 3, "Forest", 6, "Get 1 coin", 5, 5, 1);
			card.AddCard(6, "Red", 4, "Restaurant", 6, "Get 2 coins from the player that rolled the die", 5, 5, 2);
			card.AddCard(7, "Blue", 6, "Stadium", 4, "Get 4 coins", 6, 6, 4);
			card.AddCard(8, "Green", 8, "Business center", 4, "Get 6 coins", 6, 6, 6);
			card.AddCard(9, "Green", 7, "TV station", 4, "Get 5 coins from the player that rolled the die", 6, 6, 5);
			card.AddCard(10, "Green", 5, "")

		}
	}
}