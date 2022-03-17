public class QuestConsumeTree{



    boolean operator Global( ){
      return true;
    }

    private string operator CompletionPopup( ){
      return "Archimonde has now consummed the World Tree && is now nigh unstoppable";
    }

    private string operator CompletionDescription( ){
      return "By consuming the World Tree, Archimonde will obtain immense power. +80 to all stats. Additionally, the Druids faction will be eliminated.";
    }

    private void OnComplete( ){
      unit whichUnit = LEGEND_ARCHIMONDE.Unit;
      FACTION_DRUIDS.obliterate();
      BlzSetUnitName(whichUnit, "Devourer of Worlds");
      AddSpecialEffectTarget("Abilities\\Weapons\\GreenDragonMissile\\GreenDragonMissile.mdl", whichUnit, "hand, right");
      AddSpecialEffectTarget("Abilities\\Weapons\\GreenDragonMissile\\GreenDragonMissile.mdl", whichUnit, "hand, left");
      AddHeroAttributes(whichUnit, 80, 80, 80);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Twilight of the Gods", "Consuming the World Tree will grant Archimonde immeasurable power && eliminate his mortal enemies, the Druids of Kalimdor, forever.", "ReplaceableTextures\\CommandButtons\\BTNGlazeroth.blp");
      this.AddQuestItem(QuestItemChannelRect.create(gg_rct_ArchimondeChannel, "The World Tree", LEGEND_ARCHIMONDE, 420, 90));
      ;;
    }


}
