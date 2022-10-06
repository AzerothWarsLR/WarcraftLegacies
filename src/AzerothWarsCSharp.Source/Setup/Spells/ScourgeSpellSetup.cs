using AzerothWarsCSharp.MacroTools.Spells;
using AzerothWarsCSharp.MacroTools.SpellSystem;

namespace AzerothWarsCSharp.Source.Setup.Spells
{
  public static class ScourgeSpellSetup
  {
    public static void Setup()
    {
      SpellSystem.Register(new SingleTargetRecall(Constants.ABILITY_A0W8_RECALL_FROZEN_THRONE));
    }
  }
}