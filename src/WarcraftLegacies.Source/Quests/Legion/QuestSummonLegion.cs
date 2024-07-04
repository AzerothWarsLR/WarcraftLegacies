using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestSummonLegion : QuestData
  {
    private const int RitualId = ABILITY_A00J_SUMMON_THE_BURNING_LEGION_ALL_FACTIONS;
    private readonly List<unit> _rescueUnits;
    private readonly unit _interiorPortal;
    private readonly ObjectiveCastSpell _objectiveCastSpell;

    public QuestSummonLegion(Rectangle rescueRect, unit interiorPortal) : base("Under the Burning Sky",
      "The greater forces of the Burning Legion lie in wait in the vast expanse of the Twisting Nether. Use the Book of Medivh to tear open a hole in space-time, and visit the full might of the Legion upon Azeroth.",
      @"ReplaceableTextures\CommandButtons\BTNArchimonde.blp")
    {
      _interiorPortal = interiorPortal;
      _objectiveCastSpell = new ObjectiveCastSpell(RitualId, false);
      AddObjective(_objectiveCastSpell);
      ResearchId = UPGRADE_R04B_QUEST_COMPLETED_UNDER_THE_BURNING_SKY;
      Global = true;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    }

    /// <inheritdoc />
    public override string RewardFlavour => 
      $"A great portal to the depths of the Twisting Nether has been opened by {_objectiveCastSpell.Caster?.GetProperName()}. The Burning Legion steps forth, heralding the beginning of the end.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      $"The hero Archimonde, control of all units in the Twisting Nether, learn to train Greater Demons, and can now build 9 more {GetObjectName(UNIT_N04Q_NETHER_PIT_LEGION_BARRACKS)} and {GetObjectName(UNIT_U006_SUMMONING_CIRCLE_LEGION_MAGIC)}";

    /// <inheritdoc />
    protected override void OnComplete(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(UNIT_U006_SUMMONING_CIRCLE_LEGION_MAGIC, 9);
      whichFaction.ModObjectLimit(UNIT_N04Q_NETHER_PIT_LEGION_BARRACKS, 9);
      whichFaction.ModObjectLimit(UNIT_NINF_INFERNAL_LEGION, 6);
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        SetPlayerAbilityAvailable(player, ABILITY_A00J_SUMMON_THE_BURNING_LEGION_ALL_FACTIONS, false);

      whichFaction.Player.RescueGroup(_rescueUnits);
      _rescueUnits.Clear();

      CreatePortals(whichFaction.Player);

      CreateTimer().Start(6, false, () =>
      {
        PlayThematicMusic("Doom");
        GetExpiredTimer().Destroy();
      });

      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        SetPlayerAbilityAvailable(player, RitualId, false);
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      if (whichFaction.UndefeatedResearch == 0)
        throw new Exception($"{whichFaction.Name} has no presence research. QuestSummonLegion won't work.");
    }
    
    private void CreatePortals(player? whichPlayer)
    {
      var exteriorPortalPosition = _objectiveCastSpell.Caster != null
        ? _objectiveCastSpell.Caster!.GetPosition()
        : new Point(0, 0);
      SetUnitOwner(_interiorPortal, Player(PLAYER_NEUTRAL_AGGRESSIVE), true);
      var exteriorPortal = CreateUnit(whichPlayer ?? Player(PLAYER_NEUTRAL_AGGRESSIVE),
        UNIT_N037_DEMON_PORTAL, exteriorPortalPosition.X, exteriorPortalPosition.Y, 0);
      exteriorPortal.SetWaygateDestination(_interiorPortal.GetPosition());
      _interiorPortal.SetWaygateDestination(exteriorPortal.GetPosition());
    }
  }
}