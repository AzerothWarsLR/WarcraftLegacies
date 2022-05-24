using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common; 

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestTheNexus : QuestData
  {
    public QuestTheNexus() : base("The Nexus",
      "The new Lich King calls for Jaina, tempts her with power. The Nexus needs a master, and Jaina is perfect for it.",
      "ReplaceableTextures\\CommandButtons\\BTNBlueDragonNexus.blp")
    {
      AddObjective(new ObjectiveChannelRect(Regions.JainaChannel, "The Nexus", LegendDalaran.LegendJaina, 60, 270));
      AddObjective(new ObjectiveControlLegend(LegendDalaran.LegendJaina, true));
      AddObjective(new ObjectiveControlLegend(LegendNeutral.LegendNexus, false));
      Global = true;
    }

    protected override string CompletionPopup =>
      "The Nexus powers have been absorbed by Jaina and she joins the Lich King in the eternal ice of Northrend.";

    protected override string RewardDescription =>
      "You become the Nexus faction, allied with the Scourge and enemy with everyone else. Jaina becomes much more powerful";
    
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.ModObjectLimit(FourCC("h069"), -Faction.UNLIMITED); //Military Quarters
      completingFaction.ModObjectLimit(FourCC("h067"), -Faction.UNLIMITED); //Laboratory
      completingFaction.ModObjectLimit(FourCC("n096"), -Faction.UNLIMITED); //Golem
      completingFaction.ModObjectLimit(FourCC("o02U"), -Faction.UNLIMITED); //Crystal artillery
      completingFaction.ModObjectLimit(FourCC("n0AD"), -Faction.UNLIMITED); //Crystal Golem
      completingFaction.ModObjectLimit(FourCC("h032"), -Faction.UNLIMITED); //Battlemage
      completingFaction.ModObjectLimit(FourCC("n007"), -Faction.UNLIMITED); //Kirintor
      completingFaction.ModObjectLimit(FourCC("h022"), -Faction.UNLIMITED); //Peasant
      completingFaction.ModObjectLimit(FourCC("Hant"), -Faction.UNLIMITED); //Antonidas
      completingFaction.ModObjectLimit(FourCC("Haah"), -Faction.UNLIMITED); //Mediv
      completingFaction.ModObjectLimit(FourCC("njks"), -Faction.UNLIMITED); //Kasan
      completingFaction.ModObjectLimit(FourCC("R06O"), -Faction.UNLIMITED); //Phase Blade
      completingFaction.ModObjectLimit(FourCC("R061"), -Faction.UNLIMITED); //Forked Lightning
      RemoveUnit(LegendDalaran.LegendAntonidas.Unit);
      RemoveUnit(LegendDalaran.LegendMedivh.Unit);

      completingFaction.ModObjectLimit(FourCC("U026"), 1); //Malygos
      completingFaction.ModObjectLimit(FourCC("U027"), 1); //Kalecgos
      completingFaction.ModObjectLimit(FourCC("H04A"), 1); //Nexus Jaina

      completingFaction.ModObjectLimit(FourCC("n0A1"), 6); //Elite
      completingFaction.ModObjectLimit(FourCC("h09C"), Faction.UNLIMITED); //Worker
      completingFaction.ModObjectLimit(FourCC("h099"), Faction.UNLIMITED); //Infantry
      completingFaction.ModObjectLimit(FourCC("n0A4"), Faction.UNLIMITED); //Dragonspawn
      completingFaction.ModObjectLimit(FourCC("u025"), 12); //Elementalist
      completingFaction.ModObjectLimit(FourCC("n09T"), 6); //Judicator
      completingFaction.ModObjectLimit(FourCC("h09A"), Faction.UNLIMITED); //Nexus
      completingFaction.ModObjectLimit(FourCC("h09B"), Faction.UNLIMITED); //Roost

      LegendDalaran.LegendJaina.UnitType = FourCC("H04A");

      UnitRemoveAbility(LegendDalaran.LegendJaina.Unit, FourCC("A0RB"));
      completingFaction.Team = TeamSetup.Scourge;
      completingFaction.Name = "The Nexus";
      completingFaction.Icon = "ReplaceableTextures\\CommandButtons\\BTNJaina_Archmage.blp";
      SetPlayerState(completingFaction.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300);
    }
  }
}