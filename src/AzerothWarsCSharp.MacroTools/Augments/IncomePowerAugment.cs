using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;

namespace AzerothWarsCSharp.MacroTools.Augments
{
   public sealed class IncomePowerAugment : Augment
   {
      private readonly int _income;

      public IncomePowerAugment(int income)
      {
         _income = income;
      }

      public override void OnAdd(Faction whichFaction)
      {
         whichFaction.AddPower(new IncomePower(_income));
      }
   }
}