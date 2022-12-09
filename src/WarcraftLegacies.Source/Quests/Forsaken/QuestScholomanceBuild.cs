using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Forsaken
{
  public sealed class QuestScholomanceBuild : QuestData
  {
    private readonly List<unit> _rescueUnits;

    public QuestScholomanceBuild() : base("Secret Buildup",
      "The Scholomance is the secret staging ground for the invasion of Lordaeron, build your infrastructure and be ready for war.",
      "ReplaceableTextures\\CommandButtons\\BTNAffinityII.blp")
    {
      AddObjective(new ObjectiveBuild(FourCC("u011"), 2));
      AddObjective(new ObjectiveBuild(FourCC("h08C"), 20));
      AddObjective(new ObjectiveBuild(FourCC("u014"), 1));
      AddObjective(new ObjectiveBuild(FourCC("u01J"), 2));
      AddObjective(new ObjectiveUpgrade(FourCC("h08B"), FourCC("h089")));
      _rescueUnits = Regions.ShadowvaultUnlock.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      ResearchId = FourCC("R04Z");
      Required = true;
    }

    //Todo: bad flavour
    protected override string CompletionPopup => "Putress is now trainable.";

    protected override string RewardDescription => "Putress is trainable at the altar";
    
    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player?.RescueGroup(_rescueUnits);
    }
    
    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }
  }
}