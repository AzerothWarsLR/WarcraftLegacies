using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.Powers
{
   public sealed class IncomePower : Power
   {
      private int _income;
      
      public IncomePower(int income)
      {
         _income = income;
         RefreshDescription();
         Name = "Offshore Investments";
      }

      private int Income
      {
         get => _income;
         set
         {
            _income = value;
            RefreshDescription();
         }
      }

      public override void OnAdd(player whichPlayer)
      {
         whichPlayer.AddBonusIncome(_income);
      }

      public override void OnRemove(player whichPlayer)
      {
         whichPlayer.AddBonusIncome(-_income);
      }

      private void RefreshDescription()
      {
         Description =
            $"Your gold income is increased by {Income}.";
      }
   }
}