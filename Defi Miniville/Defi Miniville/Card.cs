using System.Collections.Generic;

namespace Defi_Miniville
{
	public class Card
	{
		public static Dictionary<int, CardsInfo> CardShop = new Dictionary<int, CardsInfo>();
		private static List<string> cardNames;


		public void AddCard(int Id, string Color, int Cost, string Name, int Number, string Effect, int MinDice, int MaxDice, int Gain)
		{
			CardShop.Add(Id, new CardsInfo(Id, Color, Cost, Name, Number, Effect, MinDice, MaxDice, Gain));
		}

		public static CardsInfo GetCard(int Id)
		{
			return CardShop[Id];
		}

		public static List<string> GetCardNames(int Id)
		{
			for (int i = 0; i < CardShop.Count; i++)
			{
				cardNames.Add(CardShop[Id].Name);
			}
			return cardNames;
		}

		public void CreateDeck(Card card)
		{
			card.AddCard(0, "Blue", 1, "Wheat field", 6, "Get 1 coin", 1, 1, 1);
			card.AddCard(1, "Blue", 2, "Farm", 6, "Get 1 coin", 1, 1, 2);
			card.AddCard(2, "Green", 1, "Baker's shop", 6, "Get 2 coins", 2, 3, 2);
			card.AddCard(3, "Red", 2, "Café", 6, "Get 1 coin from the player that rolled the die", 3, 3, 1);
			card.AddCard(4, "Green", 2, "Grocery", 6, "Get 3 coins", 4, 4, 3);
			card.AddCard(5, "Blue", 3, "Forest", 6, "Get 1 coin", 5, 5, 1);
			card.AddCard(6, "Red", 4, "Restaurant", 6, "Get 2 coins from the player that rolled the die", 9, 10, 2);
			card.AddCard(7, "Blue", 6, "Stadium", 4, "Get 4 coins", 6, 6, 4);
			card.AddCard(8, "Green", 8, "Business center", 4, "Get 6 coins", 6, 6, 6);
			card.AddCard(9, "Red", 7, "TV station", 4, "Get 5 coins from the player that rolled the die", 6, 6, 5);
			card.AddCard(10, "Green", 5, "Dairy", 6, "Get 3 coins foreach shop that you have", 7, 7, 0);
			card.AddCard(11, "Green", 3, "Furniture factory", 6, "Get 3 coins foreach forest or mine that you have", 8, 8, 0);
			card.AddCard(12, "Blue", 6, "Mine", 6, "Get 5 coins", 9, 9, 5);
			card.AddCard(13, "Blue", 3, "Orchard", 6, "Get 3 coins", 10, 10, 3);
			card.AddCard(14, "Green", 2, "Greengrocer's", 6, "Get 2 coins foreach wheat field and orchard that you have", 11, 12, 0);
		}
	}
}