using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.Powers
{
   public sealed class LumberIncomePower : Power
   {
      public LumberIncomePower(int income)
      {
         Income = income;
         Description = $"Your lumber income is increased by {Income}.";
      }

      private int Income { get; }

      public override void OnAdd(player whichPlayer)
      {
         whichPlayer.AddLumberIncome(Income);
      }

      public override void OnRemove(player whichPlayer)
      {
         whichPlayer.AddLumberIncome(-Income);
      }
   }
}