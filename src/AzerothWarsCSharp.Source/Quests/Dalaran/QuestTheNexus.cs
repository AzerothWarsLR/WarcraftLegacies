using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestTheNexus : QuestData{



    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => "The Nexus powers have been absorbed by Jaina && she joins the Lich King in the eternal ice of Northrend.";

    protected override string CompletionDescription => "You become the Nexus faction, allied with the Scourge && enemy with everyone else. Jaina becomes much more powerful";

    protected override void OnComplete(){
      FACTION_DALARAN.ModObjectLimit(FourCC("h069"),-UNLIMITED)       ;//Military Quarters
      FACTION_DALARAN.ModObjectLimit(FourCC("h067"),-UNLIMITED)       ;//Laboratory
      FACTION_DALARAN.ModObjectLimit(FourCC("n096"),-UNLIMITED)       ;//Golem
      FACTION_DALARAN.ModObjectLimit(FourCC("o02U"),-UNLIMITED)       ;//Crystal artillery
      FACTION_DALARAN.ModObjectLimit(FourCC("n0AD"),-UNLIMITED)       ;//Crystal Golem
      FACTION_DALARAN.ModObjectLimit(FourCC("h032"),-UNLIMITED)       ;//Battlemage
      FACTION_DALARAN.ModObjectLimit(FourCC("n007"),-UNLIMITED)       ;//Kirintor
      FACTION_DALARAN.ModObjectLimit(FourCC("h022"),-UNLIMITED)       ;//Peasant
      FACTION_DALARAN.ModObjectLimit(FourCC("Hant"),-UNLIMITED)       ;//Antonidas
      FACTION_DALARAN.ModObjectLimit(FourCC("Haah"),-UNLIMITED)       ;//Mediv
      FACTION_DALARAN.ModObjectLimit(FourCC("njks"),-UNLIMITED)       ;//Kasan
      FACTION_DALARAN.ModObjectLimit(FourCC("R06O"),-UNLIMITED)       ;//Phase Blade
      FACTION_DALARAN.ModObjectLimit(FourCC("R061"),-UNLIMITED)       ;//Forked Lightning
      RemoveUnit(LEGEND_ANTONIDAS.Unit);
      RemoveUnit(LEGEND_MEDIVH.Unit);

      FACTION_DALARAN.ModObjectLimit(FourCC("U026"),1)               ;//Malygos
      FACTION_DALARAN.ModObjectLimit(FourCC("U027"),1)               ;//Kalecgos
      FACTION_DALARAN.ModObjectLimit(FourCC("H04A"),1)               ;//Nexus Jaina

      FACTION_DALARAN.ModObjectLimit(FourCC("n0A1"),6)               ;//Elite
      FACTION_DALARAN.ModObjectLimit(FourCC("h09C"),UNLIMITED)               ;//Worker
      FACTION_DALARAN.ModObjectLimit(FourCC("h099"),UNLIMITED)               ;//Infantry
      FACTION_DALARAN.ModObjectLimit(FourCC("n0A4"),UNLIMITED)               ;//Dragonspawn
      FACTION_DALARAN.ModObjectLimit(FourCC("u025"),12)               ;//Elementalist
      FACTION_DALARAN.ModObjectLimit(FourCC("n09T"),6)               ;//Judicator
      FACTION_DALARAN.ModObjectLimit(FourCC("h09A"),UNLIMITED)               ;//Nexus
      FACTION_DALARAN.ModObjectLimit(FourCC("h09B"),UNLIMITED)               ;//Roost

      LEGEND_JAINA.UnitType = FourCC("H04A");

      UnitRemoveAbilityBJ( FourCC("A0RB"), LEGEND_JAINA.Unit);
      Holder.Team = TEAM_SCOURGE;
      Holder.Name = "The Nexus";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNJaina_Archmage.blp";
      SetPlayerStateBJ( Holder.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300 );
    }

    public  QuestTheNexus ( ){
      thistype this = thistype.allocate("The Nexus", "The new Lich King calls for Jaina, tempts her with power. The Nexus needs a master, && Jaina is perfect for it.", "ReplaceableTextures\\CommandButtons\\BTNBlueDragonNexus.blp");
      AddQuestItem(new QuestItemChannelRect(Regions.JainaChannel, "The Nexus", LEGEND_JAINA, 60.Rect, 270));
      AddQuestItem(new QuestItemControlLegend(LEGEND_JAINA, true));
      AddQuestItem(new QuestItemControlLegend(LEGEND_NEXUS, false));
      ;;
    }


  }
}
