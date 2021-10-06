using AzerothWarsCSharp.Source.Setup;
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
				GameSetup.Initialize();
				Console.WriteLine("Hello, Azeroth.");
			}
			catch (Exception ex)
			{
				DisplayTextToPlayer(GetLocalPlayer(), 0, 0, ex.ToString());
			}
		}
	}
}