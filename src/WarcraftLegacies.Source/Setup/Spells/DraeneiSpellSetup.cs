using MacroTools;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells.Slipstream;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all Draenei <see cref="Spell"/>s.
  /// </summary>
  public static class DraeneiSpellSetup
  {
    /// <summary>
    /// Sets up all Draenei <see cref="Spell"/>s.
    /// </summary>
    public static void Setup()
    {
      //Azuremyst
      SpellSystem.Register(new SlipstreamSpellSpecificLocation(Constants.ABILITY_A0P9_DIMENSIONAL_JUMP_TO_AZUREMYST_DRAENEI_AZUREMYST)
      {
        PortalUnitTypeId = Constants.UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 20,
        ClosingDelay = 10,
        TargetLocation = new Point(-20940, 10412),
        Color = new Color(155, 250, 50, 255)
      });

      //Argus
      SpellSystem.Register(new SlipstreamSpellSpecificLocation(Constants.ABILITY_A0RB_DIMENSIONAL_JUMP_TO_ARGUS_DRAENEI_ARGUS)
      {
        PortalUnitTypeId = Constants.UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 20,
        ClosingDelay = 10,
        TargetLocation = new Point(22573, -26856),
        Color = new Color(255, 50, 50, 255)
      });

      //Outland
      SpellSystem.Register(new SlipstreamSpellSpecificLocation(Constants.ABILITY_A0SR_DIMENSIONAL_JUMP_TO_TEMPEST_KEEP_DRAENEI_TEMPEST_KEEP)
      {
        PortalUnitTypeId = Constants.UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 20,
        ClosingDelay = 10,
        TargetLocation = new Point(2649, -22845),
        Color = new Color(55, 50, 250, 255)
      });

      var holyShockwave = new SpellOnAttack(Constants.UNIT_N0CX_LIGHTFORGED_WARFRAME_DRAENEI,
        Constants.ABILITY_A103_HOLY_SHOCKWAVE_DRAENEI)
      {
        DummyAbilityId = Constants.ABILITY_A104_SHOCKWAVE_WARFRAME_DUMMY,
        DummyOrderId = OrderId("carrionswarm"),
        ProcChance = 1
      };
      PassiveAbilityManager.Register(holyShockwave);

      var warStompAdal = new Stomp(Constants.ABILITY_A105_BLINDING_STARLIGHT_ADAL)
      {
        Radius = 1000,
        DamageBase = 00,
        DamageLevel = 00,
        DurationBase = 6,
        DurationLevel = 3,
        StunAbilityId = Constants.ABILITY_A106_CURSE_DRAENEI,
        StunOrderId = OrderId("curse"),
        SpecialEffect = @"war3mapImported\FrostNova.mdx"
      };
      SpellSystem.Register(warStompAdal);

      var summonGateway = new SummonUnitsTarget(Constants.ABILITY_A0LX_GATEWAY_REINFORCEMENTS_DRAENEI)
      {
        SummonUnitTypeId = Constants.UNIT_O05B_DEFENDER_DRAENEI,
        SummonCount = 1,
        Radius = 50,
        Duration = 0,
      };
      SpellSystem.Register(summonGateway);
    }
  }
}