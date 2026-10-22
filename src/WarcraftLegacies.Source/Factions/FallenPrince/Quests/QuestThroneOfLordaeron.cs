using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FallenPrince.Quests;

/// <summary>Take the Capital Palace to raise a base inside its walls and bring Falric to the Fallen Prince's side.</summary>
public sealed class QuestThroneOfLordaeron : QuestData
{
  private const float Facing = 90;
  private const float StructureSize = 256;
  private const float BlightRadius = 1100;

  private readonly Capital _capitalPalace;
  private readonly LegendaryHero _falric;

  public QuestThroneOfLordaeron(Capital capitalPalace, LegendaryHero falric) : base("The Throne of Lordaeron",
    "Arthas once returned to his father's palace as a hero. Let him return as its master, and the dead of Capital City will rise to serve their prince.",
    @"ReplaceableTextures\CommandButtons\BTNEvilFalric.blp")
  {
    _capitalPalace = capitalPalace;
    _falric = falric;
    AddObjective(new ObjectiveControlCapital(capitalPalace, false, true));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R104_QUEST_COMPLETED_THE_THRONE_OF_LORDAERON_FALLENPRINCE;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Arthas has returned to his father's throne, and the palace guard rise from their graves to kneel before him. Captain Falric, once his most loyal soldier, stands at his side once more.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Gain a blighted base inside the Capital Palace guarded by towers, an army of the risen, and Captain Falric joins you";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var owner = completingFaction.Player;
    if (owner == null)
    {
      return;
    }

    owner.PlayMusicThematic(@"Sound\Music\mp3Music\UndeadX1.mp3");

    var palace = _capitalPalace.Unit;
    if (palace != null)
    {
      SetBlight(owner, palace.X, palace.Y + 500, BlightRadius, true);
    }

    CapitalPalaceRuins.Claim(owner, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM);
    CreateStructureForced(owner, UNIT_USEP_CRYPT_SCOURGE_BARRACKS, 8288, 8800, Facing, StructureSize);
    CreateStructureForced(owner, UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR, 9888, 8672, Facing, StructureSize);
    CreateStructureForced(owner, UNIT_UTOD_TEMPLE_OF_THE_DAMNED_SCOURGE_MAGIC, 9888, 8352, Facing, StructureSize);
    CreateProtector(owner, UNIT_U104_THRONEGUARD_SPIRIT_TOWER_FALLENPRINCE_PROTECTOR, 8704, 8832);
    CreateProtector(owner, UNIT_U104_THRONEGUARD_SPIRIT_TOWER_FALLENPRINCE_PROTECTOR, 9472, 8832);
    CreateProtector(owner, UNIT_U105_THRONEGUARD_NERUBIAN_TOWER_FALLENPRINCE_PROTECTOR, 8640, 9472);
    CreateProtector(owner, UNIT_U105_THRONEGUARD_NERUBIAN_TOWER_FALLENPRINCE_PROTECTOR, 9536, 9472);

    PathBase.SummonLegend(_falric, owner, new Point(9089, 8892));
    CreateRank(owner, UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, 3, 8770);
    CreateRank(owner, UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, 3, 8640);
    CreateRank(owner, UNIT_U103_RISEN_ARCHER_FALLENPRINCE, 4, 8510);
    unit.Create(owner, UNIT_N009_REVENANT_SCOURGE, 8921, 9281, Facing);
    unit.Create(owner, UNIT_N009_REVENANT_SCOURGE, 9213, 9294, Facing);
  }

  private void CreateProtector(player owner, int towerType, float x, float y)
  {
    CapitalPalaceRuins.ClearTowerSpot(x, y);
    var tower = CreateStructureForced(owner, towerType, x, y, Facing, StructureSize);
    if (tower != null)
    {
      _capitalPalace.AddProtector(tower);
    }
  }

  private static void CreateRank(player owner, int unitType, int count, float y)
  {
    const float spacing = 128;
    var startX = 9089 - (count - 1) * spacing / 2;
    for (var i = 0; i < count; i++)
    {
      unit.Create(owner, unitType, startX + i * spacing, y, Facing);
    }
  }
}
