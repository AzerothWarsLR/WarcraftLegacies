using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source
{
	public static class Program
	{
		public static void Main()
		{
			// Delay a little since some stuff can break otherwise
			var timer = CreateTimer();
			TimerStart(timer, 0.01f, false, () =>
			{
				DestroyTimer(timer);
				Start();
			});
		}

		private static void Start()
		{
			try
			{
				CreateUnit(Player(0), FourCC("zpea"), 0, 0, 0); //Peasant
				CreateUnit(Player(0), FourCC("zfoo"), 0, 0, 0); //Footman
				CreateUnit(Player(0), FourCC("zkni"), 0, 0, 0); //Knight
				CreateUnit(Player(0), FourCC("Zart"), 0, 0, 0); //Arthas
				CreateUnit(Player(0), FourCC("zmor"), 0, 0, 0); //Mortar Team
				CreateUnit(Player(0), FourCC("zfly"), 0, 0, 0); //Flying Machine
				CreateUnit(Player(0), FourCC("zgry"), 0, 0, 0); //Gryphon Rider
				CreateUnit(Player(0), FourCC("zpri"), 0, 0, 0); //Priest
				CreateUnit(Player(0), FourCC("zsor"), 0, 0, 0); //Sorceress
				Console.WriteLine("Hello, Azeroth.");
			}
			catch (Exception ex)
			{
				DisplayTextToPlayer(GetLocalPlayer(), 0, 0, ex.ToString());
			}
		}
	}
}