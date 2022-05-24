using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestGarithosCrusade : QuestData
  {
    public QuestGarithosCrusade() : base("Garithos' Crusade",
      "Garithos has always had a distrust of other races, he might be tempted to join the Scarlet Crusade.",
      "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp")
    {
      AddQuestItem(new ObjectiveResearch(FourCC("R08E"), FourCC("hbla")));
    }

    protected override string CompletionPopup =>
      "Garithos has always had a disliking for the other races. His pride and desire for power has led the remnants of the Lordaeron forces to join the crusade";

    protected override string RewardDescription =>
      "You lose everything, but will spawn with Garithos and a small army in Tyr Hand";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player?.ModObjectLimit(FourCC("h00F"), -Faction.UNLIMITED); //Paladin
      completingFaction.Player?.ModObjectLimit(FourCC("R06Q"), -Faction.UNLIMITED); //Paladin Adept Training
      completingFaction.Player?.ModObjectLimit(FourCC("h012"), -Faction.UNLIMITED); //Falric
      completingFaction.Player?.ModObjectLimit(FourCC("Hart"), -Faction.UNLIMITED); //Arthas
      completingFaction.Player?.ModObjectLimit(FourCC("Huth"), -Faction.UNLIMITED); //Uther
      completingFaction.Player?.ModObjectLimit(FourCC("H01J"), -Faction.UNLIMITED); //Mograine
      completingFaction.Player?.ModObjectLimit(FourCC("Harf"), -Faction.UNLIMITED); //Arthas

      completingFaction.Player?.ModObjectLimit(FourCC("h009"), 6); //Dark Knight
      completingFaction.Player?.ModObjectLimit(FourCC("Hlgr"), 1); //Garithos
      completingFaction.Player?.ModObjectLimit(FourCC("E00O"), 1); //Goodchild

      completingFaction.Team = TeamSetup.ScarletCrusade;
      completingFaction.Name = "Garithos";
      completingFaction.Icon = "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp";
      SetPlayerColor(completingFaction.Player, PLAYER_COLOR_MAROON);

      LegendLordaeron.LegendGarithos.StartingXp = GetHeroXP(LegendLordaeron.LegendArthas.Unit);
      completingFaction.Obliterate();
      LegendLordaeron.LegendGarithos.Spawn(completingFaction.Player, 19410, 7975, 110);
      LegendLordaeron.LegendGoodchild.Spawn(completingFaction.Player, 19410, 7975, 110);
      CreateUnits(completingFaction.Player, FourCC("hkni"), Regions.GarithosCrusadeSpawn.Center.X,
        Regions.GarithosCrusadeSpawn.Center.Y, 270, 12);
      CreateUnits(completingFaction.Player, FourCC("hpea"), Regions.GarithosCrusadeSpawn.Center.X,
        Regions.GarithosCrusadeSpawn.Center.Y, 270, 6);
      CreateUnits(completingFaction.Player, FourCC("hfoo"), Regions.GarithosCrusadeSpawn.Center.X,
        Regions.GarithosCrusadeSpawn.Center.Y, 270, 12);
      CreateUnits(completingFaction.Player, FourCC("h009"), Regions.GarithosCrusadeSpawn.Center.X,
        Regions.GarithosCrusadeSpawn.Center.Y, 270, 2);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 2000);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 900);
      if (GetLocalPlayer() == completingFaction.Player)
        SetCameraPosition(Regions.GarithosCrusadeSpawn.Center.X,
          Regions.GarithosCrusadeSpawn.Center.Y);
    }
  }
}