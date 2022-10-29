using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  /// <summary>
  /// A <see cref="QuestData"/> to open the way into Scholomance.
  /// </summary>
  public sealed class QuestOpenScholomance : QuestData
  {
    private unit? _scholomanceInner;
    private unit? _scholomanceOuter;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestOpenScholomance"/> class.
    /// </summary>
    /// <param name="parentQuest">The <see cref="QuestData"/> which must be completed before this one can be.</param>
    public QuestOpenScholomance(QuestData parentQuest) : base("Open Scholomance",
      "Scholomance remains hidden deep within the ancient crypts beneath Caer Darrow, away from the prying eyes of the Alliance. Soon it will be time to open its doors and unleash the necromantic horrors within.",
      @"ReplaceableTextures\CommandButtons\BTNNecropolis.blp")
    {
      _scholomanceInner = PreplacedUnitSystem.GetUnit(Constants.UNIT_N04B_SCHOLOMANCE_INNER);
      _scholomanceOuter = PreplacedUnitSystem.GetUnit(Constants.UNIT_N035_SCHOLOMANCE);
      AddObjective(new ObjectiveEitherOf(
        new ObjectiveResearch(Constants.UPGRADE_R02X_OPEN_THE_SCHOLOMANCE_SCOURGE, Constants.UNIT_U012_SCHOLOMANCE),
        new ObjectiveCompleteQuest(parentQuest)));
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "Scholomance has been opened!";

    /// <inheritdoc />
    protected override string RewardDescription => "Units can be moved in and out of Scholomance";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.SetObjectLevel(Constants.UPGRADE_R02X_OPEN_THE_SCHOLOMANCE_SCOURGE, 1);
      _scholomanceInner?.SetWaygateDestination(Regions.Scholomance_Entrance.Center);
      _scholomanceOuter?.SetWaygateDestination(Regions.Scholomance_Exit.Center);
      _scholomanceInner = null;
      _scholomanceOuter = null;
    }
  }
}