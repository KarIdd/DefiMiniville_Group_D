using System;

namespace Defi_Miniville
{
	public struct CardsInfo
	{
		public CardsInfo(int Id, string Color, int Cost, string Name, int Number, string Effect, int Dice, int Gain)
		{
			this.Id = Id;
			this.Color = Color;
			this.Cost = Cost;
			this.Name = Name;
			this.Number = Number;
			this.Effect = Effect;
			this.Dice = Dice;
			this.Gain = Gain;
		}

		public int Id { get; set; }
		public string Color { get; set; }
		public int Cost { get; set; }
		public string Name { get; set; }
		public int Number { get; set; }
		public string Effect { get; set; }
		public int Dice { get; set; }
		public int Gain { get; set; }
	}
}
