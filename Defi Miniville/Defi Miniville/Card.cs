using System;
using System.Collections.Generic;

namespace Defi_Miniville
{
	public class Card
	{
		List<CardsInfo> deck = new List<CardsInfo>();

		public void AddCard(int Id, string Color, int Cost, string Name, int Number, string Effect, int MinDice, int MaxDice, int Gain)
		{
			deck.Add(new CardsInfo(Id, Color, Cost, Name, Number, Effect, MinDice, MaxDice, Gain));
		}

		public static CardsInfo GetCard(int Id)
		{
			switch (Id)
            {
				case 0 : 
					return new CardsInfo(0, "Bleue", 2, "Champs de blé", 7, "Gagne des pièces", 5, 7, 2);
				case 1:
					return new CardsInfo(1, "Vert", 2, "zoicnoiz");
            }

		}
	}
}