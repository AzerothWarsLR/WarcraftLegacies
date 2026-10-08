using MacroTools.Commands;
using WarcraftLegacies.Source.GameLogic;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Helps test the Pact of Hyjal alone: lets it be proposed straight away, and once a vote is running, makes everyone who
/// hasn't voted vote for it.
/// </summary>
public sealed class CheatTestPact : Command
{
  /// <inheritdoc />
  public override string CommandText => "testpact";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Lets the Pact of Hyjal be proposed now, or makes everyone vote for it while a vote is running.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var pact = RoleplaySetting.HyjalPact;
    if (pact == null)
    {
      return "The Pact of Hyjal only exists in Roleplay mode.";
    }

    if (pact.IsVoting)
    {
      pact.ForceVotesFor();
      return "Everyone who hadn't voted voted for the Pact of Hyjal.";
    }

    pact.ForcePrerequisites();
    return "The Pact of Hyjal can now be proposed.";
  }
}
