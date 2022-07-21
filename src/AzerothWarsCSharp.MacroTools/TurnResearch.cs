using AzerothWarsCSharp.MacroTools.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  /// <summary>
  /// A research that is automatically granted to all players when a particular turn has passed.
  /// </summary>
  public sealed class TurnResearch
  {
    private readonly int _researchId;
    private readonly int _turn;

    public TurnResearch(int researchId, int turn)
    {
      _researchId = researchId;
      _turn = turn;
    }

    public static void Register(TurnResearch turnResearch)
    {
      var timer = CreateTimer();
      TimerStart(timer, (turnResearch._turn) + 1 * 60, false, () =>
      {
        foreach (var player in GeneralHelpers.GetAllPlayers())
        {
          SetPlayerTechResearched(player, turnResearch._researchId, 1);
        }
        DestroyTimer(GetExpiredTimer());
      });
    }
  }
}