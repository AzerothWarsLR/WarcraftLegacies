using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestTakeRevenge : QuestData{


    protected override string CompletionPopup => "With the Lich King eliminated, Sylvanas vengeance is finally complete. She has absorbed his power && has become the Banshee Queen";

    protected override string CompletionDescription => "Sylvanas gains 20 intelligence, 20 strength && Chaos damage";

    protected override void OnComplete(){
      unit whichUnit = LEGEND_SYLVANASV.Unit;
      BlzSetUnitName(whichUnit, "Banshee Queen");
      AddSpecialEffectTarget("war3mapImported\\SoulArmor.mdx", whichUnit, "chest");
      BlzSetUnitWeaponIntegerField(whichUnit, UNIT_WEAPON_IF_ATTACK_ATTACK_TYPE, 0, 5) ;//Chaos
      AddHeroAttributes(whichUnit, 20, 0, 20);
      LEGEND_SYLVANASV.ClearUnitDependencies();
    }

    public  QuestTakeRevenge ( ){
      thistype this = thistype.allocate("Cold-Hearted Revenge", "Sylvanas longs to take revenge on the Lich King. Killing him && absorbing his power would maybe satisfy the emptiness inside her", "ReplaceableTextures\\CommandButtons\\BTNHelmofdomination.blp");
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n0BC"))));
      AddQuestItem(new QuestItemControlLegend(LEGEND_SYLVANASV, true));
      AddQuestItem(new QuestItemLegendDead(LEGEND_LICHKING));
      ;;
    }


  }
}
