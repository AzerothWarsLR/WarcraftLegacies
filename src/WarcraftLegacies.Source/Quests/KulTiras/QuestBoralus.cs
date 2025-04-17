﻿using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.LegendSystem;
using MacroTools.Powers;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Blizzard;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  /// <summary>
  /// Tier 4 must be researched to unlock all units in the Boralus area.
  /// </summary>
  public sealed class QuestBoralus : QuestData
  {
    private readonly List<unit> _rescueUnits;
    private const string RewardPowerName = "City of Admirals";
    private readonly LegendaryHero _katherine;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestBoralus"/> class.
    /// </summary>
    /// <param name="rescueRect">All units in this area will be made neutral, then rescued when the quest is completed or made aggressive when the quest is failed.</param>
    /// <param name="katherine">The Legendary Hero, Katherine Proudmoore, associated with this quest.</param>
    public QuestBoralus(Rectangle rescueRect, LegendaryHero katherine) : base("The Admiralty of Kul Tiras",
      "Kul Tiras has degenerated severely in contemporary times. Bandits and vile monsters threaten the islands and the noble houses have split apart. We must quell these threats and reunite the kingdom's various regions under Daelin Proudmoore's command.",
      @"ReplaceableTextures\CommandButtons\BTNHumanShipyard.blp")
    {
      _katherine = katherine;
      AddObjective(new ObjectiveUpgrade(UNIT_H06I_CASTLE_KUL_TIRAS_T3, UNIT_H062_TOWN_HALL_KUL_TIRAS_T1));
      AddObjective(new ObjectiveControlPoint(UNIT_N0BX_TIRAGARDE_SOUND));
      AddObjective(new ObjectiveControlPoint(UNIT_N0BW_STORMSONG_VALLEY, 1000));
      AddObjective(new ObjectiveControlPoint(UNIT_N0BV_DRUSTVAR));
      AddObjective(new ObjectiveExpire(480, Title));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = UPGRADE_R00L_QUEST_COMPLETED_THE_ADMIRALTY_OF_KUL_TIRAS_KUL_TIRAS;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "Kul'tiras has joined the war and its military is now free to assist the Alliance.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Gain control of all units in Kul'tiras,gain control of Katherine Proudmoore, and acquire the {RewardPowerName} Power";

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      // Grant the custom Power
      var rewardPower = new CityOfHeroes(0.125f, 1.5f, "Ships")
      {
        IconName = "LordAdmiralPendant",
        Name = RewardPowerName,
        HeroGlowAbilityTypeId = ABILITY_A0GK_HERO_GLOW_ORIGIN,
        Filter = unit =>
        {
          var x = GetUnitX(unit);
          var y = GetUnitY(unit);
          return unit.IsType(UNIT_TYPE_MECHANICAL) && !IsTerrainPathable(x, y, PATHING_TYPE_FLOATABILITY) &&
                 IsTerrainPathable(x, y, PATHING_TYPE_WALKABILITY);
        }
      };
      
      completingFaction.AddPower(rewardPower);
      completingFaction.Player?.DisplayPowerAcquired(rewardPower);

      // Rescue units connected to the quest
      if (completingFaction.Player != null)
        completingFaction.Player
          .RescueGroup(_rescueUnits)
          .PlayMusicThematic("war3mapImported\\KultirasTheme.mp3");
      else
        Player(bj_PLAYER_NEUTRAL_VICTIM).RescueGroup(_rescueUnits);
      
      if (_katherine.Unit == null)
      {
        _katherine.ForceCreate(completingFaction.Player, Regions.KatherineSpawn.Center, 90);
        _katherine.Unit?.SetLevel(3, false); // Set level to 3 (adjust if needed)
        // Add visual effects for Katherine's spawn
        DestroyEffect(AddSpecialEffect("war3mapImported\\Soul Beam Blue.mdx",
          GetUnitX(_katherine.Unit), GetUnitY(_katherine.Unit)));
        DestroyEffect(AddSpecialEffect(@"abilities\spells\human\holybolt.mdl",
          GetUnitX(_katherine.Unit), GetUnitY(_katherine.Unit)));
      }
    }
  }
}