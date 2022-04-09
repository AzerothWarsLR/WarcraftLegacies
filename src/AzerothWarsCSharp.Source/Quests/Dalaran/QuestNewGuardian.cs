using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestNewGuardian : QuestData
  {
    public QuestNewGuardian() : base("Guardian of Tirisfal", "Medivh's death left Azeroth without a Guardian. The spell book he left behind could be used to empower a new one.", "ReplaceableTextures\\CommandButtons\\BTNAstral Blessing.blp")
    {
      AddQuestItem(new QuestItemLegendLevel(LegendDalaran.LegendJaina, 15));
      AddQuestItem(new QuestItemLegendHasArtifact(LegendDalaran.LegendJaina, ArtifactSetup.ArtifactBookofmedivh));
    }
    
    protected override string CompletionPopup =>
      "Dalaran has empowered Jaina to be the new Guardian of Tirisfal, endowing her with a portion of the Council of TirisfalFourCC(s power.";

    protected override string RewardDescription =>
      "Grant Jaina Chaos Damage, 20 additional Intelligence, Teleport, && Mana Shield";

    protected override void OnComplete()
    {
      unit whichUnit = LegendDalaran.LegendJaina.Unit;
      UnitRemoveAbilityBJ(FourCC("A0RB"), LegendDalaran.LegendJaina.Unit);
      AddSpecialEffectTarget("war3mapImported\\Soul Armor Cosmic.mdx", whichUnit, "chest");
      BlzSetUnitName(whichUnit, "Guardian of Tirisfal");
      UnitAddAbility(whichUnit, Constants.ABILITY_GUARDIAN_OF_TIRISFAL_DALARAN_GUARDIAN_OF_TIRISFAL);
      BlzSetUnitWeaponIntegerField(whichUnit, UNIT_WEAPON_IF_ATTACK_ATTACK_TYPE, 0, 5); //Chaos
      AddHeroAttributes(whichUnit, 0, 0, 20);
      LegendDalaran.LegendJaina.ClearUnitDependencies();
      LegendDalaran.LegendJaina.PermaDies = false;
    }
  }
}