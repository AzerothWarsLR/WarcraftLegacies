using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;
using WCSharp.Shared.Extensions;
using static War3Api.Common;

namespace MacroTools.Powers
{
  /// <summary>
  /// The player's units have a chance to do bonus damage when they attack.
  /// </summary>
  public sealed class MaelstromWeapon : Power
  {
    /// <summary>
    /// The chance to do bonus damage.
    /// </summary>
    public float DamageChance { get; init; }
    
    /// <summary>
    /// The bonus damage dealt.
    /// </summary>
    public float DamageDealt { get; init; }

    /// <summary>
    /// The effect that appears when bonus damage is dealt.
    /// </summary>
    public string Effect { get; init; } = "";

    /// <summary>
    /// The unit types that are affected by this <see cref="Power"/>.
    /// </summary>
    public IEnumerable<int>? ValidUnitTypes;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="MaelstromWeapon"/> class.
    /// </summary>
    public MaelstromWeapon()
    {
      Description = $"Your Orc units have a {DamageChance*100}% chance to deal {DamageDealt} extra magical damage on attack. Thrall instead has a 100% chance.";
    }
    
    /// <inheritdoc />
    public override void OnAdd(player whichPlayer) => 
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamage, GetPlayerId(whichPlayer));

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer) => 
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerDealsDamage, GetPlayerId(whichPlayer));

    private void OnDamage()
    {
      if (!BlzGetEventIsAttack() || (ValidUnitTypes != null && ValidUnitTypes.Contains(GetEventDamageSource().GetTypeId()))) 
        return;

      if (!IsHeroUnitId(GetEventDamageSource().GetTypeId()) && !(GetRandomReal(0, 1) < DamageChance))
        return;
      
      GetTriggerUnit().Damage(GetEventDamageSource(), DamageDealt, ATTACK_TYPE_MAGIC);
      AddSpecialEffect(Effect, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()))
        .SetLifespan();
    }
  }
}