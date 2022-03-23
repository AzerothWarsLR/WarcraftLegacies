//Anyone on the Night Elves team approaches Moonglade with a unit with the Horn of Cenarius,
//Causing Malfurion to spawn.

using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestHakkar : QuestData{




    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "Hakkar has emerged from the Drowned Temple";
    }

    protected override string CompletionDescription => 
      return "Gain the demigod hero Hakkar";
    }

    protected override void OnComplete(){
      LEGEND_HAKKAR.Spawn(Holder.Player, GetRectCenterX(gg_rct_DrownedTemple), GetRectCenterY(gg_rct_DrownedTemple), 270);
      SetHeroLevel(LEGEND_HAKKAR.Unit, 12, false);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Binding of the Soulflayer", "Hakkar is the most dangerous && powerful of the Troll gods. Only by fusing the Demon Soul would the Zandalari be able to control Hakkar && bind him to their will.", "ReplaceableTextures\\CommandButtons\\BTNWindSerpent2blp");
      this.AddQuestItem(new QuestItemAcquireArtifact(ARTIFACT_ZINROKH));
      this.AddQuestItem(new QuestItemArtifactInRect(ARTIFACT_ZINROKH, gg_rct_DrownedTemple, "The Drowned Temple"));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00U"))));
      ;;
    }


  }
}
