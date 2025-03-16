﻿using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using MacroTools.Systems;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Stormwind
{
  public sealed class QuestClosePortal : QuestData
  {
    private readonly List<unit> _unitsToRemove;
    private readonly LegendaryHero _khadgar;

    public QuestClosePortal(PreplacedUnitSystem preplacedUnitSystem, LegendaryHero khadgar) : base("Seal the Dark Portal",
      "The Dark Portal has been a menace to the Kingdom of Stormwind for decades, it is time to end the menace once and for all.",
      @"ReplaceableTextures\CommandButtons\BTNDarkPortal.blp")
    {
      _khadgar = khadgar;
      AddObjective(new ObjectiveChannelRect(Regions.ClosePortal, "the Dark Portal", khadgar, 480, 270, Title));
      Global = true;
      _unitsToRemove = new List<unit>
      {
        //Outside the portal
        preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, new Point(15579, -19546)),
        preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, new Point(16549, -19145)),
        preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, new Point(17447, -19214)),
        //Inside the portal
        preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, new Point(4576, -24718)),
        preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, new Point(4701, -25361)),
        preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, new Point(5212, -25743)),
        //Control Nexi
        preplacedUnitSystem.GetUnit(UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, new Point(17420, -17900)),
        preplacedUnitSystem.GetUnit(UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, new Point(3703, -26045))
      };
    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "Khadgar has sealed the Dark Portal forever, finally correcting the mistake made by his former master decades ago.";

    /// <inheritdoc/>
    protected override string RewardDescription => "The Dark Portal closes permanently";

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      _unitsToRemove.Clear();
    }
    
    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _unitsToRemove)
      {
        RemoveUnit(unit);
      }
      _unitsToRemove.Clear();
      _khadgar.Unit?.AddExperience(10000);
    }
  }
}