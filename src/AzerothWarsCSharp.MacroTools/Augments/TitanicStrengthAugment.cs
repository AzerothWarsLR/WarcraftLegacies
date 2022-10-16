using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Augments
{
   /// <summary>
   /// An <see cref="Augment"/> that causes trained units to gain attack damage based on their hit points.
   /// </summary>
   public sealed class TitanicStrengthAugment : Augment
   {
      private readonly float _percentageOfHitPoints;

      /// <summary>
      /// Initializes an instance of the <see cref="RapidMobilizationAugment"/> class.
      /// </summary>
      /// <param name="percentageOfHitPoints">Trained units get extra attack damage equal to this percentage of their hit points.</param>
      public TitanicStrengthAugment(float percentageOfHitPoints)
      {
         _percentageOfHitPoints = percentageOfHitPoints;
         IconName = "ArmorGolem";
         Name = "Titanic Strength";
         Description = $"Units you train gain attack damage equal to {percentageOfHitPoints}% of their maximum hit points.";
      }
      
      /// <inheritdoc />
      public override float GetWeight(player whichPlayer)
      {
         return 10;
      }

      /// <inheritdoc />
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