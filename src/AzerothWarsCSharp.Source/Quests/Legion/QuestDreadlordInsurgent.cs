//If Quel)thalas destroys the Legion Nexus, they can train GARITHOS)thas and Blood Mages.
//If they instead lose the Sunwell, they lose everything. If that doesn)t defeat them, they get GARITHOS)thalas, Lorthemar, and some free units at Dalaran Dungeons.

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestDreadlordInsurgent : QuestData{



    protected override string CompletionPopup => "The Dreadlord has quickly fallen to Sylvanas && forced to join the Forsaken ";

    protected override string CompletionDescription => "You lose everything, but will spawn with a small army, Varimathras && Lilian Voss near Capital City";

    protected override void OnComplete(){
      player holderPlayer = Holder.Person.Player;

      FACTION_LEGION.ModObjectLimit(FourCC("Utic"), -UNLIMITED)           ;//Tichondrius
      FACTION_LEGION.ModObjectLimit(FourCC("Umal"), -UNLIMITED)           ;//maglanis
      FACTION_LEGION.ModObjectLimit(FourCC("U00L"), -UNLIMITED)           ;//Anatheron

      FACTION_LEGION.ModObjectLimit(FourCC("E01O"), 1)        ;//Lilian
      FACTION_LEGION.ModObjectLimit(FourCC("Uvar"), 1)        ;//Vari

      Holder.Team = TEAM_FORSAKEN;
      Holder.Name = "|cff8080ffInsurgents|r";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNHeroDreadLord.blp";
      SetPlayerColor(Holder.Player, PLAYER_COLOR_LIGHT_BLUE );

      LEGEND_VARIMATHRAS.StartingXp = GetHeroXP(LEGEND_TICHONDRIUS.Unit);
      LEGEND_LILIAN.StartingXp = GetHeroXP(LEGEND_MALGANIS.Unit);
      Holder.obliterate();
      LEGEND_LILIAN.Spawn(Holder.Player, 7254, 7833, 110);
      LEGEND_VARIMATHRAS.Spawn(Holder.Player, 7254, 7833, 110);
      CreateUnits(Holder.Player, FourCC("n04J"), GetRectCenterX(Regions.VandermarVillage), GetRectCenterY(gg_rct_Vandermar_Village), 270.Rect, 12);
      CreateUnits(Holder.Player, FourCC("u00D"), GetRectCenterX(Regions.VandermarVillage), GetRectCenterY(gg_rct_Vandermar_Village), 270.Rect, 6);
      CreateUnits(Holder.Player, FourCC("ninc"), GetRectCenterX(Regions.VandermarVillage), GetRectCenterY(gg_rct_Vandermar_Village), 270.Rect, 12);
      CreateUnits(Holder.Player, FourCC("u007"), GetRectCenterX(Regions.VandermarVillage), GetRectCenterY(gg_rct_Vandermar_Village), 270.Rect, 2);
      AdjustPlayerStateBJ( 2000, Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
      AdjustPlayerStateBJ( 900, Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
      if (GetLocalPlayer() == Holder.Player){
        SetCameraPosition(GetRectCenterX(Regions.VandermarVillage).Rect, GetRectCenterY(gg_rct_Vandermar_Village));
      }
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Dreadlord Insurgent", "Varimathras has branched out && tried to take control of the Plaguelands, Sylvanas will try && make him join her cause", "ReplaceableTextures\\CommandButtons\\BTNHeroDreadLord.blp");
      this.AddQuestItem(new QuestItemResearch(FourCC("R08H"), )n040)));
      
    }


  }
}
