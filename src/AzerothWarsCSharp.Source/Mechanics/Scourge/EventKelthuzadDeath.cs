using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Quests.Scourge;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.Scourge
{
  /// <summary>
  ///   When Kel'thuzad (Necromancer) is permanently killed, record his experience, and create Kel'thuzad (Ghost) as a
  ///   replacement.
  ///   This experience is given to Kel'thuzad (Lich) in <see cref="QuestKelthuzad" />.
  /// </summary>
  public static class EventKelthuzadDeath
  {
    public static int KelthuzadExp { get; private set; }

    private static void Dies(object? sender, Legend legend)
    {
      if (legend != LegendScourge.LegendKelthuzad ||
          legend.UnitType != LegendScourge.UnittypeKelthuzadNecromancer) return;
      KelthuzadExp = GetHeroXP(legend.Unit);
      legend.UnitType = LegendScourge.UnittypeKelthuzadGhost;
      legend.PermaDies = false;
      legend.Spawn(ScourgeSetup.FactionScourge.Player, Regions.FTSummon.Center,
        270);
      DestroyTrigger(GetTriggeringTrigger());
    }

    public static void Setup()
    {
      Legend.OnLegendPermaDeath += Dies;
    }
  }
}