using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestGarithosCrusade : QuestData
  {
    public QuestGarithosCrusade() : base("Garithos' Crusade",
      "Garithos has always had a distrust of other races, he might be tempted to join the Scarlet Crusade.",
      "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp")
    {
      AddQuestItem(new QuestItemResearch(FourCC("R08E"), FourCC("hbla")));
    }

    protected override string CompletionPopup =>
      "Garithos has always had a disliking for the other races. His pride and desire for power has led the remnants of the Lordaeron forces to join the crusade";

    protected override string RewardDescription =>
      "You lose everything, but will spawn with Garithos and a small army in Tyr Hand";

    protected override void OnComplete()
    {
      Holder.Player?.ModObjectLimit(FourCC("h00F"), -Faction.UNLIMITED); //Paladin
      Holder.Player?.ModObjectLimit(FourCC("R06Q"), -Faction.UNLIMITED); //Paladin Adept Training
      Holder.Player?.ModObjectLimit(FourCC("h012"), -Faction.UNLIMITED); //Falric
      Holder.Player?.ModObjectLimit(FourCC("Hart"), -Faction.UNLIMITED); //Arthas
      Holder.Player?.ModObjectLimit(FourCC("Huth"), -Faction.UNLIMITED); //Uther
      Holder.Player?.ModObjectLimit(FourCC("H01J"), -Faction.UNLIMITED); //Mograine
      Holder.Player?.ModObjectLimit(FourCC("Harf"), -Faction.UNLIMITED); //Arthas

      Holder.Player?.ModObjectLimit(FourCC("h009"), 6); //Dark Knight
      Holder.Player?.ModObjectLimit(FourCC("Hlgr"), 1); //Garithos
      Holder.Player?.ModObjectLimit(FourCC("E00O"), 1); //Goodchild

      Holder.Team = TeamSetup.ScarletCrusade;
      Holder.Name = "Garithos";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp";
      SetPlayerColor(Holder.Player, PLAYER_COLOR_MAROON);

      LegendLordaeron.LegendGarithos.StartingXp = GetHeroXP(LegendLordaeron.LegendArthas.Unit);
      Holder.Obliterate();
      LegendLordaeron.LegendGarithos.Spawn(Holder.Player, 19410, 7975, 110);
      LegendLordaeron.LegendGoodchild.Spawn(Holder.Player, 19410, 7975, 110);
      CreateUnits(Holder.Player, FourCC("hkni"), Regions.GarithosCrusadeSpawn.Center.X,
        Regions.GarithosCrusadeSpawn.Center.Y, 270, 12);
      CreateUnits(Holder.Player, FourCC("hpea"), Regions.GarithosCrusadeSpawn.Center.X,
        Regions.GarithosCrusadeSpawn.Center.Y, 270, 6);
      CreateUnits(Holder.Player, FourCC("hfoo"), Regions.GarithosCrusadeSpawn.Center.X,
        Regions.GarithosCrusadeSpawn.Center.Y, 270, 12);
      CreateUnits(Holder.Player, FourCC("h009"), Regions.GarithosCrusadeSpawn.Center.X,
        Regions.GarithosCrusadeSpawn.Center.Y, 270, 2);
      AdjustPlayerStateBJ(2000, Holder.Player, PLAYER_STATE_RESOURCE_GOLD);
      AdjustPlayerStateBJ(900, Holder.Player, PLAYER_STATE_RESOURCE_LUMBER);
      if (GetLocalPlayer() == Holder.Player)
        SetCameraPosition(Regions.GarithosCrusadeSpawn.Center.X,
          Regions.GarithosCrusadeSpawn.Center.Y);
    }
  }
}