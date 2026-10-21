using MacroTools.WorldEvents;

namespace WarcraftLegacies.Source.GameLogic.HyjalPact;

/// <summary>
/// A record in the Events menu of the Pact of Hyjal coming to an end.
/// </summary>
public sealed class PactEndedEvent : WorldEvent
{
  public PactEndedEvent(string outcome)
  {
    Name = "The Pact of Hyjal Ends";
    IconName = "TreeOfEternity";
    Description = "With Archimonde fallen, the pact's members return to their old allies and their old wars.";
    Outcome = outcome;
  }

  /// <inheritdoc />
  protected override void OnHappened()
  {
  }
}
