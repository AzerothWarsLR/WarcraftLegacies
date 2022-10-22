using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;

namespace AzerothWarsCSharp.MacroTools.Augments
{
   /// <summary>
   /// An <see cref="Augment"/> that increases a <see cref="player"/>'s income by a fixed amount.
   /// </summary>
   public sealed class IncomePowerAugment : Augment
   {
      private readonly int _income;
      
      /// <summary>
      /// Initializes an instance of the <see cref="IncomePowerAugment"/> class.
      /// </summary>
      /// <param name="income">The amount of income to grant the selecting <see cref="player"/>.</param>
      public IncomePowerAugment(int income)
      {
         _income = income;
         IconName = "ChestOfGold";
         Name = "Offshore Investments";
         Description = $"Your gold income is increased by {income}.";
      }

      /// <inheritdoc />
      public override float GetWeight(player whichPlayer)
      {
         return 5;
      }

      /// <inheritdoc />
      public override void OnAdd(Faction whichFaction)
      {
         whichFaction.AddPower(new IncomePower(_income));
      }
   }
}