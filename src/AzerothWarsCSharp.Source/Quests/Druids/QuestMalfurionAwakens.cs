//Anyone on the Night Elves team approaches Moonglade with a unit with the Horn of Cenarius,
//Causing Malfurion to spawn.

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestMalfurionAwakens : QuestData{

  
    private group MoongladeUnits;

    private const int HORN_OF_CENARIUS = FourCC("cnhn");
    private const int GHANIR = FourCC("I00C");
  


    protected override string CompletionPopup => "Malfurion has emerged from his deep slumber in the Barrow Den.";

    protected override string CompletionDescription => "Gain the hero Malfurion && the artifact GFourCC(hanir";

    private void GiveMoonglade(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Moonglade
      GroupEnumUnitsInRect(tempGroup, Regions.MoongladeVillage.Rect, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      //Cleanup
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void OnFail( ){
      GiveMoonglade(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GiveMoonglade(Holder.Player);
      if (LEGEND_MALFURION.Unit == null){
        LEGEND_MALFURION.Spawn(Holder.Player, GetRectCenterX(Regions.Moonglade), GetRectCenterY(gg_rct_Moonglade).Rect, 270);
        SetHeroLevel(LEGEND_MALFURION.Unit, 3, false);
        UnitAddItemSafe(LEGEND_MALFURION.Unit, ARTIFACT_GHANIR.item);
      }else {
        SetItemPosition(ARTIFACT_GHANIR.item, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()));
      }
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Awakening of Stormrage", "Ever since the War of the Ancients ten thousand years ago, Malfurion Stormrage && his druids have slumbered within the Barrow Den. Now, their help is required once again.", "ReplaceableTextures\\CommandButtons\\BTNFurion.blp");
      AddQuestItem(new QuestItemAcquireArtifact(ARTIFACT_HORNOFCENARIUS));
      AddQuestItem(new QuestItemArtifactInRect(ARTIFACT_HORNOFCENARIUS, Regions.Moonglade.Rect, "The Barrow Den"));
      AddQuestItem(new QuestItemExpire(1440));
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }


    public static void Setup( ){
      //Setup initially invulnerable and hidden group at Moonglade
      group tempGroup = CreateGroup();
      unit u;
      var i = 0;
      MoongladeUnits = CreateGroup();
      GroupEnumUnitsInRect(tempGroup, Regions.MoongladeVillage.Rect, null);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          SetUnitInvulnerable(u, true);
          GroupAddUnit(MoongladeUnits, u);
        }
        GroupRemoveUnit(tempGroup, u);
        i = i + 1;
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
      //Add quest
    }

  }
}
