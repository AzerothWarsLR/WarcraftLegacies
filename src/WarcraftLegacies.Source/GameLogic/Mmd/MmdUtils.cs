namespace WarcraftLegacies.Source.GameLogic.Mmd;

public static class MmdUtils
{
  public static bool IsMmdPlayer(player p)
  {
    return GetPlayerController(p) == MAP_CONTROL_USER &&
           GetPlayerSlotState(p) != PLAYER_SLOT_STATE_EMPTY;
  }
}
