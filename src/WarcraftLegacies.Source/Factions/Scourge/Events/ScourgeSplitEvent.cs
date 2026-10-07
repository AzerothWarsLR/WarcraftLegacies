using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Paths;
using MacroTools.Quests;
using MacroTools.WorldEvents;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Shared.Powers;

namespace WarcraftLegacies.Source.Factions.Scourge.Events;

/// <summary>
/// The Lich King breaks free of the Burning Legion. Forced once Archimonde is summoned, or brought on early by either
/// side taking its split path.
/// </summary>
public sealed class ScourgeSplitEvent : WorldEvent
{
  private const float PowerBonus = 0.15f;

  private readonly ScourgeFaction _scourge;
  private readonly LegionFaction _legion;
  private readonly List<FactionPath> _splitPaths = new();

  public ScourgeSplitEvent(ScourgeFaction scourge, LegionFaction legion, QuestData summonArchimonde)
  {
    _scourge = scourge;
    _legion = legion;
    Name = "The Scourge Split";
    IconName = "HeroLich";
    Description = "The Lich King breaks free of the Burning Legion. The Scourge leaves the Legion's team, and both sides are empowered by the betrayal.";
    WarningDuration = 60;

    var archimondeSummoned = new ObjectiveTriggered("The Legion summons Archimonde, or the Scourge or the Legion takes its split path");
    AddRequirement(archimondeSummoned);
    legion.QuestProgressChanged += args =>
    {
      if (args.Quest == summonArchimonde && args.Quest.Progress == QuestProgress.Complete)
      {
        if (Instigator == null)
        {
          Instigator = Loc.Format("{faction} summoning Archimonde", ("{faction}", legion.ColoredName));
        }

        archimondeSummoned.Trigger();
      }
    };
  }

  /// <summary>Registers a path that brings the split on early. It closes once the split has happened.</summary>
  public void AddSplitPath(FactionPath path) => _splitPaths.Add(path);

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
      TeamChanges.MoveSolo(scourgePlayer);
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
