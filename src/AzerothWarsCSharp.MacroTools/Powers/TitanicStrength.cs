using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Powers
{
   public sealed class TitanicStrength : Power
   {
      private readonly float _percentageOfHitPoints;
      private const string CustomEventIdentifier = "PlayerFinishesTraining";

      public TitanicStrength(float percentageOfHitPoints)
      {
         _percentageOfHitPoints = percentageOfHitPoints;
         Description = $"Units you train gain attack damage equal to {percentageOfHitPoints}% of their maximum hit points.";
      }
      
      static TitanicStrength()
      {
         PlayerUnitEvents.AddCustomEventFilter(EVENT_PLAYER_UNIT_TRAIN_FINISH,
            CustomEventIdentifier,
            () => GetPlayerId(GetOwningPlayer(GetTrainedUnit())));
      }
      
      public override void OnAdd(player whichPlayer)
      {
         PlayerUnitEvents.Register(CustomEventIdentifier, OnUnitTrain, GetPlayerId(whichPlayer));
      }
      
      public override void OnRemove(player whichPlayer)
      {
         PlayerUnitEvents.Unregister(CustomEventIdentifier, GetPlayerId(whichPlayer));
      }
      
      private void OnUnitTrain()
      {
         var trainedUnit = GetTrainedUnit();
         var bonus = (int)(1 + BlzGetUnitMaxHP(trainedUnit) * (_percentageOfHitPoints / 100));

         BlzSetUnitBaseDamage(trainedUnit, BlzGetUnitBaseDamage(trainedUnit, 0) + bonus, 0);
         BlzSetUnitBaseDamage(trainedUnit, BlzGetUnitBaseDamage(trainedUnit, 1) + bonus, 1);
      }
   }
}