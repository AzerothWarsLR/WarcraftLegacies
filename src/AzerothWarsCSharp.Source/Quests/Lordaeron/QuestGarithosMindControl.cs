using AzerothWarsCSharp.MacroTools.FactionSystem;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common; 

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestGarithosMindControl : QuestData
  {
    public QuestGarithosMindControl() : base("Garithos' Mind-Control",
      "Garithos has always had a distrust of other races, he might be tempted to join the Scarlet MindControl.",
      "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp")
    {
      AddQuestItem(new ObjectiveResearch(FourCC("R08F"), FourCC("hbla")));
    }

    protected override string CompletionPopup => "Garithos weak mind is an easy pray to Sylvanas mind control, ";

    protected override string RewardDescription =>
      "You lose everything, but will spawn with Garithos and a small army in Capital City";

    protected override void OnComplete(Faction completingFaction)
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

      completingFaction.Team = TeamSetup.Forsaken;
      completingFaction.Name = "Garithos";
      completingFaction.Icon = "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp";
      SetPlayerColor(completingFaction.Player, PLAYER_COLOR_LIGHT_BLUE);

      LegendLordaeron.LegendGarithos.StartingXp = GetHeroXP(LegendLordaeron.LegendArthas.Unit);
      completingFaction.Obliterate();
      LegendLordaeron.LegendGarithos.Spawn(completingFaction.Player, 9090, 8743, 110);
      LegendForsaken.LegendNathanos.Spawn(completingFaction.Player, 9090, 8743, 110);
      CreateUnits(completingFaction.Player, FourCC("hkni"), Regions.Terenas.Center.X, Regions.Terenas.Center.Y,
        270, 12);
      CreateUnits(completingFaction.Player, FourCC("hpea"), Regions.Terenas.Center.X, Regions.Terenas.Center.Y,
        270, 6);
      CreateUnits(completingFaction.Player, FourCC("hfoo"), Regions.Terenas.Center.X, Regions.Terenas.Center.Y,
        270, 12);
      CreateUnits(completingFaction.Player, FourCC("h009"), Regions.Terenas.Center.X, Regions.Terenas.Center.Y,
        270, 2);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 2000);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 900);
      if (GetLocalPlayer() == completingFaction.Player)
        SetCameraPosition(Regions.Terenas.Center.X, Regions.Terenas.Center.Y);
    }
  }
}