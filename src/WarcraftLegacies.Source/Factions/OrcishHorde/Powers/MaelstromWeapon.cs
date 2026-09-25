using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Setup;
using WCSharp.Effects;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Powers;

public sealed class MaelstromWeapon : Power
{
  private readonly float _damageChance;
  private readonly float _damageDealt;

  public string Effect { get; init; } = "";

  public IEnumerable<int>? ValidUnitTypes;

  public MaelstromWeapon(float damageChance, float damageDealt)
  {
    _damageChance = damageChance;
    _damageDealt = damageDealt;
    Name = Loc.Get("Maelstrom Spirit");
    Description = Loc.Format(
      "Your Orc units have a {chance}% chance on attack to call down a lightning bolt dealing {damage} magic damage. Thrall instead has a 100% chance.",
      ("{chance}", (damageChance * 100).ToString()),
      ("{damage}", damageDealt.ToString()));
  }

  public override void OnAdd(player whichPlayer) =>
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamage, whichPlayer.Id);

  public override void OnRemove(player whichPlayer) =>
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamage, whichPlayer.Id);

  private void OnDamage()
  {
    if (!@event.IsAttack || (ValidUnitTypes != null && !ValidUnitTypes.Contains(@event.DamageSource.UnitType)))
    {
      return;
    }

    if (!unit.IsHero(@event.DamageSource.UnitType) && !(GetRandomReal(0, 1) < _damageChance))
    {
      return;
    }

    @event.Unit.TakeDamage(@event.DamageSource, _damageDealt);
    EffectSystem.Add(effect.Create(Effect, @event.Unit.X, @event.Unit.Y), 1);
  }
}
