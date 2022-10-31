using WarcraftLegacies.MacroTools.Spells;
using WarcraftLegacies.MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class ScourgeSpellSetup
  {
    public static void Setup()
    {
      SpellSystem.Register(new SingleTargetRecall(Constants.ABILITY_A0W8_RECALL_FROZEN_THRONE));
    }
  }
}