using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestNewGuardian : QuestData
  {
    public QuestNewGuardian() : base("Guardian of Tirisfal",
      "Medivh's death left Azeroth without a Guardian. The spell book he left behind could be used to empower a new one.",
      "ReplaceableTextures\\CommandButtons\\BTNAstral Blessing.blp")
    {
      AddQuestItem(new QuestItemLegendLevel(LegendDalaran.LegendJaina, 15));
      AddQuestItem(new QuestItemLegendHasArtifact(LegendDalaran.LegendJaina, ArtifactSetup.ArtifactBookofmedivh));
    }

    protected override string CompletionPopup =>
      "Dalaran has empowered Jaina to be the new Guardian of Tirisfal, endowing her with a portion of the Council of TirisfalFourCC(s power.";

    protected override string RewardDescription =>
      "Grant Jaina Chaos Damage, 20 additional Intelligence, Teleport, and Mana Shield";

    protected override void OnComplete()
    {
      unit whichUnit = LegendDalaran.LegendJaina.Unit;
      UnitRemoveAbilityBJ(FourCC("A0RB"), LegendDalaran.LegendJaina.Unit);
      AddSpecialEffectTarget("war3mapImported\\Soul Armor Cosmic.mdx", whichUnit, "chest");
      BlzSetUnitName(whichUnit, "Guardian of Tirisfal");
      UnitAddAbility(whichUnit, Constants.ABILITY_A0BX_GUARDIAN_OF_TIRISFAL_DALARAN_GUARDIAN_OF_TIRISFAL);
      BlzSetUnitWeaponIntegerField(whichUnit, UNIT_WEAPON_IF_ATTACK_ATTACK_TYPE, 0, 5); //Chaos
      whichUnit.AddHeroAttributes(0, 0, 20);
      LegendDalaran.LegendJaina.ClearUnitDependencies();
      LegendDalaran.LegendJaina.PermaDies = false;
    }
  }
}