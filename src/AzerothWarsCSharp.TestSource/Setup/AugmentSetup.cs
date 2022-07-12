using AzerothWarsCSharp.MacroTools.Augments;

namespace AzerothWarsCSharp.TestSource.Setup
{
   public static class AugmentSetup
   {
      public static void Setup()
      {
         AugmentSystem.Register(new IncomePowerAugment(10));
      }
   }
}