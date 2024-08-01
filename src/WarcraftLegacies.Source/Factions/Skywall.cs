using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Powers;
using MacroTools.ResearchSystems;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Researches;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions
{
  public sealed class Skywall : Faction
  {
    /// <inheritdoc />
    public Skywall() : base("Elemental Lords", PLAYER_COLOR_LIGHT_GRAY, "|cffffffff",
      @"ReplaceableTextures\CommandButtons\BTNFrostRevenant2.blp")
    {
      ControlPointDefenderUnitTypeId = Constants.UNIT_NECP_CONTROL_POINT_DEFENDER_SKYWALL_TOWER;
      TraditionalTeam = TeamSetup.OldGods;
    }

    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterResearches();
      RegisterObjectLimits();
      RegisterSpells();
      SharedFactionConfigSetup.AddSharedFactionConfig(this);
    }

    private void RegisterResearches()
    {
      ResearchManager.Register(new PowerResearch(Constants.UPGRADE_RELT_TRANSFIGURATION_SKYWALL, 100,
        new Windforging(0.25f, new Point(-10396.5f, -20963.6f), "the Vortex Pinnacle", Regions.ElementalRealm)
        {
          IconName = "ItemForging",
          Name = "Windforging",
          AnimatedArmorID = Constants.UNIT_O01I_ANIMATED_ARMOR_ELEMENTAL
        }));
    }

    private void RegisterObjectLimits()
    {
      foreach (var (objectTypeId, objectLimit) in SkywallObjectLimitData.GetAllObjectLimits())
        ModObjectLimit(FourCC(objectTypeId), objectLimit);
    }

    private void RegisterSpells()
    {

      var purgeAttack = new SpellOnAttack(UNIT_O01I_ANIMATED_ARMOR_ELEMENTAL,
        ABILITY_AELP_SHOCKING_BLADES_ANIMATED_ARMOR)
      {
        DummyAbilityId = ABILITY_AEPU_PURGE_SHOCKING_BLADE,
        DummyOrderId = OrderId("purge"),
        ProcChance = 0.20f
      };
      PassiveAbilityManager.Register(purgeAttack);

      var stormSurge = new Stomp(ABILITY_AESS_STORM_SURGE_ARMORED_MISTRAL)
      {
        Radius = 300,
        DamageBase = 60,
        DurationBase = 3,
        StunAbilityId = ABILITY_AEPU_PURGE_SHOCKING_BLADE,
        StunOrderId = OrderId("purge"),
        SpecialEffect = @"war3mapImported\Cyclon Explosion.mdx"
      };
      SpellSystem.Register(stormSurge);

    }
  }
}