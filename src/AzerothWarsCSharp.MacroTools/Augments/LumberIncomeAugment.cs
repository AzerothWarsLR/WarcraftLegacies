using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Augments
{
   public sealed class LumberIncomeAugment : Augment
   {
      private readonly int _income;
      
      public LumberIncomeAugment(int income)
      {
         _income = income;
         IconName = "BundleOfLumber";
         Name = "Ysera's Gift";
         Description = $"Your lumber income is increased by {income}.";
      }

      public override float GetWeight(player whichPlayer)
      {
         return whichPlayer.GetLumberIncome() > 10 ? 0 : 5;
      }

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