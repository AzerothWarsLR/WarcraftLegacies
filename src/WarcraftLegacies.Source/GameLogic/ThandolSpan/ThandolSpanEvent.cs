using MacroTools.Localization;
using MacroTools.WorldEvents;
using WarcraftLegacies.Source.Objectives.MetaBased;

namespace WarcraftLegacies.Source.GameLogic.ThandolSpan;

/// <summary>Announces the restoration of the Thandol Span as a world event.</summary>
public sealed class ThandolSpanEvent : WorldEvent
{
  public ThandolSpanEvent()
  {
    Name = "The Thandol Span Restored";
    IconName = "Repair";
    Description = "The great dwarven bridge between Arathi and the Wetlands lies in ruin, and a dwarven crew is hard at work raising it again. Paying its foremen speeds up the work, and should the Alliance unite, its masons finish the bridge within 5 turns.";

    var restored = new ObjectiveTriggered(
      $"The crew finishes on turn {ThandolSpanBridge.DefaultFinishTurn}, {ThandolSpanBridge.TurnsSavedPerPayment} turns sooner for each payment to a foreman (no sooner than turn {ThandolSpanBridge.EarliestFinishTurn}), or 5 turns after the Grand Alliance forms");
    AddRequirement(restored);
    ThandolSpanBridge.Restored += () =>
    {
      Outcome = DescribeOutcome();
      restored.Trigger();
    };
  }

  private static string DescribeOutcome()
  {
    var outcome = ThandolSpanBridge.RestoredBy != null
      ? Loc.Format("Restored on turn {turn} when {cause}.", ("{turn}", ThandolSpanBridge.RestoredOnTurn.ToString()),
        ("{cause}", ThandolSpanBridge.RestoredBy))
      : Loc.Format("The crew finished the repairs on turn {turn}.",
        ("{turn}", ThandolSpanBridge.RestoredOnTurn.ToString()));

    var payers = ThandolSpanBridge.Payers;
    if (payers.Count == 0)
    {
      return outcome;
    }

    var names = payers[0];
    for (var i = 1; i < payers.Count; i++)
    {
      var separator = i == payers.Count - 1 ? " and " : ", ";
      names = names + separator + payers[i];
    }

    return outcome + " " + Loc.Format("Sped up by {names}.", ("{names}", names));
  }

  /// <inheritdoc />
  protected override void OnHappened()
  {
  }
}
