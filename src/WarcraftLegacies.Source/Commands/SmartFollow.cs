using MacroTools.Commands;
using WarcraftLegacies.Source.GameLogic.AssistedFollow;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
/// Turns the player's Smart Follow preference on or off.
/// </summary>
public sealed class SmartFollow : Command
{
  public override string CommandText => "smartfollow";

  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  public override CommandType Type => CommandType.Normal;

  public override string Description =>
    "Turns Smart Follow on or off (accepts 'true', 'false', 'on', 'off').";

  public override string Execute(player commandUser, params string[] parameters)
  {
    var input = parameters[0].ToLowerInvariant();
    bool? enabled = input switch
    {
      "true" or "on" => true,
      "false" or "off" => false,
      _ => null
    };

    if (enabled is null)
    {
      return "Invalid parameter. Please use 'true', 'false', 'on', or 'off'.";
    }

    AssistedFollowSystem.SetPlayerEnabled(commandUser, enabled.Value);
    return enabled.Value
      ? "Smart Follow is now on."
      : "Smart Follow is now off; units will use Warcraft III's native follow behavior.";
  }
}
