using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestControlShadowfang : QuestData
  {
    public QuestControlShadowfang(Capital shadowfang) : base("The Dark Manor",
      "The Legion will need a hidden stronghold to house a demon gate, the Shadowfang Keep is perfectly out of the way for the role.",
      @"ReplaceableTextures\CommandButtons\BTNKeep.blp")
    {
      AddObjective(new ObjectiveControlCapital(shadowfang, false));
    }
    
    /// <inheritdoc/>
    protected override string RewardFlavour => "Shadowfang Keep is now under the Legion control. A secret demon gate has now been formed inside.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Unlock Shadowfang Keep as a troop production building and able to build 1 more Nether Pit.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(FourCC("n04Q"), 4); //Nether Pit
    }
  }
}