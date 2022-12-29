using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Lordaeron
{
  /// <summary>
  /// Reasearch 'Join the Crusade' at the blacksmith to join the <see cref="TeamSetup.ScarletCrusade"/> team. 
  /// <para/>
  /// Lose everything but gain new units and heroes.
  /// </summary>
  public sealed class QuestGarithosCrusade : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestGarithosCrusade"/> class.
    /// </summary>
    public QuestGarithosCrusade() : base("Garithos' Crusade",
      "Garithos has always had a distrust of other races, he might be tempted to join the Scarlet Crusade.",
      "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp")
    {
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R08E_JOIN_THE_CRUSADE_LORDAERON, Constants.UNIT_HBLA_BLACKSMITH_LORDAERON));
    }

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "Garithos has always had a disliking for the other races. His pride and desire for power has led the remnants of the Lordaeron forces to join the crusade";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "You lose everything, but will spawn with Garithos and a small army in Tyr Hand";

    /// <inheritdoc/>
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
      completingFaction.ModObjectLimit(Constants.UNIT_HLGR_GRAND_MARSHAL_SCARLET, 1);
      completingFaction.ModObjectLimit(Constants.UNIT_E000_IMPROVED_ANCIENT_PROTECTOR_DRUIDS, 1);

      completingFaction.Player?.SetTeam(TeamSetup.ScarletCrusade);
      completingFaction.Name = "Garithos";
      completingFaction.Icon = "ReplaceableTextures\\CommandButtons\\BTNGarithos.blp";
      SetPlayerColor(completingFaction.Player, PLAYER_COLOR_MAROON);

      LegendLordaeron.Garithos.StartingXp = GetHeroXP(LegendLordaeron.Arthas.Unit);
      completingFaction.Obliterate();
      LegendLordaeron.Garithos.ForceCreate(completingFaction.Player, new Point(19410, 7975), 110);
      LegendLordaeron.Goodchild.ForceCreate(completingFaction.Player, new Point(19410, 7975), 110);
   
      CreateUnits(completingFaction.Player, Constants.UNIT_HKNI_KNIGHT_LORDAERON, Regions.GarithosCrusadeSpawn.Center.X,
        Regions.GarithosCrusadeSpawn.Center.Y, 270, 12);
      CreateUnits(completingFaction.Player, Constants.UNIT_HPEA_PEASANT_LORDAERON_STORMWIND_WORKER, Regions.GarithosCrusadeSpawn.Center.X,
        Regions.GarithosCrusadeSpawn.Center.Y, 270, 6);
      CreateUnits(completingFaction.Player, Constants.UNIT_HFOO_FOOTMAN_LORDAERON, Regions.GarithosCrusadeSpawn.Center.X,
        Regions.GarithosCrusadeSpawn.Center.Y, 270, 12);
      CreateUnits(completingFaction.Player, Constants.UNIT_H009_DARK_KNIGHT_GARITHOS, Regions.GarithosCrusadeSpawn.Center.X,
        Regions.GarithosCrusadeSpawn.Center.Y, 270, 2);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 2000);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 900);
      if (GetLocalPlayer() == completingFaction.Player)
        SetCameraPosition(Regions.GarithosCrusadeSpawn.Center.X,
          Regions.GarithosCrusadeSpawn.Center.Y);
    }
  }
}