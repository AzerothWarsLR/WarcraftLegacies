﻿using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Scourge;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestCunningPlan : QuestData
  {
    private readonly List<unit> _rescueUnits;
    private readonly LegendaryHero _malganis;

    public QuestCunningPlan(Rectangle rescueRect, Faction scourge, LegendaryHero malganis) : base("A Cunning Plan",
      "The Dreadlords have played a subtle hand in preparing Lordaeron for the coming of the Scourge. Once the Plague is unleashed, the Dreadlords will activate their own assets.",
      @"ReplaceableTextures\CommandButtons\BTNHeroDreadlord.blp")
    {
      AddObjective(new ObjectiveFactionQuestComplete(scourge.GetQuestByType<QuestPlague>(), scourge));

      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      _malganis = malganis;

      ResearchId = UPGRADE_R01L_QUEST_COMPLETED_A_CUNNING_PLAN;
    }

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Gain control of a small base in Alterac, learn to generate a portal to Alterac using the Argus Teleporter, and gain a {GetObjectName(UNIT_U005_DREAD_SHRINE_LEGION_SPECIAL)} in each of the following Scourge bases: Deathknell, Stratholme Coast, and Scholomance. Mal'ganis improves his Vampiric Siphon ability.";

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "With the Plague now spreading amongst Lordaeron's populace, the Dreadlords set the second half of their plan in motion: a direct demonic incursion into the Eastern Kingdoms.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
      CreateUnit(completingFaction.Player, UNIT_U005_DREAD_SHRINE_LEGION_SPECIAL, 11138, 12802, 0);
      CreateUnit(completingFaction.Player, UNIT_U005_DREAD_SHRINE_LEGION_SPECIAL, 4860, 9277, 0);
      CreateUnit(completingFaction.Player, UNIT_U005_DREAD_SHRINE_LEGION_SPECIAL, 14725, 7356, 0);
      _malganis.Unit?.SetAbilityLevel(ABILITY_VP02_VAMPIRIC_SIPHON_LEGION_DREADLORDS, 2);
    }
  }
}