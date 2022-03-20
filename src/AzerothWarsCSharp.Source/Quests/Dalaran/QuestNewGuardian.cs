using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public class QuestNewGuardian{


    protected override string CompletionPopup => 
      return "Dalaran has empowered Jaina to be the new Guardian of Tirisfal, endowing her with a portion of the Council of TirisfalFourCC(s power.";
    }

    protected override string CompletionDescription => 
      return "Grant Jaina Chaos Damage, 20 additional Intelligence, Teleport, && Mana Shield";
    }

    protected override void OnComplete(){
      unit whichUnit = LEGEND_JAINA.Unit;
      UnitRemoveAbilityBJ( FourCC(A0RB), LEGEND_JAINA.Unit);
      AddSpecialEffectTarget("war3mapImported\\Soul Armor Cosmic.mdx", whichUnit, "chest");
      BlzSetUnitName(whichUnit, "Guardian of Tirisfal");
      UnitAddAbility(whichUnit, FourCC(A0BX)) ;//Guardian of Tirisfal Spellbook
      BlzSetUnitWeaponIntegerField(whichUnit, UNIT_WEAPON_IF_ATTACK_ATTACK_TYPE, 0, 5) ;//Chaos
      GeneralHelpers.AddHeroAttributes(whichUnit, 0, 0, 20);
      LEGEND_JAINA.ClearUnitDependencies();
      LEGEND_JAINA.PermaDies = false;
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Guardian of Tirisfal", "MedivhFourCC(s death left Azeroth without a Guardian. The spell book he left behind could be used to empower a new one.", "ReplaceableTextures\\CommandButtons\\BTNAstral Blessing.blp");
      this.AddQuestItem(QuestItemLegendLevel.create(LEGEND_JAINA, 15));
      this.AddQuestItem(QuestItemLegendHasArtifact.create(LEGEND_JAINA, ARTIFACT_BOOKOFMEDIVH));
      ;;
    }


  }
}
