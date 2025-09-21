using MacroTools.FactionSystem;
using MacroTools.Setup;
using WCSharp.Events;

namespace MacroTools.Powers;

public sealed class RapidMobilization : Power
{
  private readonly float _chance;

  public RapidMobilization(float percentageChance)
  {
    _chance = percentageChance;
    Description = $"When you train a unit, you have a {percentageChance}% of instantly training an additional copy for free.";
  }

  public override void OnAdd(player whichPlayer)
  {
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerFinishesTraining, OnUnitTrain, whichPlayer.Id);
  }

  public override void OnRemove(player whichPlayer)
  {
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerFinishesTraining, OnUnitTrain, whichPlayer.Id);
  }

  private void OnUnitTrain()
  {
    var trainedUnit = @event.TrainedUnit;
    if (!(_chance > GetRandomReal(0, 100)))
    {
      return;
    }

    var newUnit = unit.Create(trainedUnit.Owner, trainedUnit.UnitType, trainedUnit.X, trainedUnit.Y, trainedUnit.Facing);
    var rallyPoint = @event.Unit.RallyPoint;
    newUnit.IssueOrder("attack", rallyPoint.X, rallyPoint.Y);
    rallyPoint.Dispose();
  }
}
