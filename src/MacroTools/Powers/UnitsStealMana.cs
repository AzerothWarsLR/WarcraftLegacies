using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;


namespace MacroTools.Powers
{
  /// <summary>
  /// Causes all the player's units to steal mana when they attack.
  /// </summary>
  public sealed class UnitsStealMana : Power
  {
    private readonly float _manaPerDamage;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitsStealMana"/> class.
    /// <param name="manaPerDamage">Units steal this amount of mana per attack damage they deal.</param>
    /// </summary>
    public UnitsStealMana(float manaPerDamage)
    {
      _manaPerDamage = manaPerDamage;
      Description = $"Your units restore {manaPerDamage} mana per damage they deal with basic attacks.";
    }
    
    /// <inheritdoc />
    public override void OnAdd(player whichPlayer)
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealsDamage, OnDealDamage, GetPlayerId(whichPlayer));
    }

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer)
    {
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerDealsDamage, OnDealDamage, GetPlayerId(whichPlayer));
    }

    private void OnDealDamage()
    {
      if (!BlzGetEventIsAttack())
        return;
      GetEventDamageSource().Mana += GetEventDamage() * _manaPerDamage;
    }
  }
}