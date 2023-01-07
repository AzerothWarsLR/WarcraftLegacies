using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Naga
{
  /// <summary>
  /// Bring <see cref="LegendNaga.LegendIllidan"/> to <see cref="LegendFelHorde.LegendBlacktemple"/> to gain control of it.
  /// </summary>
  public sealed class QuestBlackTemple : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestBlackTemple"/> class.
    /// </summary>
    /// <param name="rescueRect"></param>
    public QuestBlackTemple(Rectangle rescueRect) : base("Seat of Power",
      "Illidan requires the aid of his servants in outland for the upcoming war. He must travel to outland to muster them. His incredible power allows him to move between worlds with ease.",
      "ReplaceableTextures\\CommandButtons\\BTNWarpPortal.blp")
    {
      AddObjective(new ObjectiveLegendInRect(LegendNaga.LegendIllidan, Regions.IllidanBlackTempleUnlock, "Black Temple"));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures,
        filterUnit => filterUnit.GetTypeId() != Constants.UNIT_N066_INFERNAL_JUGGERNAUT_TEAL_TOWER);
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "The forces of Outland are now under Illidan's Command!";

    /// <inheritdoc />
    protected override string RewardDescription => "Gain control of the Black Temple.";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player?.RescueGroup(_rescueUnits);
    }
  }
}