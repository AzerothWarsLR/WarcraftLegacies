using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Researches;

public sealed class GrantResearchOnLegendTrained
{
  private readonly int _unitType;
  private readonly int _researchId;

  public GrantResearchOnLegendTrained(int unitType, int researchId)
  {
    _unitType = unitType;
    _researchId = researchId;
    PlayerUnitEvents.Register(UnitTypeEvent.FinishesTraining, OnFinishesTraining);
    PlayerUnitEvents.Register(HeroTypeEvent.FinishesRevive, OnFinishesRevive);
  }

  private void OnFinishesTraining()
  {
    var trainedUnit = @event.TrainedUnit;
    GrantIfMatches(trainedUnit);
  }

  private void OnFinishesRevive()
  {
    GrantIfMatches(@event.RevivingUnit);
  }

  private void GrantIfMatches(unit whichUnit)
  {
    if (whichUnit.UnitType != _unitType)
    {
      return;
    }

    whichUnit.Owner.SetTechResearched(_researchId, 1);
  }
}
