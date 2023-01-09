using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.QuestSystem;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Goblin
{
  /// <summary>
  /// The Goblins can acquire Kezan.
  /// </summary>
  public sealed class QuestBusinessExpansion : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestBusinessExpansion"/>.
    /// </summary>
    public QuestBusinessExpansion() : base("Business Expansion",
      "Trade Prince Gallywix will need a great amount of wealth to join the Goblin Empire; he needs to expand his business all over the world quickly.",
      "ReplaceableTextures\\CommandButtons\\BTNGoblinPrince.blp")
    {
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N05C_GADGETZAN_10GOLD_MIN), 10));
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N0A6_RATCHET_10GOLD_MIN), 10));
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N09D_AUBERDINE_25GOLD_MIN), 10));
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N05U_FEATHERMOON_STRONGHOLD_20GOLD_MIN), 10));
      ResearchId = Constants.UPGRADE_R07G_QUEST_COMPLETED_BUSINESS_EXPANSION;
      Required = true;
      _rescueUnits = Regions.KezanUnlock.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures,
        filterUnit => filterUnit.GetTypeId() != FourCC("ngme"));
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "Our trade empire has grown large enough to earn the attention of the Trade Princes of Kezan. Their investments are already flowing in, and the isle of Kezan is now under Bilgewater control.";

    /// <inheritdoc />
    protected override string RewardDescription => "You unlock Kezan and can now train Traders";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player?.RescueGroup(_rescueUnits);
      if (GetLocalPlayer() == completingFaction.Player) 
        PlayThematicMusic("war3mapImported\\GoblinTheme.mp3");
    }
  }
}