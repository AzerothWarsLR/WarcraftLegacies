using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Naga
{
  public sealed class QuestAetheneumTomb : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestAetheneumTomb(Rectangle rescueRect) : base("The Secrets of Dire Maul",
      "Illidan has heard of Highborns secrets hiding in the depths of the Dire Maul. If he could uncover them, they could be a source of great power.",
      "ReplaceableTextures\\CommandButtons\\BTNDoomlord.blp")
    {
      AddObjective(new ObjectiveLegendDead(LegendNeutral.Immolthar));
      AddObjective(new ObjectiveExpire(1280));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R07H_QUEST_COMPLETED_THE_SECRETS_OF_DIRE_MAUL;

      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      Required = true;
    }

    //Todo: bad flavour
    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Illidan has seized control of the Aethenem Catacombs. The Sea Witch Lady Vashj and her Naga have joined him.";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all buildings and units in the Aetheneum Catacombs as well as the ability to train Lady Vashj and Naga Units";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      PlayThematicMusic("IllidansTheme");
      completingFaction.Player?.RescueGroup(_rescueUnits);
    }
  }
}