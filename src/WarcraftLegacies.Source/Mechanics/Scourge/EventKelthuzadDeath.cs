using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using WarcraftLegacies.Source.Quests.Scourge;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Mechanics.Scourge
{
  /// <summary>
  ///   When Kel'thuzad (Necromancer) is permanently killed, record his experience, and create Kel'thuzad (Ghost) as a
  ///   replacement.
  ///   This experience is given to Kel'thuzad (Lich) in <see cref="QuestKelthuzad" />.
  /// </summary>
  public static class EventKelthuzadDeath
  {
    public static int KelthuzadExp { get; private set; }

    private static void Dies(object? sender, LegendaryHero legendaryHero)
    {
      if (legendaryHero != LegendScourge.LegendKelthuzad ||
          legendaryHero.UnitType != LegendScourge.UnittypeKelthuzadNecromancer) return;
      KelthuzadExp = GetHeroXP(legendaryHero.Unit);
      legendaryHero.UnitType = LegendScourge.UnittypeKelthuzadGhost;
      legendaryHero.PermaDies = false;
      legendaryHero.ForceCreate(ScourgeSetup.Scourge.Player, Regions.FTSummon.Center,
        270);
      DestroyTrigger(GetTriggeringTrigger());
    }

    public static void Setup()
    {
      LegendScourge.LegendKelthuzad.OnLegendPermaDeath += Dies;
    }
  }
}