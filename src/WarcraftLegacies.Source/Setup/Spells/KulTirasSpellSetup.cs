using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.Spells;

/// <summary>
/// Responsible for setting up all KulTiras <see cref="Spell"/>s.
/// </summary>
public static class KulTirasSpellSetup
{
  /// <summary>
  /// Sets up all KulTiras <see cref="Spell"/>s.
  /// </summary>
  public static void Setup()
  {
    SpellSystem.Register(new WaygateOpen(ABILITY_A0LM_OPEN_SHIP)
    {
      InteriorWaygateUnitTypeId = UNIT_H03V_ENTRANCE_PORTAL,
      ExteriorWaygateUnitTypeId = UNIT_H05T_INSTANCE_ENTRANCE_PORTAL,
      GetExteriorWaygatePosition = () => new Point(@event.SpellTargetX, @event.SpellTargetY),
      GetInteriorWaygatePosition = () => Regions.ShipInside.Center
    });

    SpellSystem.Register(new ChannelAnySpell(ABILITY_A0S5_BOMBING_RUN_STORMWIND_DUMMY)
    {
      DummyAbilityId = ABILITY_A0S1_BOMBING_RUN_STORMWIND,
      DummyAbilityOrderId = ORDER_LOCUST_SWARM,
      Duration = 15
    });

    var warStompMeredith = new Stomp(ABILITY_A003_DISCORDANT_CADENZA_MEREDITH)
    {
      Radius = 800,
      DamageBase = 00,
      DamageLevel = 00,
      DurationBase = 4,
      DurationLevel = 2,
      StunAbilityId = ABILITY_A0L0_SLEEP_DUMMY,
      StunOrderId = ORDER_SLEEP,
      SpecialEffect = @"Abilities\Spells\Other\HowlOfTerror\HowlCaster.mdl"
    };
    SpellSystem.Register(warStompMeredith);

    var scattershot = new MassAnySpell(ABILITY_A0GP_SCATTERSHOT_KUL_TIRAS_LADY_ASHVANE)
    {
      DummyAbilityId = ABILITY_A0GL_SCATTERSHOT_KUL_TIRAS_LADY_ASHVANE_DUMMY,
      DummyAbilityOrderId = ORDER_THUNDERBOLT,
      Radius = 250,
      CastFilter = CastFilters.IsTargetEnemyAndAlive,
      TargetType = SpellTargetType.Point,
      DummyCastOriginType = DummyCastOriginType.Caster
    };
    SpellSystem.Register(scattershot);
  }
}
