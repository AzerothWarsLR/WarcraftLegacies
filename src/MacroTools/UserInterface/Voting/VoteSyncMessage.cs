namespace MacroTools.UserInterface.Voting;

internal sealed class VoteSyncMessage
{
  public int GroupId { get; set; }

  public int PlayerId { get; set; }

  public int OptionIndex { get; set; }
}
