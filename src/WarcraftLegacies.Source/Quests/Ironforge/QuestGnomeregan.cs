using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Ironforge
{
  /// <summary>
  /// Kill a specific to unlock Gnomeregan
  /// </summary>
  public sealed class QuestGnomeregan : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestGnomeregan"/> class.
    /// </summary>
    /// <param name="rescueRect"></param>
    public QuestGnomeregan(Rectangle rescueRect) : base("The City of Invention",
      "The people of Gnomeregan have long been unable to assist the Alliance in its wars due an infestation of troggs and Ice Trolls. Resolve their conflicts for them to gain their services.",
      @"ReplaceableTextures\CommandButtons\BTNFlyingMachine.blp")
    {
      AddObjective(new ObjectiveHostilesInAreaAreDead(new[] { Regions.Gnomergan }, "near Gnomeregan"));
      AddObjective(new ObjectiveExpire(480, Title));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      ResearchId = UPGRADE_R05Q_QUEST_COMPLETED_GNOMEREGAN_IRONFORGE;
    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "Gnomeregan has been literated, and its military is now free to assist Ironforge.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of all units in Gnomeregan";

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
    }
  }
}