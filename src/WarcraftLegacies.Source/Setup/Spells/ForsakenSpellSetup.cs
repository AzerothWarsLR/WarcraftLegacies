using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class ForsakenSpellSetup
  {
    public static void Setup()
    {
      SpellSystem.Register(new CorruptBuildingSpell(Constants.ABILITY_A0N8_CORRUPT_FORSAKEN, 6, 500));
    }
  }
}