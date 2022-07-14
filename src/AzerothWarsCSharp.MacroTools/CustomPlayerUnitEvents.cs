using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public static class CustomPlayerUnitEvents
  {
    public static string PlayerFinishesTraining => "PlayerFinishesTraining";

    static CustomPlayerUnitEvents()
    {
      PlayerUnitEvents.AddCustomEventFilter(EVENT_PLAYER_UNIT_TRAIN_FINISH,
        PlayerFinishesTraining,
        () => GetPlayerId(GetOwningPlayer(GetTrainedUnit())));
    }
  }
}