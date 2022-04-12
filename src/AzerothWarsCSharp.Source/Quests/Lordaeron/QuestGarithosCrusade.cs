using AzerothWarsCSharp.MacroTools.FactionSystem;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;

using static War3Api.Common; using static War3Api.Blizzard;

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
      Holder.Person.ModObjectLimit(FourCC("h00F"), -Faction.UNLIMITED); //Paladin
      Holder.Person.ModObjectLimit(FourCC("R06Q"), -Faction.UNLIMITED); //Paladin Adept Training
      Holder.Person.ModObjectLimit(FourCC("h012"), -Faction.UNLIMITED); //Falric
      Holder.Person.ModObjectLimit(FourCC("Hart"), -Faction.UNLIMITED); //Arthas
      Holder.Person.ModObjectLimit(FourCC("Huth"), -Faction.UNLIMITED); //Uther
      Holder.Person.ModObjectLimit(FourCC("H01J"), -Faction.UNLIMITED); //Mograine
      Holder.Person.ModObjectLimit(FourCC("Harf"), -Faction.UNLIMITED); //Arthas

      Holder.Person.ModObjectLimit(FourCC("h009"), 6); //Dark Knight
      Holder.Person.ModObjectLimit(FourCC("Hlgr"), 1); //Garithos
      Holder.Person.ModObjectLimit(FourCC("E00O"), 1); //Goodchild

      Holder.Team = TeamSetup.TeamScarlet;
      Holder.Name = "|cff800000Garithos|r";
      Holder.PrefixCol = "|cff800000";
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