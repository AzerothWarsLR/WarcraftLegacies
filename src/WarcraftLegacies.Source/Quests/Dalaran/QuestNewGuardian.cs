using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Dalaran
{
  public sealed class QuestNewGuardian : QuestData
  {
    private readonly LegendaryHero _jaina;

    public QuestNewGuardian(Artifact bookOfMedivh, LegendaryHero jaina) : base("Guardian of Tirisfal",
      "Medivh's death left Azeroth without a Guardian. The spell book he left behind could be used to empower a new one.",
      "ReplaceableTextures\\CommandButtons\\BTNAstral Blessing.blp")
    {
      _jaina = jaina;
      AddObjective(new ObjectiveLegendLevel(jaina, 15));
      AddObjective(new ObjectiveLegendHasArtifact(jaina, bookOfMedivh));
    }

    protected override string RewardFlavour =>
      "Dalaran has empowered Jaina to be the new Guardian of Tirisfal, endowing her with a portion of the Council of Tirisfal's power.";

    protected override string RewardDescription =>
      "Grant Jaina Chaos Damage, 20 additional Intelligence, Teleport, and Mana Shield";

    protected override void OnComplete(Faction completingFaction)
    {
      var whichUnit = _jaina.Unit;
      UnitRemoveAbility(whichUnit, FourCC("A0RB"));
      AddSpecialEffectTarget("war3mapImported\\Soul Armor Cosmic.mdx", whichUnit, "chest");
      BlzSetUnitName(whichUnit, "Guardian of Tirisfal");
      UnitAddAbility(whichUnit, Constants.ABILITY_A0BX_GUARDIAN_OF_TIRISFAL_DALARAN_GUARDIAN_OF_TIRISFAL);
      BlzSetUnitWeaponIntegerField(whichUnit, UNIT_WEAPON_IF_ATTACK_ATTACK_TYPE, 0, 5); //Chaos
      whichUnit.AddHeroAttributes(0, 0, 20);
      _jaina.ClearUnitDependencies();
      _jaina.PermaDies = false;
    }
  }
}