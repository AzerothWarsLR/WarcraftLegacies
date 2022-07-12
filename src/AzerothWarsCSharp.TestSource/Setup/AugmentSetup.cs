using AzerothWarsCSharp.MacroTools.Augments;

namespace AzerothWarsCSharp.TestSource.Setup
{
   public static class AugmentSetup
   {
      public static void Setup()
      {
         AugmentSystem.Register(new IncomePowerAugment(10));
         AugmentSystem.Register(new IncomePowerAugment(15));
         AugmentSystem.Register(new IncomePowerAugment(20));
         AugmentSystem.Register(new LumberIncomeAugment(7));
         AugmentSystem.Register(new LumberIncomeAugment(1400));
      }
   }
}