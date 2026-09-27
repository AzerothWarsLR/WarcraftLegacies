using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Quests;

public sealed class QuestWarsongHold : QuestData
{
  private const int RequiredResearchId = UPGRADE_R06G_NORTHREND_EXPEDITION_WARSONG;
  private const int RequiredTurn = 20;
  private const int AbilityId = ABILITY_A0DZ_WARSONG_OFFENSIVE_WARSONG;
  private const int SummonGruntsAbilityId = ABILITY_A027_SUMMON_GRUNTS_FROSTWOLF;

  public QuestWarsongHold(QuestData previousQuest) : base("Warsong Hold",
    "The far-off land of Northrend is the new home of the traitor shaman Ner'zhul. The Horde must land its forces on its shores in order to end the existential threat he now represents. The Warsong Clan, now sworn to Thrall, will lead the way.",
    @"ReplaceableTextures\CommandButtons\BTNTuskaarBrown.blp")
  {
    AddObjective(new ObjectiveResearch(RequiredResearchId, UNIT_OSHY_HORDE_PIER_ORCISH_HORDE_SHIPYARD));
    AddObjective(new ObjectiveTurn(RequiredTurn));
    AddObjective(new ObjectiveQuestComplete(previousQuest)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
  }

  public override string RewardFlavour =>
    "The Horde has set sail for the icy shores of Northrend and set up a formidable encampment at Borean Tundra.";

  protected override string RewardDescription => "A new base at Borean Tundra in Northrend";

  protected override void OnComplete(Faction completingFaction)
  {
    var boreanTundra = ControlPointManager.Instance.GetFromUnitType(UNIT_N00G_BOREAN_TUNDRA).Unit;

    var p = completingFaction.Player;
    if (p != null)
    {
      RefundSystem.RefundEnemyStructuresInRange(p, boreanTundra.X, boreanTundra.Y, 2300);
    }

    KillNeutralHostileUnitsInRadius(boreanTundra.X, boreanTundra.Y, 2300);

    boreanTundra.SetOwner(completingFaction.Player);

    var warsongHold = CreateStructureForced(completingFaction.Player, UNIT_OFRT_FORTRESS_ORCISH_HORDE_T3, -7648, 15456, 270, 192);
    warsongHold.Name = Loc.Get("Warsong Hold");
    warsongHold.MaxLife = 4000;
    warsongHold.SetLifePercent(100);
    warsongHold.AddAbility(AbilityId);
    warsongHold.AddAbility(SummonGruntsAbilityId);

    CreateStructureForced(completingFaction.Player, UNIT_OWTW_WATCH_TOWER_ORCISH_HORDE_TOWER, -7296, 15680, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OVLN_VOODOO_LOUNGE_ORCISH_HORDE_SHOP, -7456, 15008, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OTRB_BURROW_ORCISH_HORDE_FARM, -7808, 16512, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OTRB_BURROW_ORCISH_HORDE_FARM, -7296, 16000, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OTRB_BURROW_ORCISH_HORDE_FARM, -7424, 16192, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OTRB_BURROW_ORCISH_HORDE_FARM, -6656, 15616, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OTRB_BURROW_ORCISH_HORDE_FARM, -6912, 15744, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_ODOC_WITCH_DOCTOR_ORCISH_HORDE, -8299, 16110, 1.850517f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OBEA_BEASTIARY_ORCISH_HORDE_SPECIALIST, -8512, 15936, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_ODOC_WITCH_DOCTOR_ORCISH_HORDE, -8513, 16171, 1.126743f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OGRU_GRUNT_ORCISH_HORDE, -8048, 16427, -0.7628738f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OGRU_GRUNT_ORCISH_HORDE, -8065, 15788, -0.08624744f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OTRB_BURROW_ORCISH_HORDE_FARM, -7936, 16768, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OSHY_HORDE_PIER_ORCISH_HORDE_SHIPYARD, -6752, 14880, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_H0AP_FRIGATE_HORDE, -8633, 15012, -1.101598f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OALT_ALTAR_OF_STORMS_ORCISH_HORDE_ALTAR, -6976, 15552, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OWTW_WATCH_TOWER_ORCISH_HORDE_TOWER, -8064, 15360, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OWTW_WATCH_TOWER_ORCISH_HORDE_TOWER, -8320, 16000, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OGRU_GRUNT_ORCISH_HORDE, -7086, 15749, 1.348478f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OWTW_WATCH_TOWER_ORCISH_HORDE_TOWER, -7808, 16128, 4.712389f * MathEx.DegToRad, 128);
    CreateStructureForced(completingFaction.Player, UNIT_OSHY_HORDE_PIER_ORCISH_HORDE_SHIPYARD, -8672, 15328, 4.712389f * MathEx.DegToRad, 128);

    completingFaction.ModObjectLimit(RequiredResearchId, -Faction.Unlimited);
  }

  protected override void OnAdd(Faction whichFaction)
  {
    GameTimeManager.RegisterOnTurn(RequiredTurn, () =>
    {
      if (Progress != QuestProgress.Complete && Progress != QuestProgress.Failed)
      {
        whichFaction.ModObjectLimit(RequiredResearchId, Faction.Unlimited);
      }
    });
  }
}
