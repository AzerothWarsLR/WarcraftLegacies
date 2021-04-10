using AzerothWarsCSharp.Source.Commands;
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
				CheatControl.Initialize();
				CheatFaction.Initialize();
				CheatFood.Initialize();
				CheatGod.Initialize();
				CheatGold.Initialize();
				CheatHasResearch.Initialize();
				CheatHP.Initialize();
				CheatKick.Initialize();
				CheatLevel.Initialize();
				CheatLumber.Initialize();
				CheatMP.Initialize();
				CheatNoCD.Initialize();
				CheatOwner.Initialize();
				CheatRemove.Initialize();
				CheatSkipCinematic.Initialize();
				CheatSpawn.Initialize();
				CheatTeam.Initialize();
				CheatTele.Initialize();
				CheatUncontrol.Initialize();
				CheatUnlimitedMana.Initialize();
				CheatVision.Initialize();
				Console.WriteLine("Hello, Azeroth.");
			}
			catch (Exception ex)
			{
				DisplayTextToPlayer(GetLocalPlayer(), 0, 0, ex.Message);
			}
		}
	}
}
