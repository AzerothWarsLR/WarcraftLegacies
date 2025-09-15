using MacroTools.FactionSystem;
using MacroTools.Setup;
using WCSharp.Events;

namespace MacroTools.Powers
{
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
         PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerFinishesTraining, OnUnitTrain, GetPlayerId(whichPlayer));
      }
      
      public override void OnRemove(player whichPlayer)
      {
         PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerFinishesTraining, OnUnitTrain, GetPlayerId(whichPlayer));
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