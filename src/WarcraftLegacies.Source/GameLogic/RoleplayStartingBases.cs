using MacroTools.ControlPoints;
using MacroTools.Extensions;
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
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>Starts Roleplay factions in their capitals with their bases unlocked and their first heroes ready.</summary>
public static class RoleplayStartingBases
{
  private const float StartingKitRadius = 700;
  private const float HeroSpacing = 150;
  private const float HeroDistanceFromCapital = 400;

  public static void Unlock()
  {
    if (FactionManager.TryGetFactionByType<LordaeronFaction>(out var lordaeron) && lordaeron.Player != null)
    {
      StartInCapital(lordaeron, AllLegends.Lordaeron.CapitalPalace);
      Complete(lordaeron, lordaeron.GetQuestByType<QuestHearthglen>(), Regions.Hearthglen);
      Complete(lordaeron, lordaeron.GetQuestByType<QuestStrahnbrad>(), Regions.StrahnbradUnlock);
      Complete(lordaeron, lordaeron.GetQuestByType<QuestStratholme>(), Regions.StratholmeUnlock);
      Complete(lordaeron, lordaeron.GetQuestByType<QuestCapitalCity>(), Regions.Terenas);
      SpawnHero(lordaeron, AllLegends.Lordaeron.Uther, new Point(9099, 8912));
      SpawnHero(lordaeron, AllLegends.Lordaeron.Arthas, new Point(15120, 13698));
    }

    if (FactionManager.TryGetFactionByType<DalaranFaction>(out var dalaran) && dalaran.Player != null)
    {
      StartInCapital(dalaran, AllLegends.Dalaran.Dalaran);
      Complete(dalaran, dalaran.GetQuestByType<QuestShadowfang>(), Regions.ShadowfangUnlock);
      Complete(dalaran, dalaran.GetQuestByType<QuestSouthshore>(), Regions.SouthshoreUnlock);
      Complete(dalaran, dalaran.GetQuestByType<QuestDalaran>(), Regions.Dalaran);
      SpawnHero(dalaran, AllLegends.Dalaran.Jaina, AllLegends.Dalaran.Dalaran, 0);
      SpawnHero(dalaran, AllLegends.Dalaran.Antonidas, AllLegends.Dalaran.Dalaran, 1);
    }

    if (FactionManager.TryGetFactionByType<QuelthalasFaction>(out var quelthalas) && quelthalas.Player != null)
    {
      StartInCapital(quelthalas, AllLegends.Quel.Silvermoon);
      Complete(quelthalas, quelthalas.GetQuestByType<QuestSilvermoon>(), Regions.SunwellAmbient);
      Complete(quelthalas, quelthalas.GetQuestByType<QuestUnlockSpire>(), Regions.WindrunnerSpireUnlock);
      Complete(quelthalas, quelthalas.GetQuestByType<QuestQueldanil>(), Regions.QuelDanil_Lodge);
      SpawnHero(quelthalas, AllLegends.Quel.Anasterian, new Point(19838, 18290));
      SpawnHero(quelthalas, AllLegends.Quel.Sylvanas, new Point(16823, 13714));
    }

    if (FactionManager.TryGetFactionByType<IronforgeFaction>(out var ironforge) && ironforge.Player != null)
    {
      StartInCapital(ironforge, AllLegends.Ironforge.GreatForge);
      Complete(ironforge, ironforge.GetQuestByType<QuestThelsamar>(), Regions.ThelUnlock);
      Complete(ironforge, ironforge.GetQuestByType<QuestDunMorogh>(), Regions.DunmoroghAmbient2);
      Complete(ironforge, ironforge.GetQuestByType<QuestGnomeregan>(), Regions.Gnomergan);
      Complete(ironforge, ironforge.GetQuestByType<QuestDominion>(), Regions.IronforgeAmbient);
      SpawnHero(ironforge, AllLegends.Ironforge.Muradin, AllLegends.Ironforge.GreatForge, 0);
      SpawnHero(ironforge, AllLegends.Ironforge.Magni, new Point(10641, -4413));
    }

    if (FactionManager.TryGetFactionByType<StormwindFaction>(out var stormwind) && stormwind.Player != null)
    {
      StartInCapital(stormwind, AllLegends.Stormwind.StormwindKeep);
      Complete(stormwind, stormwind.GetQuestByType<QuestDarkshire>(), Regions.DarkshireUnlock);
      Complete(stormwind, stormwind.GetQuestByType<QuestLakeshire>(), Regions.LakeshireUnlock);
      Complete(stormwind, stormwind.GetQuestByType<QuestGoldshire>(), Regions.ElwinForestAmbient);
      Complete(stormwind, stormwind.GetQuestByType<QuestStormwindCity>(), Regions.StormwindUnlock);
      Complete(stormwind, stormwind.GetQuestByType<QuestNethergarde>(), Regions.NethergardeUnlock);
      SpawnHero(stormwind, AllLegends.Stormwind.Varian, new Point(9781, -10995));
      SpawnHero(stormwind, AllLegends.Stormwind.Bolvar, new Point(17165, -17321));
    }

    if (FactionManager.TryGetFactionByType<KultirasFaction>(out var kultiras) && kultiras.Player != null)
    {
      StartInCapital(kultiras, AllLegends.Kultiras.LegendBoralus);
      Complete(kultiras, kultiras.GetQuestByType<QuestBoralus>(), Regions.Kultiras);
      SpawnHero(kultiras, AllLegends.Kultiras.LegendAdmiral, AllLegends.Kultiras.LegendBoralus, 0);
      SpawnHero(kultiras, AllLegends.Kultiras.LegendKatherine, AllLegends.Kultiras.LegendBoralus, 1);
    }

    if (FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge) && scourge.Player != null)
    {
      StartInCapital(scourge, AllLegends.Scourge.TheFrozenThrone);
      Complete(scourge, scourge.GetQuestByType<QuestDrakUnlock>(), Regions.DrakUnlock);
      Complete(scourge, scourge.GetQuestByType<QuestEnKilahUnlock>(), Regions.EnKilahUnlock);
      Complete(scourge, scourge.GetQuestByType<QuestSpiderWar>(), Regions.Ice_Crown);
      SpawnHero(scourge, AllLegends.Scourge.Kelthuzad, Regions.DrakUnlock.Center);
      SpawnHero(scourge, AllLegends.Scourge.Anubarak, Regions.EnKilahUnlock.Center);
    }

    if (FactionManager.TryGetFactionByType<FelHordeFaction>(out var felHorde) && felHorde.Player != null)
    {
      StartInCapital(felHorde, AllLegends.FelHorde.HellfireCitadel);
      Complete(felHorde, felHorde.GetQuestByType<QuestHellfireCitadel>(), Regions.HellfireUnlock);
      Complete(felHorde, felHorde.GetQuestByType<QuestBlackrock>(), Regions.BlackrockUnlock);
      felHorde.Player.SetTechResearched(UPGRADE_R090_ACTIVATE_THE_BLACKROCK_CLAN_FEL, 1);
      SpawnHero(felHorde, AllLegends.FelHorde.Magtheridon, new Point(637, -26035));
      SpawnHero(felHorde, AllLegends.FelHorde.Rend, new Point(13059, -10991));
      SpawnDemiHero(felHorde, UNIT_N05T_KAZZAK_THE_SUPREME_FEL_DEMI, new Point(1850, -26173));
    }

    if (FactionManager.TryGetFactionByType<IllidariFaction>(out var illidari) && illidari.Player != null)
    {
      Complete(illidari, illidari.GetQuestByType<QuestStranglethornOutpost>(), Regions.IllidariUnlockSA);
    }

    if (FactionManager.TryGetFactionByType<SentinelsFaction>(out var sentinels) && sentinels.Player != null)
    {
      Complete(sentinels, sentinels.GetQuestByType<QuestAstranaar>(), Regions.AstranaarUnlock, Regions.AuberdineUnlock);
      SpawnHero(sentinels, AllLegends.Sentinels.Shandris, new Point(-16777, 9861));
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
    faction.HideQuest(quest);
    foreach (var baseArea in baseAreas)
    {
      ClaimBaseArea(baseArea, faction.Player);
    }
  }

  private static void StartInCapital(Faction faction, Capital capital)
  {
    var owner = faction.Player;
    var capitalUnit = capital.Unit;
    if (owner == null || capitalUnit == null)
    {
      return;
    }

    var startLocation = GetPlayerStartLocation(owner);
    var startX = GetStartLocationX(startLocation);
    var startY = GetStartLocationY(startLocation);
    foreach (var startingUnit in GlobalGroup.EnumUnitsInRange(new Point(startX, startY), StartingKitRadius))
    {
      if (startingUnit.Owner != owner || CapitalManager.UnitIsCapital(startingUnit))
      {
        continue;
      }

      if (startingUnit.IsUnitType(unittype.TownHall) || startingUnit.IsUnitType(unittype.Peon))
      {
        startingUnit.Dispose();
      }
    }

    owner.RepositionCamera(capitalUnit.X, capitalUnit.Y);
  }

  private static void SpawnHero(Faction faction, LegendaryHero hero, Capital capital, int slot)
  {
    var capitalUnit = capital.Unit;
    if (capitalUnit != null)
    {
      SpawnHero(faction, hero, new Point(capitalUnit.X + (slot * 2 - 1) * HeroSpacing, capitalUnit.Y - HeroDistanceFromCapital));
    }
  }

  private static void SpawnHero(Faction faction, LegendaryHero hero, Point position)
  {
    var owner = faction.Player;
    if (owner == null || hero.Unit != null)
    {
      return;
    }

    hero.ForceCreate(owner, position, 270);
    var heroUnit = hero.Unit;
    if (heroUnit != null)
    {
      GameStartVoteSequence.PauseUnit(heroUnit);
    }
  }

  private static void SpawnDemiHero(Faction faction, int unitType, Point position)
  {
    var owner = faction.Player;
    if (owner == null || owner.CountUnitsOfUnitType(unitType) > 0)
    {
      return;
    }

    GameStartVoteSequence.PauseUnit(unit.Create(owner, unitType, position.X, position.Y, 270));
  }

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
