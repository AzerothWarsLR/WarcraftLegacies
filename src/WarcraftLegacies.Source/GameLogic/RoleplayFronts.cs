using MacroTools.Extensions;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.BansheesHost;
using WarcraftLegacies.Source.Factions.Dalaran;
using WarcraftLegacies.Source.Factions.Druids;
using WarcraftLegacies.Source.Factions.FallenPrince;
using WarcraftLegacies.Source.Factions.FelHorde;
using WarcraftLegacies.Source.Factions.Forsaken;
using WarcraftLegacies.Source.Factions.Gilneas;
using WarcraftLegacies.Source.Factions.Ironforge;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.Factions.OrcishHorde;
using WarcraftLegacies.Source.Factions.Quelthalas;
using WarcraftLegacies.Source.Factions.ScarletCrusade;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Sentinels;
using WarcraftLegacies.Source.Factions.Stormwind;
using WarcraftLegacies.Source.Factions.Sunfury;
using WarcraftLegacies.Source.Factions.TaurenTribes;
using WarcraftLegacies.Source.Factions.Theramore;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>Who fights whom in Roleplay mode, across the North, South and Kalimdor fronts.</summary>
public static class RoleplayFronts
{
  /// <summary>Registers every front with <see cref="TeamHandicaps"/>.</summary>
  public static void Register()
  {
    TeamHandicaps.AddFront(new Front(AttacksNorth, DefendsNorth));
    TeamHandicaps.AddFront(new Front(AttacksSouth, DefendsSouth));
    TeamHandicaps.AddFront(new Front(AttacksKalimdor, DefendsKalimdor));
    TeamHandicaps.AddFront(new Front(IsForsaken, ServesTheLichKing));
    TeamHandicaps.AddFront(new Front(IsChaosOrcs, IsTauren));
    TeamHandicaps.AddFront(new Front(x => x is LegionFaction, IsInHyjalPact));
  }

  private static bool AttacksNorth(Faction faction) =>
    faction is ScourgeFaction || faction is LegionFaction || faction is FallenPrinceFaction || faction is BansheesHostFaction ||
    (faction is ForsakenFaction && !IsOnTeam(faction, TeamSetup.Horde));

  private static bool DefendsNorth(Faction faction) =>
    faction is LordaeronFaction || faction is DalaranFaction || faction is QuelthalasFaction ||
    (faction is SunfuryFaction && !IsOnTeam(faction, TeamSetup.Legion)) ||
    faction is ScarletCrusadeFaction ||
    (faction is GilneasFaction && IsOnTeam(faction, TeamSetup.NorthAlliance)) ||
    (faction is TheramoreFaction && !IsOnKalimdorTeam(faction));

  private static bool IsForsaken(Faction faction) => faction is ForsakenFaction && IsOnTeam(faction, TeamSetup.Horde);

  private static bool IsChaosOrcs(Faction faction) => faction is ChaosOrcsFaction;

  private static bool IsTauren(Faction faction) => faction is TaurenTribesFaction;

  private static bool IsInHyjalPact(Faction faction)
  {
    var pact = RoleplaySetting.HyjalPact;
    return pact != null && pact.PactTeam != null && IsOnTeam(faction, pact.PactTeam);
  }

  private static bool ServesTheLichKing(Faction faction) =>
    faction is ScourgeFaction || faction is FallenPrinceFaction || faction is BansheesHostFaction;

  private static bool AttacksSouth(Faction faction) =>
    faction is FelHordeFaction || faction is LegionFaction || (faction is SunfuryFaction && IsOnTeam(faction, TeamSetup.Legion)) ||
    (faction is DarkIronFaction && IsOnTeam(faction, TeamSetup.Legion));

  private static bool DefendsSouth(Faction faction) =>
    faction is StormwindFaction || faction is IronforgeFaction || faction is KultirasFaction || faction is WildhammerFaction ||
    faction is StromgardeFaction;

  private static bool AttacksKalimdor(Faction faction) =>
    faction is OrcishHordeFaction || faction is TaurenTribesFaction || (faction is TheramoreFaction && IsOnTeam(faction, TeamSetup.Horde));

  private static bool DefendsKalimdor(Faction faction) =>
    faction is SentinelsFaction || faction is DruidsFaction || (faction is TheramoreFaction && IsOnTeam(faction, TeamSetup.NightElves)) ||
    (faction is GilneasFaction && IsOnTeam(faction, TeamSetup.NightElves));

  /// <summary>Whether Theramore has joined the Horde or the Night Elves.</summary>
  private static bool IsOnKalimdorTeam(Faction faction) =>
    IsOnTeam(faction, TeamSetup.Horde) || IsOnTeam(faction, TeamSetup.NightElves);

  private static bool IsOnTeam(Faction faction, Team team)
  {
    var factionPlayer = faction.Player;
    return factionPlayer != null && factionPlayer.GetPlayerData().Team == team;
  }
}
