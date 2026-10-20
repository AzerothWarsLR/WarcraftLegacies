using MacroTools.ControlPoints;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Dalaran;
using WarcraftLegacies.Source.Factions.Dalaran.Quests;
using WarcraftLegacies.Source.Factions.FelHorde;
using WarcraftLegacies.Source.Factions.FelHorde.Quests;
using WarcraftLegacies.Source.Factions.Illidari;
using WarcraftLegacies.Source.Factions.Illidari.Quests;
using WarcraftLegacies.Source.Factions.Ironforge;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Factions.Kultiras.Quests;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.Factions.Lordaeron.Quests;
using WarcraftLegacies.Source.Factions.Quelthalas;
using WarcraftLegacies.Source.Factions.Quelthalas.Quests;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Scourge.Quests;
using WarcraftLegacies.Source.Factions.Sentinels;
using WarcraftLegacies.Source.Factions.Sentinels.Quests;
using WarcraftLegacies.Source.Factions.Stormwind;
using WarcraftLegacies.Source.Factions.Stormwind.Quests;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Gives factions their starting bases at the start of a Roleplay game by completing the quests that unlock them,
/// and clears out the hostile creeps that guarded them.
/// The Orcish Horde, the Tauren Tribes and the Druids keep their starting quests.
/// </summary>
public static class RoleplayStartingBases
{
  public static void Unlock()
  {
    if (FactionManager.TryGetFactionByType<LordaeronFaction>(out var lordaeron) && lordaeron.Player != null)
    {
      Complete(lordaeron, lordaeron.GetQuestByType<QuestHearthglen>(), Regions.Hearthglen);
      Complete(lordaeron, lordaeron.GetQuestByType<QuestStrahnbrad>(), Regions.StrahnbradUnlock);
      Complete(lordaeron, lordaeron.GetQuestByType<QuestStratholme>(), Regions.StratholmeUnlock);
      Complete(lordaeron, lordaeron.GetQuestByType<QuestCapitalCity>(), Regions.Terenas);
    }

    if (FactionManager.TryGetFactionByType<DalaranFaction>(out var dalaran) && dalaran.Player != null)
    {
      Complete(dalaran, dalaran.GetQuestByType<QuestShadowfang>(), Regions.ShadowfangUnlock);
      Complete(dalaran, dalaran.GetQuestByType<QuestSouthshore>(), Regions.SouthshoreUnlock);
      Complete(dalaran, dalaran.GetQuestByType<QuestDalaran>(), Regions.Dalaran);
    }

    if (FactionManager.TryGetFactionByType<QuelthalasFaction>(out var quelthalas) && quelthalas.Player != null)
    {
      Complete(quelthalas, quelthalas.GetQuestByType<QuestSilvermoon>(), Regions.SunwellAmbient);
      Complete(quelthalas, quelthalas.GetQuestByType<QuestUnlockSpire>(), Regions.WindrunnerSpireUnlock);
      Complete(quelthalas, quelthalas.GetQuestByType<QuestQueldanil>(), Regions.QuelDanil_Lodge);
    }

    if (FactionManager.TryGetFactionByType<IronforgeFaction>(out var ironforge) && ironforge.Player != null)
    {
      Complete(ironforge, ironforge.GetQuestByType<QuestThelsamar>(), Regions.ThelUnlock);
      Complete(ironforge, ironforge.GetQuestByType<QuestDunMorogh>(), Regions.DunmoroghAmbient2);
      Complete(ironforge, ironforge.GetQuestByType<QuestGnomeregan>(), Regions.Gnomergan);
      Complete(ironforge, ironforge.GetQuestByType<QuestDominion>(), Regions.IronforgeAmbient);
    }

    if (FactionManager.TryGetFactionByType<StormwindFaction>(out var stormwind) && stormwind.Player != null)
    {
      Complete(stormwind, stormwind.GetQuestByType<QuestDarkshire>(), Regions.DarkshireUnlock);
      Complete(stormwind, stormwind.GetQuestByType<QuestLakeshire>(), Regions.LakeshireUnlock);
      Complete(stormwind, stormwind.GetQuestByType<QuestGoldshire>(), Regions.ElwinForestAmbient);
      Complete(stormwind, stormwind.GetQuestByType<QuestStormwindCity>(), Regions.StormwindUnlock);
      Complete(stormwind, stormwind.GetQuestByType<QuestNethergarde>(), Regions.NethergardeUnlock);
    }

    if (FactionManager.TryGetFactionByType<KultirasFaction>(out var kultiras) && kultiras.Player != null)
    {
      Complete(kultiras, kultiras.GetQuestByType<QuestBoralus>(), Regions.Kultiras);
    }

    if (FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge) && scourge.Player != null)
    {
      Complete(scourge, scourge.GetQuestByType<QuestDrakUnlock>(), Regions.DrakUnlock);
      Complete(scourge, scourge.GetQuestByType<QuestEnKilahUnlock>(), Regions.EnKilahUnlock);
      Complete(scourge, scourge.GetQuestByType<QuestSpiderWar>(), Regions.Ice_Crown);
    }

    if (FactionManager.TryGetFactionByType<FelHordeFaction>(out var felHorde) && felHorde.Player != null)
    {
      Complete(felHorde, felHorde.GetQuestByType<QuestHellfireCitadel>(), Regions.HellfireUnlock);
      Complete(felHorde, felHorde.GetQuestByType<QuestBlackrock>(), Regions.BlackrockUnlock, Regions.DarkPortalUnlock);
    }

    if (FactionManager.TryGetFactionByType<IllidariFaction>(out var illidari) && illidari.Player != null)
    {
      Complete(illidari, illidari.GetQuestByType<QuestStranglethornOutpost>(), Regions.IllidariUnlockSA);
    }

    if (FactionManager.TryGetFactionByType<SentinelsFaction>(out var sentinels) && sentinels.Player != null)
    {
      Complete(sentinels, sentinels.GetQuestByType<QuestAstranaar>(), Regions.AstranaarUnlock, Regions.AuberdineUnlock);
    }
  }

  private static void Complete(Faction faction, QuestData quest, params Rectangle[] baseAreas)
  {
    if (quest.Progress == QuestProgress.Complete || quest.Progress == QuestProgress.Failed)
    {
      return;
    }

    quest.SuppressCompletionDisplay = true;
    quest.Progress = QuestProgress.Complete;
    foreach (var baseArea in baseAreas)
    {
      ClaimBaseArea(baseArea, faction.Player);
    }
  }

  /// <summary>Gives the unowned control points in a base to its owner and removes the hostile creeps guarding it.</summary>
  private static void ClaimBaseArea(Rectangle baseArea, player owner)
  {
    foreach (var creep in GlobalGroup.EnumUnitsInRect(baseArea))
    {
      var creepOwner = creep.Owner;
      if (ControlPointManager.Instance.UnitIsControlPoint(creep))
      {
        if (creepOwner == player.NeutralAggressive || creepOwner == player.NeutralPassive)
        {
          creep.SetOwner(owner);
        }

        continue;
      }

      if (creepOwner != player.NeutralAggressive || creep.UnitType == UNIT_NFOH_FOUNTAIN_OF_HEALTH)
      {
        continue;
      }

      if (CapitalManager.UnitIsCapital(creep))
      {
        continue;
      }

      creep.Dispose();
    }
  }
}
