using System;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Buffs;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.PassiveAbilitySystem;
using AzerothWarsCSharp.MacroTools.Powers;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.Goblins
{
   /// <summary>
   /// Oil producers use oil instead of mana. The oil is provided by the owner's <see cref="OilPower"/> if they have one.
   /// They also periodically add oil to the power.
   /// </summary>
   public sealed class OilProducer : PassiveAbility
   {
      private readonly float _income;

      public OilProducer(int unitTypeId, float income) : base(unitTypeId)
      {
         _income = income;
      }

      public override void OnCreated()
      {
         var triggerUnit = GetTriggerUnit();
         var owningFaction = triggerUnit.OwningPlayer().GetFaction();
         var oilPower = owningFaction?.GetPowerByType<OilPower>();
         if (oilPower == null)
         {
            throw new Exception(
               $"Oil user {GetUnitName(GetTriggerUnit())} was created but owning faction {owningFaction?.Name} doesn't have a power that stores oil.");
         }

         var oilBuff = new OilProducerBuff(triggerUnit, _income, oilPower);
         BuffSystem.Add(oilBuff);
      }
   }
}