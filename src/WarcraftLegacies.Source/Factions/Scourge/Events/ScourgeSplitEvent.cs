using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Paths;
using MacroTools.Quests;
using MacroTools.WorldEvents;
using WarcraftLegacies.Source.Factions.BansheesHost;
using WarcraftLegacies.Source.Factions.FallenPrince;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Shared.Powers;

namespace WarcraftLegacies.Source.Factions.Scourge.Events;

/// <summary>The Lich King breaks free of the Burning Legion, taking the Scourge's undead allies with it.</summary>
public sealed class ScourgeSplitEvent : WorldEvent
{
  private const float PowerBonus = 0.15f;

  private readonly ScourgeFaction _scourge;
  private readonly LegionFaction _legion;
  private readonly List<FactionPath> _splitPaths = new();
  private readonly ObjectiveTriggered _forced;

  public ScourgeSplitEvent(ScourgeFaction scourge, LegionFaction legion, QuestData summonArchimonde)
  {
    _scourge = scourge;
    _legion = legion;
    Name = "The Scourge Split";
    IconName = "HeroLich";
    Description = "Ner'zhul has bided his time within the Frozen Throne, and now he strikes. The Lich King breaks free of the Burning Legion and takes the Scourge with him, and the hatred between old masters and servants makes both sides stronger.";
    WarningDuration = 60;

    _forced = new ObjectiveTriggered("The Legion summons Archimonde, the Fallen Prince and the Banshee's Host both join the Scourge, or the Scourge or the Legion takes its split path");
    AddRequirement(_forced);
    legion.QuestProgressChanged += args =>
    {
      if (args.Quest == summonArchimonde && args.Quest.Progress == QuestProgress.Complete)
      {
        if (Instigator == null)
        {
          Instigator = Loc.Format("{faction} summoning Archimonde", ("{faction}", legion.ColoredName));
        }

        _forced.Trigger();
      }
    };
    TeamChanges.OnAnyTeamChanged(CheckUndeadGathered);
  }

  /// <summary>Registers a path that brings the split on early. It closes once the split has happened.</summary>
  public void AddSplitPath(FactionPath path) => _splitPaths.Add(path);

  private void CheckUndeadGathered()
  {
    var scourgePlayer = _scourge.Player;
    var legionPlayer = _legion.Player;
    if (_forced.Progress == QuestProgress.Complete || scourgePlayer == null || legionPlayer == null ||
        !TeamChanges.AreTeammates(scourgePlayer, legionPlayer))
    {
      return;
    }

    if (!FactionManager.TryGetFactionByType<FallenPrinceFaction>(out var fallenPrince))
    {
      return;
    }

    if (!FactionManager.TryGetFactionByType<BansheesHostFaction>(out var bansheesHost))
    {
      return;
    }

    var fallenPrincePlayer = fallenPrince.Player;
    var bansheesHostPlayer = bansheesHost.Player;
    if (fallenPrincePlayer == null || bansheesHostPlayer == null ||
        !TeamChanges.AreTeammates(scourgePlayer, fallenPrincePlayer) || !TeamChanges.AreTeammates(scourgePlayer, bansheesHostPlayer))
    {
      return;
    }

    if (Instigator == null)
    {
      Instigator = Loc.Format("{faction} gathering the Fallen Prince and the Banshee's Host", ("{faction}", _scourge.ColoredName));
    }

    _forced.Trigger();
  }

  /// <summary>Undead factions that leave the Legion along with the Scourge.</summary>
  private static List<player> GetUndeadAllies(player scourgePlayer)
  {
    var undeadAllies = new List<player>();
    foreach (var faction in FactionManager.GetAllFactions())
    {
      if ((faction is FallenPrinceFaction || faction is BansheesHostFaction) && faction.Player != null &&
          TeamChanges.AreTeammates(scourgePlayer, faction.Player))
      {
        undeadAllies.Add(faction.Player);
      }
    }

    return undeadAllies;
  }

  /// <inheritdoc />
  protected override void OnHappened()
  {
    foreach (var path in _splitPaths)
    {
      path.Close();
    }

    var scourgePlayer = _scourge.Player;
    var legionPlayer = _legion.Player;
    if (scourgePlayer != null && legionPlayer != null && TeamChanges.AreTeammates(scourgePlayer, legionPlayer))
    {
      var legionTeam = legionPlayer.GetPlayerData().Team;
      var undeadAllies = GetUndeadAllies(scourgePlayer);
      TeamChanges.MoveSolo(scourgePlayer);
      var scourgeTeam = scourgePlayer.GetPlayerData().Team;
      var allyNames = new List<string>();
      foreach (var undeadAlly in undeadAllies)
      {
        TeamChanges.Move(undeadAlly, scourgeTeam);
        allyNames.Add(undeadAlly.GetPlayerData().Faction?.ColoredName ?? undeadAlly.Name);
      }

      Outcome = Loc.Format("{scourge} left the {team} and formed the {newTeam}.", ("{scourge}", _scourge.ColoredName),
        ("{team}", legionTeam?.LocalizedName ?? ""), ("{newTeam}", scourgeTeam?.LocalizedName ?? ""));
      if (allyNames.Count > 0)
      {
        Outcome += " " + Loc.Format("{allies} went with it.", ("{allies}", string.Join(", ", allyNames)));
      }
    }

    _scourge.AddPower(new EmpoweredUnits(x => x.IsUnitType(unittype.Undead) && !x.IsUnitType(unittype.Structure), PowerBonus)
    {
      Name = "Unbound Scourge",
      IconName = "FrostWyrm",
      DescriptionTemplate = "Free of the Legion's chains, your undead units deal {bonus}% more damage and take {reduction}% less damage."
    });

    _legion.AddPower(new EmpoweredUnits(x => !x.IsUnitType(unittype.Structure), PowerBonus)
    {
      Name = "Wrath of the Legion",
      IconName = "DoomGuard",
      DescriptionTemplate = "Enraged by the Scourge's betrayal, your demons deal {bonus}% more damage and take {reduction}% less damage."
    });

    new ScourgeSoloLimits(_scourge).Start();
  }
}
