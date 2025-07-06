using MacroTools.CommandSystem;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Commands
{
  /// <summary>
  /// A <see cref="CommandSystem.Command"/> that turns quest text on or off.
  /// </summary>
  public sealed class QuestText : Command
  {
    /// <inheritdoc />
    public override string CommandText => "questtext";

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(1);

    /// <inheritdoc />
    public override CommandType Type => CommandType.Normal;

    /// <inheritdoc />
    public override string Description => "Turns quest text on or off (accepts 'true', 'false', 'on', 'off').";

    /// <inheritdoc />
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
        return "Invalid parameter. Please use 'true', 'false', 'on', or 'off'.";

      PlayerData.ByHandle(commandUser).UpdatePlayerSetting("ShowQuestText", parsed.Value);
      return $"Setting show quest text option to {parsed.Value}.";
    }
  }
}