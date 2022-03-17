//If Quel)thalas destroys the Legion Nexus, they can train GARITHOS)thas and Blood Mages.
//If they instead lose the Sunwell, they lose everything. If that doesn)t defeat them, they get GARITHOS)thalas, Lorthemar, and some free units at Dalaran Dungeons.

using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Lordaeron
{
  public class QuestGarithosCrusade{



    private string operator CompletionPopup( ){
      return "Garithos has always had a disliking for the other races. His pride && desire for power has led the remnants of the Lordaeron forces to join the crusade";
    }

    private string operator CompletionDescription( ){
      return "You lose everything, but will spawn with Garithos && a small army in Tyr Hand";
    }

    private void OnComplete( ){
      player holderPlayer = this.Holder.Person.Player;
      FACTION_LORDAERON.ModObjectLimit(FourCC(h00F), -UNLIMITED)           ;//Paladin
      FACTION_LORDAERON.ModObjectLimit(FourCC(R06Q), -UNLIMITED)   ;//Paladin Adept Training
      FACTION_LORDAERON.ModObjectLimit(FourCC(h012), -UNLIMITED)           ;//Falric
      FACTION_LORDAERON.ModObjectLimit(FourCC(Hart), -UNLIMITED)           ;//Arthas
      FACTION_LORDAERON.ModObjectLimit(FourCC(Huth), -UNLIMITED)           ;//Uther
      FACTION_LORDAERON.ModObjectLimit(FourCC(H01J), -UNLIMITED)           ;//Mograine
      FACTION_LORDAERON.ModObjectLimit(FourCC(Harf), -UNLIMITED)           ;//Arthas

      FACTION_LORDAERON.ModObjectLimit(FourCC(h009), 6)           ;//Dark Knight
      FACTION_LORDAERON.ModObjectLimit(FourCC(Hlgr), 1)        ;//Garithos
      FACTION_LORDAERON.ModObjectLimit(FourCC(E00O), 1)        ;//Goodchild

      this.Holder.Team = TEAM_SCARLET;
      this.Holder.Name = "|cff800000Garithos|r";
      this.Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp";
      SetPlayerColor(this.Holder.Player, PLAYER_COLOR_MAROON );

      LEGEND_GARITHOS.StartingXP = GetHeroXP(LEGEND_ARTHAS.Unit);
      this.Holder.obliterate();
      LEGEND_GARITHOS.Spawn(this.Holder.Player, 19410, 7975, 110);
      LEGEND_GOODCHILD.Spawn(this.Holder.Player, 19410, 7975, 110);
      CreateUnits(this.Holder.Player, FourCC(hkni), GetRectCenterX(gg_rct_GarithosCrusadeSpawn), GetRectCenterY(gg_rct_GarithosCrusadeSpawn), 270, 12);
      CreateUnits(this.Holder.Player, FourCC(hpea), GetRectCenterX(gg_rct_GarithosCrusadeSpawn), GetRectCenterY(gg_rct_GarithosCrusadeSpawn), 270, 6);
      CreateUnits(this.Holder.Player, FourCC(hfoo), GetRectCenterX(gg_rct_GarithosCrusadeSpawn), GetRectCenterY(gg_rct_GarithosCrusadeSpawn), 270, 12);
      CreateUnits(this.Holder.Player, FourCC(h009), GetRectCenterX(gg_rct_GarithosCrusadeSpawn), GetRectCenterY(gg_rct_GarithosCrusadeSpawn), 270, 2);
      AdjustPlayerStateBJ( 2000, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
      AdjustPlayerStateBJ( 900, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
      if (GetLocalPlayer() == this.Holder.Player){
        SetCameraPosition(GetRectCenterX(gg_rct_GarithosCrusadeSpawn), GetRectCenterY(gg_rct_GarithosCrusadeSpawn));
      }
    }

    public  thistype ( ){
      thistype this = thistype.allocate("GarithosFourCC( Crusade", "Garithos has always had a distrust of other races, he might be tempted to join the Scarlet Crusade.", "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp");
      this.AddQuestItem(QuestItemResearch.create(FourCC(R08E), )hbla)));
      ;;
    }


  }
}
