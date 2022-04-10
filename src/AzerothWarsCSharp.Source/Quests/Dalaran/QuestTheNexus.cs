using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;

using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestTheNexus : QuestData
  {
    public QuestTheNexus() : base("The Nexus",
      "The new Lich King calls for Jaina, tempts her with power. The Nexus needs a master, and Jaina is perfect for it.",
      "ReplaceableTextures\\CommandButtons\\BTNBlueDragonNexus.blp")
    {
      AddQuestItem(new QuestItemChannelRect(Regions.JainaChannel.Rect, "The Nexus", LegendDalaran.LegendJaina, 60, 270));
      AddQuestItem(new QuestItemControlLegend(LegendDalaran.LegendJaina, true));
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.LegendNexus, false));
      Global = true;
    }

    protected override string CompletionPopup =>
      "The Nexus powers have been absorbed by Jaina and she joins the Lich King in the eternal ice of Northrend.";

    protected override string RewardDescription =>
      "You become the Nexus faction, allied with the Scourge and enemy with everyone else. Jaina becomes much more powerful";
    
    protected override void OnComplete()
    {
      Holder.ModObjectLimit(FourCC("h069"), -Faction.UNLIMITED); //Military Quarters
      Holder.ModObjectLimit(FourCC("h067"), -Faction.UNLIMITED); //Laboratory
      Holder.ModObjectLimit(FourCC("n096"), -Faction.UNLIMITED); //Golem
      Holder.ModObjectLimit(FourCC("o02U"), -Faction.UNLIMITED); //Crystal artillery
      Holder.ModObjectLimit(FourCC("n0AD"), -Faction.UNLIMITED); //Crystal Golem
      Holder.ModObjectLimit(FourCC("h032"), -Faction.UNLIMITED); //Battlemage
      Holder.ModObjectLimit(FourCC("n007"), -Faction.UNLIMITED); //Kirintor
      Holder.ModObjectLimit(FourCC("h022"), -Faction.UNLIMITED); //Peasant
      Holder.ModObjectLimit(FourCC("Hant"), -Faction.UNLIMITED); //Antonidas
      Holder.ModObjectLimit(FourCC("Haah"), -Faction.UNLIMITED); //Mediv
      Holder.ModObjectLimit(FourCC("njks"), -Faction.UNLIMITED); //Kasan
      Holder.ModObjectLimit(FourCC("R06O"), -Faction.UNLIMITED); //Phase Blade
      Holder.ModObjectLimit(FourCC("R061"), -Faction.UNLIMITED); //Forked Lightning
      RemoveUnit(LegendDalaran.LegendAntonidas.Unit);
      RemoveUnit(LegendDalaran.LegendMedivh.Unit);

      Holder.ModObjectLimit(FourCC("U026"), 1); //Malygos
      Holder.ModObjectLimit(FourCC("U027"), 1); //Kalecgos
      Holder.ModObjectLimit(FourCC("H04A"), 1); //Nexus Jaina

      Holder.ModObjectLimit(FourCC("n0A1"), 6); //Elite
      Holder.ModObjectLimit(FourCC("h09C"), Faction.UNLIMITED); //Worker
      Holder.ModObjectLimit(FourCC("h099"), Faction.UNLIMITED); //Infantry
      Holder.ModObjectLimit(FourCC("n0A4"), Faction.UNLIMITED); //Dragonspawn
      Holder.ModObjectLimit(FourCC("u025"), 12); //Elementalist
      Holder.ModObjectLimit(FourCC("n09T"), 6); //Judicator
      Holder.ModObjectLimit(FourCC("h09A"), Faction.UNLIMITED); //Nexus
      Holder.ModObjectLimit(FourCC("h09B"), Faction.UNLIMITED); //Roost

      LegendDalaran.LegendJaina.UnitType = FourCC("H04A");

      UnitRemoveAbilityBJ(FourCC("A0RB"), LegendDalaran.LegendJaina.Unit);
      Holder.Team = TeamSetup.TeamScourge;
      Holder.Name = "The Nexus";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNJaina_Archmage.blp";
      SetPlayerStateBJ(Holder.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300);
    }
  }
}