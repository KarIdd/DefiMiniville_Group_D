using System;

namespace Defi_MiniVille
{
	public struct Card
	{
		public Card(int Id, string Color, int Cost, string Name, string Effect, int Dice, int Gain)
		{
			this.Id = Id;
			this.Color = Color;
			this.Cost = Cost;
			this.Name = Name;
			this.Effect = Effect;
			this.Dice = Dice;
			this.Gain = Gain;
		}

		public int Id { get; set; }
		public string Color { get; set; }
		public int Cost { get; set; }
		public string Name { get; set; }
		public string Effect { get; set; }
		public int Dice { get; set; }
		public int Gain { get; set; }
	}
}
