using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.FactionMechanics.QuelThalas;
using WarcraftLegacies.Source.Powers;

namespace WarcraftLegacies.Source.Quests.Quelthalas
{
  public sealed class QuestDestroyCorruptedSunwell : QuestData
  {
    private readonly CorruptedSunwell _corruptedSunwellPower;

    /// <inheritdoc />
    public QuestDestroyCorruptedSunwell(Capital theSunwell, CorruptedSunwell corruptedSunwellPower) : base("Forever Dusk", 
      "The necrotic taint at the heart of the Sunwell now permeates not only our people, but all we have built. The sacrifice we must now make is grave but inevitable: the Sunwell will be destroyed.",
      @"ReplaceableTextures\CommandButtons\BTNWispSplode.blp")
    {
      _corruptedSunwellPower = corruptedSunwellPower;
      AddObjective(new ObjectiveCastSpellFromUnit(ABILITY_A00D_DESTROY_THE_CORRUPTED_SUNWELL_QUEL_THALAS_SUNWELL, theSunwell.Unit!));
    }
    
    /// <inheritdoc/>
    protected override string RewardDescription => "Lose the Corrupted Sunwell power";
    
    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.RemovePower(_corruptedSunwellPower);
      TheSunwell.Destroy();
    }
    
    /// <inheritdoc />
    protected override void OnAdd(Faction faction)
    {
      faction.ModAbilityAvailability(ABILITY_A00D_DESTROY_THE_CORRUPTED_SUNWELL_QUEL_THALAS_SUNWELL, 1);
    }
  }
}