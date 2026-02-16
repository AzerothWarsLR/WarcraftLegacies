using MacroTools.Commands;
using MacroTools.Extensions;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
/// Toggles quest text, dialogue, and captions simultaneously.
/// </summary>
public sealed class Text : Command
{
  public override string CommandText => "text";
  public override ExpectedParameterCount ExpectedParameterCount => new(1);
  public override CommandType Type => CommandType.Normal;
  public override string Description =>
    "Toggles quest text, dialogue, and captions with a single command (use 'on', 'off', 'true', 'false').";

  public override string Execute(player commandUser, params string[] parameters)
  {
    var input = parameters[0].ToLowerInvariant();
    bool? parsed = input switch
    {
      "true" or "on" => true,
      "false" or "off" => false,
      _ => null
    };

    if (parsed is null)
    {
      return "Invalid input. Use 'on', 'off', 'true', or 'false'.";
    }

    var data = PlayerData.ByHandle(commandUser);
    data.UpdatePlayerSetting("ShowQuestText", parsed.Value);
    data.UpdatePlayerSetting("PlayDialogue", parsed.Value);
    data.UpdatePlayerSetting("ShowCaptions", parsed.Value);

    return $"All text settings set to {parsed.Value}.";
  }
}
