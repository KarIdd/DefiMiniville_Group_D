using System;
using System.Collections.Generic;

namespace Defi_Miniville
{
	public class Card
	{
		List<CardsInfo> deck = new List<CardsInfo>();

		public void AddCard(int Id, string Color, int Cost, string Name, int Number, string Effect, int MinDice, int MaxDice, int Gain)
        {
			deck.Add(CardsInfo(Id, Color, Cost, Name, Number, Effect, MinDice, MaxDice, Gain));
        }
	}
}
