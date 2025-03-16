using MacroTools.FactionSystem;
using MacroTools.Setup;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.Powers
{
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
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerFinishesTraining, OnUnitTrain, GetPlayerId(whichPlayer));
    }
      
    public override void OnRemove(player whichPlayer)
    {
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerFinishesTraining, OnUnitTrain, GetPlayerId(whichPlayer));
    }
      
    private void OnUnitTrain()
    {
      var trainedUnit = GetTrainedUnit();
      if (!(_chance > GetRandomReal(0, 100))) return;
      var newUnit = CreateUnit(GetOwningPlayer(trainedUnit), GetUnitTypeId(trainedUnit), GetUnitX(trainedUnit), GetUnitY(trainedUnit), GetUnitFacing(trainedUnit));
      var rallyPoint = GetUnitRallyPoint(GetTriggerUnit());
      IssuePointOrder(newUnit, "attack", GetLocationX(rallyPoint), GetLocationY(rallyPoint));
      RemoveLocation(rallyPoint);
    }
  }
}