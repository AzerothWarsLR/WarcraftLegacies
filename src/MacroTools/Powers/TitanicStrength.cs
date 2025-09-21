using MacroTools.FactionSystem;
using MacroTools.Setup;
using WCSharp.Events;

namespace MacroTools.Powers;

public sealed class TitanicStrength : Power
{
  private readonly float _percentageOfHitPoints;

  public TitanicStrength(float percentageOfHitPoints)
  {
    _percentageOfHitPoints = percentageOfHitPoints;
    Description = $"Units you train gain attack damage equal to {percentageOfHitPoints}% of their maximum hit points.";
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
    var bonus = (int)(1 + trainedUnit.MaxLife * (_percentageOfHitPoints / 100));

    trainedUnit.AttackBaseDamage1 = trainedUnit.AttackBaseDamage1 + bonus;
    trainedUnit.AttackBaseDamage2 = trainedUnit.AttackBaseDamage2 + bonus;
  }
}
