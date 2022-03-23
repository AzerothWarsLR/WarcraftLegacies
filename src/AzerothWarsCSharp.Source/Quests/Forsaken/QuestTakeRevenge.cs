using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public class QuestTakeRevenge{


    protected override string CompletionPopup => 
      return "With the Lich King eliminated, Sylvanas vengeance is finally complete. She has absorbed his power && has become the Banshee Queen";
    }

    protected override string CompletionDescription => 
      return "Sylvanas gains 20 intelligence, 20 strength && Chaos damage";
    }

    protected override void OnComplete(){
      unit whichUnit = LEGEND_SYLVANASV.Unit;
      BlzSetUnitName(whichUnit, "Banshee Queen");
      AddSpecialEffectTarget("war3mapImported\\SoulArmor.mdx", whichUnit, "chest");
      BlzSetUnitWeaponIntegerField(whichUnit, UNIT_WEAPON_IF_ATTACK_ATTACK_TYPE, 0, 5) ;//Chaos
      GeneralHelpers.AddHeroAttributes(whichUnit, 20, 0, 20);
      LEGEND_SYLVANASV.ClearUnitDependencies();
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Cold-Hearted Revenge", "Sylvanas longs to take revenge on the Lich King. Killing him && absorbing his power would maybe satisfy the emptiness inside her", "ReplaceableTextures\\CommandButtons\\BTNHelmofdomination.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC("n0BC"))));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_SYLVANASV, true));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_LICHKING));
      ;;
    }


  }
}
