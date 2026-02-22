using MacroTools.GameTime;

namespace MacroTools.Researches;

/// <summary>
/// Research that is automatically granted to all players when a particular turn has passed.
/// </summary>
public sealed class TurnResearch
{
  private readonly int _researchId;
  private readonly int _turn;

  /// <summary>
  /// Initializes a new instance of the <see cref="TurnResearch"/> class.
  /// </summary>
  /// <param name="researchId">Which research to grant.</param>
  /// <param name="turn">Which turn this research should be granted on.</param>
  public TurnResearch(int researchId, int turn)
  {
    _researchId = researchId;
    _turn = turn;
  }

  /// <summary>
  /// Registers a <see cref="TurnResearch"/> so that the game can grant it at the specified time.
  /// </summary>
  public static void Register(TurnResearch turnResearch)
  {
    GameTimeManager.OnTurn(turnResearch._turn, () =>
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        player.SetTechResearched(turnResearch._researchId, 1);
      }
    });
  }
}
