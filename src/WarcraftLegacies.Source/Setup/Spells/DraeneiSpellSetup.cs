using MacroTools.Data;
using MacroTools.Spells;
using MacroTools.UnitTypeTraits;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.Spells.MassiveAttack;
using WarcraftLegacies.Source.Spells.Slipstream;
using WCSharp.Shared.Data;


namespace WarcraftLegacies.Source.Setup.Spells;

public static class DraeneiSpellSetup
{
  public static void Setup()
  {
    var slipstreamTempestOriginPoint = Regions.SlipstreamTempestOrigin.GetRandomPoint();
    var slipstreamTempestTargetPoint = Regions.SlipstreamTempestTarget.GetRandomPoint();
    var slipstreamArgusOriginPoint = Regions.SlipstreamArgusOrigin.GetRandomPoint();
    var slipstreamArgusTargetPoint = Regions.SlipstreamArgusTarget.GetRandomPoint();
    var slipstreamAzuremystTargetPoint = new Point(-20940, 10412);

    SpellRegistry.Register(new SlipstreamSpellSpecificOriginAndDestination(ABILITY_A0P9_PORTAL_TO_AZUREMYST_DRAENEI)
    {
      PortalUnitTypeId = UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
      OpeningDelay = 20,
      ClosingDelay = 10,
      OriginLocation = slipstreamArgusOriginPoint,
      TargetLocation = slipstreamAzuremystTargetPoint,
      Color = new Color(155, 250, 50, 255)
    });
    SpellRegistry.Register(new SlipstreamSpellSpecificOriginAndDestination(ABILITY_A0RB_PORTAL_TO_ARGUS_DRAENEI)
    {
      PortalUnitTypeId = UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
      OpeningDelay = 20,
      ClosingDelay = 10,
      OriginLocation = slipstreamArgusOriginPoint,
      TargetLocation = slipstreamArgusTargetPoint,
      Color = new Color(255, 50, 50, 255)
    });

    SpellRegistry.Register(new SlipstreamSpellSpecificOriginAndDestination(ABILITY_A0SR_PORTAL_TO_TEMPEST_KEEP_DRAENEI)
    {
      PortalUnitTypeId = UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
      OpeningDelay = 20,
      ClosingDelay = 10,
      OriginLocation = slipstreamTempestOriginPoint,
      TargetLocation = slipstreamTempestTargetPoint,
      Color = new Color(55, 50, 250, 255)
    });

    UnitTypeTraitRegistry.Register(new MassiveAttackAbility
    {
      AttackDamagePercentage = 0.3f,
      Distance = 700
    }, UNIT_N0CX_LIGHTFORGED_WARFRAME_DRAENEI);

    var warStompAdal = new Stomp(ABILITY_A105_BLINDING_STARLIGHT_ADAL)
    {
      Radius = 1000,
      DamageBase = 00,
      DamageLevel = 00,
      DurationBase = 6,
      DurationLevel = 3,
      StunAbilityId = ABILITY_A106_CURSE_DRAENEI,
      StunOrderId = ORDER_CURSE,
      SpecialEffect = @"war3mapImported\FrostNova.mdx"
    };
    SpellRegistry.Register(warStompAdal);

    var summonGateway = new SummonUnitsTarget(ABILITY_A0LX_GATEWAY_REINFORCEMENT_DRAENEI)
    {
      SummonUnitTypeId = UNIT_O05B_DEFENDER_DRAENEI,
      SummonCount = 1,
      Radius = 50,
      Duration = 0,
    };
    SpellRegistry.Register(summonGateway);

    var blessedGround = new BlessedGroundSpell(ABILITY_A12V_BLESSED_GROUND_DRAENEI)
    {
      HealPerSecond = 10.0f,
      InitialHeal = 150.0f,
      Duration = 30.0f,
      MaxInitialHeal = 900.0f,
      MaxHealingOverTime = 600.0f,
      Radius = 200.0f,
      HealEffectPath = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
    };
    SpellRegistry.Register(blessedGround);


    var manaSyphon2 = new GrantMana(ABILITY_ADMS_RESTORE_MANA_DRAENEI_CASTER_BUILDING)
    {
      ManaToGrant = 240
    };
    SpellRegistry.Register(manaSyphon2);
  }
}
