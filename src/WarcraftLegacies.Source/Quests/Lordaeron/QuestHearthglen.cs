using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Lordaeron
{
  /// <summary>
  /// Bring Uther, get hearthglen.
  /// </summary>
  public sealed class QuestHearthglen : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestHearthglen"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
    public QuestHearthglen(Rectangle rescueRect) : base("Hearthglen",
      "The village of Hearthglen is just nearby. A legendary warrior like Uther would be enough for them to join us",
      "ReplaceableTextures\\CommandButtons\\BTNutherAlt.blp")
    {
      AddObjective(new ObjectiveLegendInRect(LegendLordaeron.Arthas, Regions.Hearthglen, "Hearthglen"));
      AddObjective(new ObjectiveExpire(635));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "The village of Hearthglen has decided to join Uther";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all units in Hearthglen";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction) => 
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction) => 
      completingFaction.Player?.RescueGroup(_rescueUnits);
  }
}