//If Quel)thalas destroys the Legion Nexus, they can train GARITHOS)thas and Blood Mages.
//If they instead lose the Sunwell, they lose everything. If that doesn)t defeat them, they get GARITHOS)thalas, Lorthemar, and some free units at Dalaran Dungeons.

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public class QuestGarithosMindControl{



    protected override string CompletionPopup => 
      return "Garithos weak mind is an easy pray to Sylvanas mind control, ";
    }

    protected override string CompletionDescription => 
      return "You lose everything, but will spawn with Garithos && a small army in Capital City";
    }

    protected override void OnComplete(){
      player holderPlayer = this.Holder.Person.Player;
      FACTION_LORDAERON.ModObjectLimit(FourCC(h00F), -UNLIMITED)           ;//Paladin
      FACTION_LORDAERON.ModObjectLimit(FourCC(R06Q), -UNLIMITED)   ;//Paladin Adept Training
      FACTION_LORDAERON.ModObjectLimit(FourCC(h012), -UNLIMITED)           ;//Falric
      FACTION_LORDAERON.ModObjectLimit(FourCC(Hart), -UNLIMITED)           ;//Arthas
      FACTION_LORDAERON.ModObjectLimit(FourCC(Huth), -UNLIMITED)           ;//Uther
      FACTION_LORDAERON.ModObjectLimit(FourCC(H01J), -UNLIMITED)           ;//Mograine
      FACTION_LORDAERON.ModObjectLimit(FourCC(Harf), -UNLIMITED)           ;//Arthas

      FACTION_LORDAERON.ModObjectLimit(FourCC(h009), 6)           ;//Dark Knight
      FACTION_LORDAERON.ModObjectLimit(FourCC(H049), 1)        ;//Nathanos
      FACTION_LORDAERON.ModObjectLimit(FourCC(Hlgr), 1)        ;//Garithos

      this.Holder.Team = TEAM_FORSAKEN;
      this.Holder.Name = "|cff8080ffGarithos|r";
      this.Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp";
      SetPlayerColor(this.Holder.Player, PLAYER_COLOR_LIGHT_BLUE );

      LEGEND_GARITHOS.StartingXp = GetHeroXP(LEGEND_ARTHAS.Unit);
      this.Holder.obliterate();
      LEGEND_GARITHOS.Spawn(this.Holder.Player, 9090, 8743, 110);
      LEGEND_NATHANOS.Spawn(this.Holder.Player, 9090, 8743, 110);
      GeneralHelpers.CreateUnits(this.Holder.Player, FourCC(hkni), GetRectCenterX(gg_rct_Terenas), GetRectCenterY(gg_rct_Terenas), 270, 12);
      GeneralHelpers.CreateUnits(this.Holder.Player, FourCC(hpea), GetRectCenterX(gg_rct_Terenas), GetRectCenterY(gg_rct_Terenas), 270, 6);
      GeneralHelpers.CreateUnits(this.Holder.Player, FourCC(hfoo), GetRectCenterX(gg_rct_Terenas), GetRectCenterY(gg_rct_Terenas), 270, 12);
      GeneralHelpers.CreateUnits(this.Holder.Player, FourCC(h009), GetRectCenterX(gg_rct_Terenas), GetRectCenterY(gg_rct_Terenas), 270, 2);
      AdjustPlayerStateBJ( 2000, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
      AdjustPlayerStateBJ( 900, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
      if (GetLocalPlayer() == this.Holder.Player){
        SetCameraPosition(GetRectCenterX(gg_rct_Terenas), GetRectCenterY(gg_rct_Terenas));
      }
    }

    public  thistype ( ){
      thistype this = thistype.allocate("GarithosFourCC( Mind-Control", "Garithos has always had a distrust of other races, he might be tempted to join the Scarlet MindControl.", "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp");
      this.AddQuestItem(QuestItemResearch.create(FourCC(R08F), )hbla)));
      ;;
    }


  }
}
