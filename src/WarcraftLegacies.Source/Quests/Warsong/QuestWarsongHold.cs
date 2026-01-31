using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Quests.Warsong;

public sealed class QuestWarsongHold : QuestData
{
  private const int RequiredResearchId = UPGRADE_R06G_NORTHREND_EXPEDITION_WARSONG;
  private const int AbilityId = ABILITY_A0DZ_WARSONG_OFFENSIVE_WARSONG;

  public QuestWarsongHold() : base("Warsong Hold",
    "The far-off land of Northrend is the new home of the traitor shaman Ner'zhul. The Warsong must land its forces on its shores in order to end the existential threat he now represents.",
    @"ReplaceableTextures\CommandButtons\BTNTuskaarBrown.blp")
  {
    AddObjective(new ObjectiveResearch(RequiredResearchId, UNIT_O02T_SHIPYARD_WARSONG_SHIPYARD));
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The Warsong Clan has set sail for the icy shores of Northrend and set up a formidable encampment at Borean Tundra.";

  /// <inheritdoc/>
  protected override string RewardDescription => "A new base at Borean Tundra in Northrend";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    var boreanTundra = ControlPointManager.Instance.GetFromUnitType(UNIT_N00G_BOREAN_TUNDRA).Unit;
    KillNeutralHostileUnitsInRadius(boreanTundra.X, boreanTundra.Y, 2300);
    //Spawn the base
    boreanTundra.SetOwner(completingFaction.Player);
    var warsongHold = CreateStructureForced(completingFaction.Player, UNIT_O02S_FORTRESS_WARSONG_T3, -7648, 15456, 270, 192);
    warsongHold.Name = "Warsong Hold";
    warsongHold.MaxLife = 4000;
    warsongHold.SetLifePercent(100);
    warsongHold.AddAbility(AbilityId);
    CreateStructureForced(completingFaction.Player, UNIT_N03E_IRON_KEEP_WARSONG_TOWER, -7296, 15680, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O01T_TREASURE_HOARD_WARSONG_SHOP, -7456, 15008, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O028_BURROW_WARSONG_FARM, -7808, 16512, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O028_BURROW_WARSONG_FARM, -7296, 16000, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O028_BURROW_WARSONG_FARM, -7424, 16192, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O028_BURROW_WARSONG_FARM, -6656, 15616, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O028_BURROW_WARSONG_FARM, -6912, 15744, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_N08E_SHADOWPRIEST_WARSONG, -8299, 16110, 1.850517f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O02Q_BEASTIARY_WARSONG_SPECIALIST, -8512, 15936, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_N08E_SHADOWPRIEST_WARSONG, -8513, 16171, 1.126743f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O01S_WAR_CAMP_WARSONG_BARRACKS, -8192, 16576, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O02M_WARSONG_GRUNT_WARSONG, -8048, 16427, -0.7628738f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O02M_WARSONG_GRUNT_WARSONG, -8065, 15788, -0.08624744f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O028_BURROW_WARSONG_FARM, -7936, 16768, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O02T_SHIPYARD_WARSONG_SHIPYARD, -6752, 14880, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_H0AP_FRIGATE_HORDE, -8633, 15012, -1.101598f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O020_ALTAR_OF_CONQUERORS_WARSONG_ALTAR, -6976, 15552, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_N03E_IRON_KEEP_WARSONG_TOWER, -8064, 15360, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_N03E_IRON_KEEP_WARSONG_TOWER, -8320, 16000, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O02M_WARSONG_GRUNT_WARSONG, -7086, 15749, 1.348478f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_N03E_IRON_KEEP_WARSONG_TOWER, -7808, 16128, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_ORAI_RAIDER_WARSONG, -7319, 15134, 0.467489f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_O02T_SHIPYARD_WARSONG_SHIPYARD, -8672, 15328, 4.712389f * MathEx.DegToRad, 128);
    completingFaction.ModObjectLimit(RequiredResearchId, -Faction.Unlimited);
  }

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction)
  {
    whichFaction.ModObjectLimit(RequiredResearchId, Faction.Unlimited);
  }
}
