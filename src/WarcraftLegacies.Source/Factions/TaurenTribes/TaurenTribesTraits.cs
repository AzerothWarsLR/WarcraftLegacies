using WarcraftLegacies.Source.Shared.UnitTraits;

namespace WarcraftLegacies.Source.Factions.TaurenTribes;

public static class TaurenTribesTraits
{
  public static void Setup()
  {
    new MultishotAttack
    {
      ExtraTargets = 2,
      Radius = 300,
      MissilePath = @"Abilities\Spells\Other\Volcano\VolcanoMissile.mdl"
    }.Register(UNIT_OTVW_VOLCANO_WARD_TAUREN_TRIBES);

  }
}
