using MacroTools.GameModes;
using MacroTools.Localization;
using WarcraftLegacies.Source.GameLogic;

namespace WarcraftLegacies.Source.GameModes;

public sealed class Roleplay : IGameMode
{
  /// <inheritdoc />
  public string Name => Loc.Get("Roleplay");

  /// <inheritdoc />
  public string Description => Loc.Get("Factions can branch onto alternate paths and betray their allies as the game unfolds.");

  /// <inheritdoc />
  public void OnChoose()
  {
    RoleplaySetting.Apply();
    this.SetupControlPointVictory();
  }

  /// <inheritdoc />
  public int VoteOffset => 0;

  /// <inheritdoc />
  public bool ForcesOpenDiplomacy => false;
}
