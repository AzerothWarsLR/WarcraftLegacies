using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestTheNexus : QuestData
  {
    private Global()
    {
      return true;
    }

    public QuestTheNexus() : base("The Nexus",
      "The new Lich King calls for Jaina, tempts her with power. The Nexus needs a master, && Jaina is perfect for it.",
      "ReplaceableTextures\\CommandButtons\\BTNBlueDragonNexus.blp")
    {
      AddQuestItem(new QuestItemChannelRect(Regions.JainaChannel, "The Nexus", LEGEND_JAINA, 60.Rect, 270));
      AddQuestItem(new QuestItemControlLegend(LEGEND_JAINA, true));
      AddQuestItem(new QuestItemControlLegend(LEGEND_NEXUS, false));
      ;
      ;
    }

    protected override string CompletionPopup =>
      "The Nexus powers have been absorbed by Jaina && she joins the Lich King in the eternal ice of Northrend.";

    protected override string CompletionDescription =>
      "You become the Nexus faction, allied with the Scourge && enemy with everyone else. Jaina becomes much more powerful";


    bool operator

    protected override void OnComplete()
    {
      FACTION_DALARAN.ModObjectLimit(FourCC("h069"), -Faction.UNLIMITED); //Military Quarters
      FACTION_DALARAN.ModObjectLimit(FourCC("h067"), -Faction.UNLIMITED); //Laboratory
      FACTION_DALARAN.ModObjectLimit(FourCC("n096"), -Faction.UNLIMITED); //Golem
      FACTION_DALARAN.ModObjectLimit(FourCC("o02U"), -Faction.UNLIMITED); //Crystal artillery
      FACTION_DALARAN.ModObjectLimit(FourCC("n0AD"), -Faction.UNLIMITED); //Crystal Golem
      FACTION_DALARAN.ModObjectLimit(FourCC("h032"), -Faction.UNLIMITED); //Battlemage
      FACTION_DALARAN.ModObjectLimit(FourCC("n007"), -Faction.UNLIMITED); //Kirintor
      FACTION_DALARAN.ModObjectLimit(FourCC("h022"), -Faction.UNLIMITED); //Peasant
      FACTION_DALARAN.ModObjectLimit(FourCC("Hant"), -Faction.UNLIMITED); //Antonidas
      FACTION_DALARAN.ModObjectLimit(FourCC("Haah"), -Faction.UNLIMITED); //Mediv
      FACTION_DALARAN.ModObjectLimit(FourCC("njks"), -Faction.UNLIMITED); //Kasan
      FACTION_DALARAN.ModObjectLimit(FourCC("R06O"), -Faction.UNLIMITED); //Phase Blade
      FACTION_DALARAN.ModObjectLimit(FourCC("R061"), -Faction.UNLIMITED); //Forked Lightning
      RemoveUnit(LEGEND_ANTONIDAS.Unit);
      RemoveUnit(LEGEND_MEDIVH.Unit);

      FACTION_DALARAN.ModObjectLimit(FourCC("U026"), 1); //Malygos
      FACTION_DALARAN.ModObjectLimit(FourCC("U027"), 1); //Kalecgos
      FACTION_DALARAN.ModObjectLimit(FourCC("H04A"), 1); //Nexus Jaina

      FACTION_DALARAN.ModObjectLimit(FourCC("n0A1"), 6); //Elite
      FACTION_DALARAN.ModObjectLimit(FourCC("h09C"), Faction.UNLIMITED); //Worker
      FACTION_DALARAN.ModObjectLimit(FourCC("h099"), Faction.UNLIMITED); //Infantry
      FACTION_DALARAN.ModObjectLimit(FourCC("n0A4"), Faction.UNLIMITED); //Dragonspawn
      FACTION_DALARAN.ModObjectLimit(FourCC("u025"), 12); //Elementalist
      FACTION_DALARAN.ModObjectLimit(FourCC("n09T"), 6); //Judicator
      FACTION_DALARAN.ModObjectLimit(FourCC("h09A"), Faction.UNLIMITED); //Nexus
      FACTION_DALARAN.ModObjectLimit(FourCC("h09B"), Faction.UNLIMITED); //Roost

      LEGEND_JAINA.UnitType = FourCC("H04A");

      UnitRemoveAbilityBJ(FourCC("A0RB"), LEGEND_JAINA.Unit);
      Holder.Team = TeamSetup.TeamScourge;
      Holder.Name = "The Nexus";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNJaina_Archmage.blp";
      SetPlayerStateBJ(Holder.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300);
    }
  }
}