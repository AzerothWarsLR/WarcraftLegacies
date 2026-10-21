using MacroTools.Commands;
using MacroTools.GameModes;
using MacroTools.Localization;
using WarcraftLegacies.Source.Commands;

namespace WarcraftLegacies.Source.GameModes;

public sealed class GreatWar : IGameMode
{
  /// <inheritdoc />
  public string Name => Loc.Get("Great War (7v7)");

  /// <inheritdoc />
  public string Description => Loc.Get("Two teams of 7 clash in large-scale battles for control of Azeroth.");

  /// <inheritdoc />
  public void OnChoose()
  {
    CommandManager.Register(new Forfeit());
    this.SetupGreatWarTeams();
  }

  /// <inheritdoc />
  public int VoteOffset => -4;

  /// <inheritdoc />
  public string IconPath => @"ReplaceableTextures\CommandButtons\BTNAttack.blp";

  /// <inheritdoc />
  public bool SkipsEarlyGame => false;

  /// <inheritdoc />
  public DiplomacyRule Diplomacy => DiplomacyRule.Open;
}
