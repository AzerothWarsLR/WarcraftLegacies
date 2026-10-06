using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Commands;

public sealed class Settings : Command
{
  /// <inheritdoc />
  public override string CommandText => "settings";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Normal;

  /// <inheritdoc />
  public override string Description => "Shows your current settings.";

  /// <inheritdoc />
  public override string Execute(player commandUser, params string[] parameters)
  {
    var playerSettings = commandUser.GetPlayerSettings();
    return Loc.Format(@"Current settings:
Camera distance: {distance}

Show quest text: {questText}

Play dialogue: {dialogue}

Show captions: {captions}

Smart follow: {smartFollow}",
      ("{distance}", playerSettings.CamDistance.ToString()),
      ("{questText}", playerSettings.ShowQuestText.ToString()),
      ("{dialogue}", playerSettings.PlayDialogue.ToString()),
      ("{captions}", playerSettings.ShowCaptions.ToString()),
      ("{smartFollow}", playerSettings.SmartFollowEnabled.ToString()));
  }
}
