using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Augments
{
   public sealed class TitanicStrengthAugment : Augment
   {
      private readonly float _percentageOfHitPoints;

      public TitanicStrengthAugment(float percentageOfHitPoints)
      {
         _percentageOfHitPoints = percentageOfHitPoints;
         IconName = "ArmorGolem";
         Name = "Titanic Strength";
         Description = $"Units you train gain attack damage equal to {percentageOfHitPoints}% of their maximum hit points.";
      }
      
      public override float GetWeight(player whichPlayer)
      {
         return 10;
      }

      public override void OnAdd(Faction whichFaction)
      {
         whichFaction.AddPower(new TitanicStrength(_percentageOfHitPoints)
         {
            IconName = IconName,
            Name = Name
         });
      }
   }
}