using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Mechanics.Scourge
{
  /// <summary>
  /// When Kel'thuzad (Necromancer) is permanently killed, record his experience, and create Kel'thuzad (Ghost) as a replacement.
  /// This experience is given to Kel'thuzad (Lich) in <see cref="QuestKelthuzadLich"/>.
  /// </summary>
  public static class EventKelthuzadDeath
  {
    public static int KelthuzadExp { get; private set; }
    private static readonly int GhostId = FourCC("uktg");

    private static void Dies(object? sender, Legend legend)
    {
      var kelthuzad = LegendScourge.LegendKelthuzad;
      if (legend == LegendScourge.LegendKelthuzad && legend.UnitType == LegendScourge.UnittypeKelthuzadNecromancer)
      {
        KelthuzadExp = GetHeroXP(legend.Unit);
        legend.UnitType = LegendScourge.UnittypeKelthuzadGhost;
        legend.PermaDies = false;
        legend.Spawn(ScourgeSetup.FACTION_SCOURGE.Player, Regions.FTSummon.Center.X, Regions.FTSummon.Center.Y,
          270);
        DestroyTrigger(GetTriggeringTrigger());
      }
    }

    public static void Setup()
    {
      Legend.OnLegendPermaDeath += Dies;
    }
  }
}