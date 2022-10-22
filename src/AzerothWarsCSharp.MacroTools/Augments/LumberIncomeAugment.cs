using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;

namespace AzerothWarsCSharp.MacroTools.Augments
{
   /// <summary>
   /// An <see cref="Augment"/> that increases a <see cref="player"/>'s lumber income by a fixed amount.
   /// </summary>
   public sealed class LumberIncomeAugment : Augment
   {
      private readonly int _income;
      
      /// <summary>
      /// Initializes an instance of the <see cref="LumberIncomeAugment"/> class.
      /// </summary>
      /// <param name="income">The amount of lumber income to grant the selecting <see cref="player"/>.</param>
      public LumberIncomeAugment(int income)
      {
         _income = income;
         IconName = "BundleOfLumber";
         Name = "Ysera's Gift";
         Description = $"Your lumber income is increased by {income}.";
      }

      /// <inheritdoc />
      public override float GetWeight(player whichPlayer) => whichPlayer.GetLumberIncome() > 10 ? 0 : 5;

      /// <inheritdoc />
      public override void OnAdd(Faction whichFaction)
      {
         whichFaction.AddPower(new LumberIncomePower(_income)
         {
            IconName = IconName,
            Name = Name
         });
      }
   }
}