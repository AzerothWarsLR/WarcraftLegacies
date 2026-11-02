using System.Collections.Generic;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using MacroTools.Shared;
using MacroTools.Utils;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Ironforge;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Factions.Stormwind.Quests;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Stormwind;

/// <summary>Turns Stormwind into Stromgarde, holding Stromgarde Keep and leaving the rest of its land to the Alliance.</summary>
public sealed class StromgardeTransformation
{
  private static readonly Point _stromgardeKeep = new(14064, 912);
  private const float ClearRadius = 800;
  private const float SecondHandOverDelay = 1;

  private static readonly Dictionary<int, int> _landmarks = new()
  {
    { UNIT_H024_LIGHT_HOUSE_STORMWIND_OTHER, UnitEquivalents.Keep },
    { UNIT_H05J_CHAMPION_S_HALL_STORMWIND_OTHER, UnitEquivalents.Keep },
    { UNIT_H05A_WIZARD_S_SANCTUM_STORMWIND_OTHER, UnitEquivalents.Keep }
  };

  private static Dictionary<int, int> IronforgeEquivalents => UnitEquivalents.Pair(
    StormwindObjectInfo.GetAllObjectLimits(), IronforgeObjectInfo.GetAllObjectLimits(), new Dictionary<int, int>(_landmarks)
    {
      { UNIT_H06Y_ARCANE_TOWER_STORMWIND_TOWER, UNIT_H07I_GUARD_TOWER_IRONFORGE_TOWER },
      { UNIT_H06Z_IMPROVED_ARCANE_TOWER_STORMWIND_TOWER, UNIT_H07L_IMPROVED_GUARD_TOWER_IRONFORGE_TOWER }
    });

  private static Dictionary<int, int> KultirasEquivalents => UnitEquivalents.Pair(
    StormwindObjectInfo.GetAllObjectLimits(), KultirasObjectInfo.GetAllObjectLimits(), new Dictionary<int, int>(_landmarks)
    {
      { UNIT_H06Y_ARCANE_TOWER_STORMWIND_TOWER, UNIT_H07S_GUARD_TOWER_KULTIRAS_TOWER },
      { UNIT_H06Z_IMPROVED_ARCANE_TOWER_STORMWIND_TOWER, UNIT_H07T_IMPROVED_GUARD_TOWER_KULTIRAS_TOWER }
    });

  /// <summary>Turns <paramref name="stormwind"/>'s player into Stromgarde.</summary>
  public void Execute(Faction stormwind)
  {
    var whichPlayer = stormwind.Player;
    if (whichPlayer == null)
    {
      return;
    }

    ClaimHeldLands(stormwind);
    var stromgarde = new StromgardeFaction(stormwind);
    FactionTransition.AssignNewFaction(stormwind, stromgarde);
    CarryOverResearches(stromgarde, whichPlayer);
    PathBase.RemoveHero(AllLegends.Stormwind.Varian);
    PathBase.RemoveHero(AllLegends.Stormwind.Bolvar);
    PathBase.RemoveHero(AllLegends.Stormwind.Khadgar);

    var heir = GetHeir(out var heirEquivalents);
    PathBase.HandOverStructures(whichPlayer, heir, heirEquivalents, Regions.Stromgarde);
    PathBase.ConvertStructures(whichPlayer, StromgardeFaction.UnitEquivalents);

    PathBase.RelocateArmy(whichPlayer, StromgardeFaction.UnitEquivalents, _stromgardeKeep.X, _stromgardeKeep.Y - 600);
    PathBase.SummonLegend(AllLegends.Stormwind.Thoras, whichPlayer, new Point(_stromgardeKeep.X, _stromgardeKeep.Y - 400));
    FortifyStromgardeKeep(whichPlayer);
    StromgardeQuests.Setup(stormwind, stromgarde);
    HandOverLateStructures(whichPlayer, heir, heirEquivalents);
    whichPlayer.PlayMusicThematic(@"Sound\Music\mp3Music\AllianceBattleMarch.ogg");
  }

  /// <summary>
  /// Completes the Stromgarde quest so its lands come to Stormwind's player, and ends Stormwind's other
  /// unfinished land quests so the units they hold come to it instead of going hostile.
  /// </summary>
  private static void ClaimHeldLands(Faction stormwind)
  {
    foreach (var quest in stormwind.GetAllQuests())
    {
      quest.SuppressFailureDisplay = true;
    }

    var questStromgarde = stormwind.GetQuestByType<QuestStromgarde>();
    if (IsUnfinished(questStromgarde))
    {
      questStromgarde.Progress = QuestProgress.Complete;
    }

    EndQuest(stormwind.GetQuestByType<QuestDarkshire>());
    EndQuest(stormwind.GetQuestByType<QuestLakeshire>());
    EndQuest(stormwind.GetQuestByType<QuestGoldshire>());
    EndQuest(stormwind.GetQuestByType<QuestStormwindCity>());
    EndQuest(stormwind.GetQuestByType<QuestNethergarde>());
  }

  private static void EndQuest(QuestData quest)
  {
    if (IsUnfinished(quest))
    {
      quest.Progress = QuestProgress.Failed;
    }
  }

  private static bool IsUnfinished(QuestData quest) =>
    quest.Progress != QuestProgress.Complete && quest.Progress != QuestProgress.Failed;

  /// <summary>Ironforge if it's still in the game, otherwise Kul Tiras, otherwise nobody, with the buildings each turns Stormwind buildings into.</summary>
  private static player GetHeir(out Dictionary<int, int>? equivalents)
  {
    if (FactionManager.TryGetFactionByType<IronforgeFaction>(out var ironforge) && IsStillInGame(ironforge))
    {
      equivalents = IronforgeEquivalents;
      return ironforge.Player!;
    }

    if (FactionManager.TryGetFactionByType<KultirasFaction>(out var kultiras) && IsStillInGame(kultiras))
    {
      equivalents = KultirasEquivalents;
      return kultiras.Player!;
    }

    equivalents = null;
    return player.NeutralPassive;
  }

  /// <summary>Makes Stromgarde Keep a capital, with the improved cannon towers in Stromgarde rebuilt as Stromgarde Protectors that guard it.</summary>
  private static void FortifyStromgardeKeep(player whichPlayer)
  {
    var keep = AllPreplacedWidgets.Units.Get(UNIT_H02V_STROMGARDE_KEEP_STORMWIND_OTHER);
    if (keep == null || !keep.Alive || keep.Owner != whichPlayer)
    {
      return;
    }

    var capital = new Capital
    {
      Unit = keep,
      Capturable = true
    };
    CapitalManager.Register(capital);
    foreach (var tower in GlobalGroup.EnumUnitsInRect(Regions.Stromgarde))
    {
      if (!tower.Alive || tower.Owner != whichPlayer || tower.UnitType != UNIT_H0G1_IMPROVED_CANNON_TOWER_STROMGARDE)
      {
        continue;
      }

      var x = tower.X;
      var y = tower.Y;
      var facing = tower.Facing;
      tower.Dispose();
      var protector = unit.Create(whichPlayer, UNIT_H0GM_STROMGARDE_PROTECTOR_STROMGARDE_PROTECTOR, x, y, facing);
      if (protector != null)
      {
        capital.AddProtector(protector);
      }
    }
  }

  /// <summary>Gives Stromgarde the Arathi Highlands control point, clearing out creeps and other players' buildings around it.</summary>
  private static void ClaimArathiHighlands(player whichPlayer)
  {
    var controlPoint = ControlPointManager.Instance.GetFromUnitType(UNIT_N01Z_ARATHI_HIGHLANDS).Unit;
    foreach (var whichUnit in GlobalGroup.EnumUnitsInRange(controlPoint.X, controlPoint.Y, ClearRadius))
    {
      if (!whichUnit.Alive || !whichUnit.IsRemovable() || whichUnit.Owner == whichPlayer || whichUnit == controlPoint)
      {
        continue;
      }

      var owner = whichUnit.Owner;
      var isStructure = whichUnit.IsUnitType(unittype.Structure);
      if (owner == player.NeutralAggressive && !isStructure)
      {
        whichUnit.DropAllItems();
        whichUnit.Dispose();
      }
      else if (isStructure && owner != player.NeutralPassive && owner != player.NeutralAggressive)
      {
        owner.Gold += whichUnit.GoldCost;
        whichUnit.Dispose();
      }
    }

    controlPoint.SetOwner(whichPlayer);
  }

  /// <summary>Hands over any buildings outside Stromgarde that reached the player just after the path was taken, then claims the Arathi Highlands.</summary>
  private static void HandOverLateStructures(player whichPlayer, player heir, Dictionary<int, int>? heirEquivalents)
  {
    var delay = timer.Create();
    delay.Start(SecondHandOverDelay, false, () =>
    {
      delay.Dispose();
      PathBase.HandOverStructures(whichPlayer, heir, heirEquivalents, Regions.Stromgarde);
      ClaimArathiHighlands(whichPlayer);
    });
  }

  /// <summary>Gives Stromgarde every level Stormwind had in a research it replaces with its own.</summary>
  private static void CarryOverResearches(Faction stromgarde, player whichPlayer)
  {
    foreach (var pair in StromgardeFaction.ResearchEquivalents)
    {
      var level = whichPlayer.GetTechResearched(pair.Key, false);
      if (level > 0)
      {
        stromgarde.SetObjectLevel(pair.Value, level);
      }
    }
  }

  private static bool IsStillInGame(Faction faction) =>
    faction.Player != null && faction.ScoreStatus == ScoreStatus.Undefeated;
}
