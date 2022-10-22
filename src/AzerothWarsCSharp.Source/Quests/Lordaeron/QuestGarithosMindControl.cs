using AzerothWarsCSharp.MacroTools.FactionSystem;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestGarithosMindControl : QuestData
  {
    public QuestGarithosMindControl() : base("Garithos' Mind-Control",
      "Garithos has always had a distrust of other races, he might be tempted to join the Scarlet MindControl.",
      "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp")
    {
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R08F_GARITHOS_MIND_CONTROL_LORDAERON, Constants.UNIT_HBLA_BLACKSMITH_LORDAERON));
    }

    protected override string CompletionPopup => "Garithos weak mind is an easy pray to Sylvanas mind control, ";

    protected override string RewardDescription =>
      "You lose everything, but will spawn with Garithos and a small army in Capital City";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.ModObjectLimit(Constants.UNIT_H00F_PALADIN_LORDAERON, -Faction.UNLIMITED);
      completingFaction.ModObjectLimit(Constants.UPGRADE_R06Q_PALADIN_MASTER_TRAINING_LORDAERON, -Faction.UNLIMITED);
      completingFaction.ModObjectLimit(Constants.UNIT_H012_CAPTAIN_FALRIC_LORDAERON_DEMI, -Faction.UNLIMITED);
      completingFaction.ModObjectLimit(Constants.UNIT_HART_CROWN_PRINCE_OF_LORDAERON_LORDAERON, -Faction.UNLIMITED);
      completingFaction.ModObjectLimit(Constants.UNIT_HUTH_LEADER_OF_THE_SILVER_HAND_LORDAERON, -Faction.UNLIMITED);
      completingFaction.ModObjectLimit(Constants.UNIT_H01J_THE_ASHBRINGER_LORDAERON, -Faction.UNLIMITED);
      completingFaction.ModObjectLimit(Constants.UNIT_HARF_HIGH_KING_LORDAERON_HIGH_KING, -Faction.UNLIMITED);
      completingFaction.ModObjectLimit(Constants.UNIT_H009_DARK_KNIGHT_GARITHOS, 6);
      completingFaction.ModObjectLimit(Constants.UNIT_H049_RANGER_LORD_FORSAKEN, 1);
      completingFaction.ModObjectLimit(Constants.UNIT_HLGR_GRAND_MARSHAL_SCARLET, 1);

      completingFaction.Player?.SetTeam(TeamSetup.Forsaken);
      completingFaction.Name = "Garithos";
      completingFaction.Icon = "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp";
      SetPlayerColor(completingFaction.Player, PLAYER_COLOR_LIGHT_BLUE);

      LegendLordaeron.LegendGarithos.StartingXp = GetHeroXP(LegendLordaeron.LegendArthas.Unit);
      completingFaction.Obliterate();
      LegendLordaeron.LegendGarithos.Spawn(completingFaction.Player, new Point(9090, 8743), 110);
      LegendForsaken.Nathanos.Spawn(completingFaction.Player, new Point(9090, 8743), 110);
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