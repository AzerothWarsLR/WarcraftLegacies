using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests
{
  /// <summary>
  /// Capture the entire Broken Isles to get Blackrook Hold.
  /// </summary>
  public sealed class QuestBlackrookHold : QuestData
  {
    /// <inheritdoc />
    public QuestBlackrookHold() : base("Blackrook Hold",
      "Blackrook Hold once stood as a bulwark against the Burning Legion during the War of the Ancients. That it survived the Great Sundering is an extraordinary testatement to its construction; if it were to be secured, it would offer dominion over the entire Broken Isles.",
      BlzGetAbilityIcon(LegendSentinels.BlackrookHold.UnitType))
    {
      AddObjective(new ObjectiveKillAllInArea(new[]
      {
        Regions.BrokenIslesA,
        Regions.BrokenIslesB
      }, "on the Broken Isles"));
      AddObjective(new NoOtherPlayerGetsCapital(LegendSentinels.BlackrookHold));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N053_VAL_SHARAH_15GOLD_MIN)));
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "The Broken Isles have been secured, and Black Rook Hold's garrison has been re-established.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "You gain control of Blackrook Hold";

    /// <inheritdoc />
    protected override void OnComplete(Faction whichFaction)
    {
      LegendSentinels.BlackrookHold.Unit.Rescue(whichFaction.Player);
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      LegendSentinels.BlackrookHold.Unit.SetInvulnerable(true);
    }
  }
}