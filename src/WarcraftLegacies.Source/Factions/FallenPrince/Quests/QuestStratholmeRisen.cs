using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.FallenPrince.Quests;

/// <summary>Hold Stratholme with your allies to raise a small base inside the city and let Marwyn be trained.</summary>
public sealed class QuestStratholmeRisen : QuestData
{
  private const float Facing = 270;
  private const float StructureSize = 256;
  private const float BlightRadius = 1600;

  public QuestStratholmeRisen() : base("The Culled Rise",
    "Stratholme burned at Arthas's command. Retake its ruins, and the souls of the culled will answer their prince once more.",
    @"ReplaceableTextures\CommandButtons\BTNHeroDeathKnight.blp")
  {
    AddObjective(new ObjectiveCapitalDead(AllLegends.Lordaeron.Stratholme));
    AddObjective(new ObjectiveControlPoint(UNIT_N01M_STRATHOLME, 0));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R105_QUEST_COMPLETED_THE_CULLED_RISE_FALLENPRINCE;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The ashes of Stratholme stir as the culled claw their way out of the ruins. Captain Marwyn, who carried out the culling at his prince's side, awaits the call to serve again.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Gain a blighted base inside Stratholme, the culled dead rise as zombies around the city while four plague cauldrons raise more over time, and learn to train Captain Marwyn from the Altar of Darkness";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var owner = completingFaction.Player;
    if (owner == null)
    {
      return;
    }

    SetBlight(owner, 14600, 13000, BlightRadius, true);
    CreateStructureForced(owner, UNIT_USEP_CRYPT_SCOURGE_BARRACKS, 15584, 13536, Facing, StructureSize);
    CreateStructureForced(owner, UNIT_UTOD_TEMPLE_OF_THE_DAMNED_SCOURGE_MAGIC, 14624, 13408, Facing, StructureSize);
    CreateStructureForced(owner, UNIT_USLH_SLAUGHTERHOUSE_SCOURGE_SPECIALIST, 13536, 12384, Facing, StructureSize);
    CreateStructureForced(owner, UNIT_UGRV_GRAVEYARD_SCOURGE_RESEARCH, 13920, 11488, Facing, StructureSize);
    CreateStructureForced(owner, UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR, 15904, 12448, Facing, StructureSize);
    CreateStructureForced(owner, UNIT_USHP_HAUNTED_HARBOR_SCOURGE_SHIPYARD, 13664, 14304, Facing, StructureSize);
    TeleportScrollSetting.StockShop(CreateStructureForced(owner, UNIT_UTOM_TOMB_OF_RELICS_SCOURGE_SHOP, 14016, 14528, Facing, StructureSize));
    CreateStructureForced(owner, UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, 14336, 13568, Facing, StructureSize);
    CreateStructureForced(owner, UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, 15808, 13248, Facing, StructureSize);
    CreateStructureForced(owner, UNIT_UZG2_NERUBIAN_TOWER_SCOURGE_TOWER, 14592, 14208, Facing, StructureSize);
    unit.Create(owner, UNIT_U103_RISEN_ARCHER_FALLENPRINCE, 15398, 13446, Facing);
    unit.Create(owner, UNIT_U103_RISEN_ARCHER_FALLENPRINCE, 15565, 13337, Facing);
    unit.Create(owner, UNIT_N009_REVENANT_SCOURGE, 14996, 14180, Facing);
    unit.Create(owner, UNIT_N009_REVENANT_SCOURGE, 15236, 14184, Facing);
    unit.Create(owner, UNIT_UNEC_NECROMANCER_SCOURGE, 14101, 12827, Facing);
    unit.Create(owner, UNIT_UNEC_NECROMANCER_SCOURGE, 14762, 13302, Facing);
    unit.Create(owner, UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, 14564, 11445, Facing);
    unit.Create(owner, UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, 14691, 12979, Facing);
    unit.Create(owner, UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, 14903, 11437, Facing);
    unit.Create(owner, UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, 14939, 12761, Facing);
    CulledOutbreak.Unleash(owner);
  }
}
