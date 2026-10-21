using MacroTools.GameModes;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.GameModes;

public sealed class Standard : IGameMode
{
  /// <inheritdoc />
  public string Name => Loc.Get("Standard");

  /// <inheritdoc />
  public string Description => Loc.Get("Capture Control Points across Azeroth alongside your allies to win.");

  /// <inheritdoc />
  public void OnChoose()
  {
    this.SetupControlPointVictory();
  }

  /// <inheritdoc />
  public int VoteOffset => 0;

  /// <inheritdoc />
  public string IconPath => @"ReplaceableTextures\CommandButtons\BTNHumanCaptureFlag.blp";

  /// <inheritdoc />
  public bool SkipsEarlyGame => false;

  /// <inheritdoc />
  public DiplomacyRule Diplomacy => DiplomacyRule.Vote;
}
