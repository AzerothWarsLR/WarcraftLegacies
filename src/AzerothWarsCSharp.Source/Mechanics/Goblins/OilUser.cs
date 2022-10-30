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
  /// Oil users use oil instead of mana. The oil is provided by the owner's <see cref="OilPower"/> if they have one.
  /// </summary>
  public sealed class OilUser : PassiveAbility
  {
    public OilUser(int unitTypeId) : base(unitTypeId)
    {
    }

    public override void OnCreated(unit createdUnit)
    {
      var owningFaction = createdUnit.OwningPlayer().GetFaction();
      var oilPower = owningFaction?.GetPowerByType<OilPower>();
      if (oilPower == null)
      {
        throw new Exception(
          $"Oil user {GetUnitName(GetTriggerUnit())} was created but owning faction {owningFaction?.Name} doesn't have a power that stores oil.");
      }

      var oilBuff = new OilUserBuff(createdUnit, oilPower);
      BuffSystem.Add(oilBuff);
    }
  }
}