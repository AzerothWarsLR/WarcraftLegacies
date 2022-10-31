using System;
using System.Diagnostics.CodeAnalysis;
using WarcraftLegacies.TestSource.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.TestSource
{
	public static class Program
	{
		[SuppressMessage("ReSharper", "UnusedMember.Global")]
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
				Console.WriteLine("Starting setup.");
				GameSetup.Setup();
				Console.WriteLine("Setup finished.");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}