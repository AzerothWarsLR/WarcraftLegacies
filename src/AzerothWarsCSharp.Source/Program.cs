using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Spells;
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
				CreateUnit(Player(0), FourCC("ksea"), 0, 0, 0);
				CreateUnit(Player(0), FourCC("kdec"), 0, 0, 0);
				CreateUnit(Player(0), FourCC("ktid"), 0, 0, 0);
				CreateUnit(Player(0), FourCC("kbla"), 0, 0, 0);
				CreateUnit(Player(0), FourCC("drag"), 0, 0, 0);

				CreateUnit(Player(0), FourCC("ksco"), 100, 0, 0);
				CreateUnit(Player(0), FourCC("kgua"), 100, 200, 0);
				CreateUnit(Player(0), FourCC("kcan"), 100, 400, 0);
				unit blademaster = CreateUnit(Player(0), FourCC("Yakb"), 100, 400, 0);
				SetHeroLevel(blademaster, 10, true);
				unit kazzak = CreateUnit(Player(0), FourCC("Kazz"), 100, 400, 0);
				SetHeroLevel(kazzak, 10, true);
				unit arthas = CreateUnit(Player(0), FourCC("Bang"), 100, 400, 0);
				SetHeroLevel(arthas, 10, true);
				MassAnySpell.Initialize();
				//GameSetup.Initialize();
				Console.WriteLine("Hello, Azeroth.");
			}
			catch (Exception ex)
			{
				DisplayTextToPlayer(GetLocalPlayer(), 0, 0, ex.ToString());
			}
		}
	}
}