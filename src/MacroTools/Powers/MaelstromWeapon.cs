using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;


namespace MacroTools.Powers
{
  /// <summary>
  /// The player's units have a chance to do bonus damage when they attack.
  /// </summary>
  public sealed class MaelstromWeapon : Power
  {
    private readonly float _damageChance;
    private readonly float _damageDealt;

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
    public MaelstromWeapon(float damageChance, float damageDealt)
    {
      _damageChance = damageChance;
      _damageDealt = damageDealt;
      Name = "Maelstrom Spirit";
      Description = $"Your Orc units have a {damageChance*100}% chance on attack to call down a lightning bolt dealing {damageDealt} magic damage. Thrall instead has a 100% chance.";
    }
    
    /// <inheritdoc />
    public override void OnAdd(player whichPlayer) => 
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamage, GetPlayerId(whichPlayer));

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer) => 
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamage, GetPlayerId(whichPlayer));

    private void OnDamage()
    {
      if (!BlzGetEventIsAttack() || (ValidUnitTypes != null && !ValidUnitTypes.Contains(GetEventDamageSource().GetTypeId()))) 
        return;

      if (!IsHeroUnitId(GetEventDamageSource().GetTypeId()) && !(GetRandomReal(0, 1) < _damageChance)) 
        return;
      
      GetTriggerUnit().TakeDamage(GetEventDamageSource(), _damageDealt);
      AddSpecialEffect(Effect, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()))
        .SetLifespan(1);
    }
  }
}