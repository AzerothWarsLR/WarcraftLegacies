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
      }
   }
}