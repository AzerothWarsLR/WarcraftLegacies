using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
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
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R08E_JOIN_THE_CRUSADE_LORDAERON, Constants.UNIT_HBLA_BLACKSMITH_LORDAERON));
    }

    protected override string CompletionPopup =>
      "Garithos has always had a disliking for the other races. His pride and desire for power has led the remnants of the Lordaeron forces to join the crusade";

    protected override string RewardDescription =>
      "You lose everything, but will spawn with Garithos and a small army in Tyr Hand";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player?.ModObjectLimit(Constants.UNIT_H00F_PALADIN_LORDAERON, -Faction.UNLIMITED);
      completingFaction.Player?.ModObjectLimit(Constants.UPGRADE_R06Q_PALADIN_MASTER_TRAINING_LORDAERON, -Faction.UNLIMITED);
      completingFaction.Player?.ModObjectLimit(Constants.UNIT_H012_CAPTAIN_FALRIC_LORDAERON_DEMI, -Faction.UNLIMITED);
      completingFaction.Player?.ModObjectLimit(Constants.UNIT_HART_CROWN_PRINCE_OF_LORDAERON_LORDAERON, -Faction.UNLIMITED);
      completingFaction.Player?.ModObjectLimit(Constants.UNIT_HUTH_LEADER_OF_THE_SILVER_HAND_LORDAERON, -Faction.UNLIMITED);
      completingFaction.Player?.ModObjectLimit(Constants.UNIT_H01J_THE_ASHBRINGER_LORDAERON, -Faction.UNLIMITED);
      completingFaction.Player?.ModObjectLimit(Constants.UNIT_HARF_HIGH_KING_LORDAERON_HIGH_KING, -Faction.UNLIMITED);

      completingFaction.Player?.ModObjectLimit(Constants.UNIT_H009_DARK_KNIGHT_GARITHOS, 6);
      completingFaction.Player?.ModObjectLimit(Constants.UNIT_HLGR_GRAND_MARSHAL_SCARLET, 1);
      completingFaction.Player?.ModObjectLimit(Constants.UNIT_E000_IMPROVED_ANCIENT_PROTECTOR_DRUIDS, 1);

      completingFaction.Player?.SetTeam(TeamSetup.ScarletCrusade);
      completingFaction.Name = "Garithos";
      completingFaction.Icon = "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp";
      SetPlayerColor(completingFaction.Player, PLAYER_COLOR_MAROON);

      LegendLordaeron.LegendGarithos.StartingXp = GetHeroXP(LegendLordaeron.LegendArthas.Unit);
      completingFaction.Obliterate();
      LegendLordaeron.LegendGarithos.Spawn(completingFaction.Player, new Point(19410, 7975), 110);
      LegendLordaeron.LegendGoodchild.Spawn(completingFaction.Player, new Point(19410, 7975), 110);
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