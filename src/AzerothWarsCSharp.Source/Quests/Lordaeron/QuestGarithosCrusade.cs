//If Quel)thalas destroys the Legion Nexus, they can train GARITHOS)thas and Blood Mages.
//If they instead lose the Sunwell, they lose everything. If that doesn)t defeat them, they get GARITHOS)thalas, Lorthemar, and some free units at Dalaran Dungeons.

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestGarithosCrusade : QuestData{



    protected override string CompletionPopup => "Garithos has always had a disliking for the other races. His pride && desire for power has led the remnants of the Lordaeron forces to join the crusade";

    protected override string CompletionDescription => "You lose everything, but will spawn with Garithos && a small army in Tyr Hand";

    protected override void OnComplete(){
      player holderPlayer = Holder.Person.Player;
      FACTION_LORDAERON.ModObjectLimit(FourCC("h00F"), -UNLIMITED)           ;//Paladin
      FACTION_LORDAERON.ModObjectLimit(FourCC("R06Q"), -UNLIMITED)   ;//Paladin Adept Training
      FACTION_LORDAERON.ModObjectLimit(FourCC("h012"), -UNLIMITED)           ;//Falric
      FACTION_LORDAERON.ModObjectLimit(FourCC("Hart"), -UNLIMITED)           ;//Arthas
      FACTION_LORDAERON.ModObjectLimit(FourCC("Huth"), -UNLIMITED)           ;//Uther
      FACTION_LORDAERON.ModObjectLimit(FourCC("H01J"), -UNLIMITED)           ;//Mograine
      FACTION_LORDAERON.ModObjectLimit(FourCC("Harf"), -UNLIMITED)           ;//Arthas

      FACTION_LORDAERON.ModObjectLimit(FourCC("h009"), 6)           ;//Dark Knight
      FACTION_LORDAERON.ModObjectLimit(FourCC("Hlgr"), 1)        ;//Garithos
      FACTION_LORDAERON.ModObjectLimit(FourCC("E00O"), 1)        ;//Goodchild

      Holder.Team = TEAM_SCARLET;
      Holder.Name = "|cff800000Garithos|r";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp";
      SetPlayerColor(Holder.Player, PLAYER_COLOR_MAROON );

      LEGEND_GARITHOS.StartingXp = GetHeroXP(LEGEND_ARTHAS.Unit);
      Holder.obliterate();
      LEGEND_GARITHOS.Spawn(Holder.Player, 19410, 7975, 110);
      LEGEND_GOODCHILD.Spawn(Holder.Player, 19410, 7975, 110);
      CreateUnits(Holder.Player, FourCC("hkni"), GetRectCenterX(Regions.GarithosCrusadeSpawn), GetRectCenterY(gg_rct_GarithosCrusadeSpawn), 270.Rect, 12);
      CreateUnits(Holder.Player, FourCC("hpea"), GetRectCenterX(Regions.GarithosCrusadeSpawn), GetRectCenterY(gg_rct_GarithosCrusadeSpawn), 270.Rect, 6);
      CreateUnits(Holder.Player, FourCC("hfoo"), GetRectCenterX(Regions.GarithosCrusadeSpawn), GetRectCenterY(gg_rct_GarithosCrusadeSpawn), 270.Rect, 12);
      CreateUnits(Holder.Player, FourCC("h009"), GetRectCenterX(Regions.GarithosCrusadeSpawn), GetRectCenterY(gg_rct_GarithosCrusadeSpawn), 270.Rect, 2);
      AdjustPlayerStateBJ( 2000, Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
      AdjustPlayerStateBJ( 900, Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
      if (GetLocalPlayer() == Holder.Player){
        SetCameraPosition(GetRectCenterX(Regions.GarithosCrusadeSpawn).Rect, GetRectCenterY(gg_rct_GarithosCrusadeSpawn));
      }
    }

    public  QuestGarithosCrusade ( ){
      thistype this = thistype.allocate("GarithosFourCC(" Crusade", "Garithos has always had a distrust of other races, he might be tempted to join the Scarlet Crusade.", "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp"");
      this.AddQuestItem(new QuestItemResearch(FourCC("R08E"), )hbla)));
      ;;
    }


  }
}
