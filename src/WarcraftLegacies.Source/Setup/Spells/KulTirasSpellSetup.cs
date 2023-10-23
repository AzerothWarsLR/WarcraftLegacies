using MacroTools.Spells;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Spells
{
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
      SpellSystem.Register(new WaygateOpen(Constants.ABILITY_A0LM_OPEN_SHIP)
      {
        InteriorWaygateUnitTypeId = Constants.UNIT_H03V_ENTRANCE_PORTAL,
        ExteriorWaygateUnitTypeId = Constants.UNIT_H05T_INSTANCE_ENTRANCE_PORTAL,
        GetExteriorWaygatePosition = () => new Point(GetSpellTargetX(), GetSpellTargetY()),
        GetInteriorWaygatePosition = () => Regions.ShipInside.Center
      });
      
      SpellSystem.Register(new ChannelAnySpell(Constants.ABILITY_A0S5_BOMBING_RUN_STORMWIND_DUMMY)
      {
        DummyAbilityId = Constants.ABILITY_A0S1_BOMBING_RUN_STORMWIND,
        DummyAbilityOrderString = "locustswarm",
        Duration = 15
      });

      var warStompMeredith = new Stomp(Constants.ABILITY_A003_DISCORDANT_CADENZA_MEREDITH)
      {
        Radius = 800,
        DamageBase = 00,
        DamageLevel = 00,
        DurationBase = 4,
        DurationLevel = 2,
        StunAbilityId = Constants.ABILITY_A0L0_SLEEP_DUMMY,
        StunOrderId = OrderId("sleep"),
        SpecialEffect = @"Abilities\Spells\Other\HowlOfTerror\HowlCaster.mdl"
      };
      SpellSystem.Register(warStompMeredith);
    }
  }
}