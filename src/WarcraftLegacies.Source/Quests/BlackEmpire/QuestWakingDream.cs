﻿using System.Collections.Generic;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.BlackEmpire
{
  public sealed class QuestWakingDream : QuestData
  {

    public QuestWakingDream(LegendaryHero Xkorr, PreplacedUnitSystem preplacedUnitSystem) : base("Waking Dream",
      "Countless ages ago, Warlord Zon'ozz was one of my strongest generals. Unfortunately, he is currently trapped in the past. To summon him, I need to capture the Caverns of Time and call him to serve me in the present once again.",
      @"ReplaceableTextures\CommandButtons\BTNDarkPortal.blp")
    {
      AddObjective(new ObjectiveKillUnit(preplacedUnitSystem.GetUnit(UNIT_O070_OCCULUS_CREEP_CAVERNS)));
      AddObjective(new ObjectiveChannelRect(Regions.CavernofTime, "the Caverns of Time", Xkorr, 180, 315, Title));
      ResearchId = UPGRADE_RBWD_QUEST_COMPLETED_WAKING_DREAM;

    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "Zon'ozz has joined my ranks once more.";

    /// <inheritdoc/>
    protected override string RewardDescription => $"Learn to train Warlord Zon'ozz from the {GetObjectName(UNIT_N0AV_ALTAR_OF_MADNESS_YOGG_ALTAR)}";

   
  }
}