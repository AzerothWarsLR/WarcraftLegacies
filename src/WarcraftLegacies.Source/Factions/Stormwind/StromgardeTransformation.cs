using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Shared;
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

  private static readonly Dictionary<int, int> _noEquivalents = new();

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
    FactionTransition.AssignNewFaction(stormwind, new StromgardeFaction(stormwind));
    PathBase.RemoveHero(AllLegends.Stormwind.Varian);
    PathBase.RemoveHero(AllLegends.Stormwind.Bolvar);
    PathBase.RemoveHero(AllLegends.Stormwind.Khadgar);

    var heir = GetHeir(out var heirEquivalents);
    PathBase.HandOverStructures(whichPlayer, heir, heirEquivalents, Regions.Stromgarde);

    PathBase.RelocateArmy(whichPlayer, _noEquivalents, _stromgardeKeep.X, _stromgardeKeep.Y - 600);
    PathBase.SummonLegend(AllLegends.Stormwind.Thoras, whichPlayer, new Point(_stromgardeKeep.X, _stromgardeKeep.Y - 400));
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

  private static bool IsStillInGame(Faction faction) =>
    faction.Player != null && faction.ScoreStatus == ScoreStatus.Undefeated;
}
