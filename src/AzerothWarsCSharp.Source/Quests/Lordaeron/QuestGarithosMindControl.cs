using AzerothWarsCSharp.MacroTools.FactionSystem;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestGarithosMindControl : QuestData
  {
    public QuestGarithosMindControl() : base("Garithos' Mind-Control",
      "Garithos has always had a distrust of other races, he might be tempted to join the Scarlet MindControl.",
      "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp")
    {
      AddQuestItem(new QuestItemResearch(FourCC("R08F"), FourCC("hbla")));
    }

    protected override string CompletionPopup => "Garithos weak mind is an easy pray to Sylvanas mind control, ";

    protected override string RewardDescription =>
      "You lose everything, but will spawn with Garithos and a small army in Capital City";

    protected override void OnComplete()
    {
      LordaeronSetup.FactionLordaeron.ModObjectLimit(FourCC("h00F"), -Faction.UNLIMITED); //Paladin
      LordaeronSetup.FactionLordaeron.ModObjectLimit(FourCC("R06Q"), -Faction.UNLIMITED); //Paladin Adept Training
      LordaeronSetup.FactionLordaeron.ModObjectLimit(FourCC("h012"), -Faction.UNLIMITED); //Falric
      LordaeronSetup.FactionLordaeron.ModObjectLimit(FourCC("Hart"), -Faction.UNLIMITED); //Arthas
      LordaeronSetup.FactionLordaeron.ModObjectLimit(FourCC("Huth"), -Faction.UNLIMITED); //Uther
      LordaeronSetup.FactionLordaeron.ModObjectLimit(FourCC("H01J"), -Faction.UNLIMITED); //Mograine
      LordaeronSetup.FactionLordaeron.ModObjectLimit(FourCC("Harf"), -Faction.UNLIMITED); //Arthas
      LordaeronSetup.FactionLordaeron.ModObjectLimit(FourCC("h009"), 6); //Dark Knight
      LordaeronSetup.FactionLordaeron.ModObjectLimit(FourCC("H049"), 1); //Nathanos
      LordaeronSetup.FactionLordaeron.ModObjectLimit(FourCC("Hlgr"), 1); //Garithos

      Holder.Team = TeamSetup.Forsaken;
      Holder.Name = "Garithos";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp";
      SetPlayerColor(Holder.Player, PLAYER_COLOR_LIGHT_BLUE);

      LegendLordaeron.LegendGarithos.StartingXp = GetHeroXP(LegendLordaeron.LegendArthas.Unit);
      Holder.Obliterate();
      LegendLordaeron.LegendGarithos.Spawn(Holder.Player, 9090, 8743, 110);
      LegendForsaken.LegendNathanos.Spawn(Holder.Player, 9090, 8743, 110);
      CreateUnits(Holder.Player, FourCC("hkni"), Regions.Terenas.Center.X, Regions.Terenas.Center.Y,
        270, 12);
      CreateUnits(Holder.Player, FourCC("hpea"), Regions.Terenas.Center.X, Regions.Terenas.Center.Y,
        270, 6);
      CreateUnits(Holder.Player, FourCC("hfoo"), Regions.Terenas.Center.X, Regions.Terenas.Center.Y,
        270, 12);
      CreateUnits(Holder.Player, FourCC("h009"), Regions.Terenas.Center.X, Regions.Terenas.Center.Y,
        270, 2);
      AdjustPlayerStateBJ(2000, Holder.Player, PLAYER_STATE_RESOURCE_GOLD);
      AdjustPlayerStateBJ(900, Holder.Player, PLAYER_STATE_RESOURCE_LUMBER);
      if (GetLocalPlayer() == Holder.Player)
        SetCameraPosition(Regions.Terenas.Center.X, Regions.Terenas.Center.Y);
    }
  }
}