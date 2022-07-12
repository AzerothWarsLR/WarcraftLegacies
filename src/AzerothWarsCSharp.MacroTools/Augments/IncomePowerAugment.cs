using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Augments
{
   public sealed class IncomePowerAugment : Augment
   {
      private readonly int _income;
      
      public IncomePowerAugment(int income)
      {
         _income = income;
         IconName = "ChestOfGold";
         Name = "Offshore Investments";
         Description = $"Your gold income is increased by {income}.";
      }

      public override float GetWeight(player whichPlayer)
      {
         return 5;
      }

      public override void OnAdd(Faction whichFaction)
      {
         whichFaction.AddPower(new IncomePower(_income));
      }
   }
}