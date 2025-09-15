using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests
{
  /// <summary>
  /// The Tomb of Sargeras starts closed, and can be opened by completing this quest.
  /// </summary>
  public sealed class QuestTombOfSargeras : QuestData
  {
    private readonly Rectangle _entrance;
    private readonly ObjectiveAnyHeroWithLevelReachRect _enterTombOfSargerasRegion;
    private IEnumerable<trigger>? _preventAccessTriggers;
    private readonly List<unit> _rescueUnits = new();
    private readonly unit _entranceDoor;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestTombOfSargeras"/> class.
    /// </summary>
    /// <param name="interiorRects">All of the <see cref="Rectangle"/>s that makes up the Tomb's interior.</param>
    /// <param name="entrance">The area just outside of the gate.</param>
    /// <param name="entranceDoor">The gate blocking the way in.</param>
    /// <param name="guldanRemains">Gul'dan's corpse within the Tomb.</param>
    public QuestTombOfSargeras(IReadOnlyCollection<Rectangle> interiorRects, Rectangle entrance, unit entranceDoor,
      unit guldanRemains) : base("Tomb of Sargeras",
      "When the Guardian Aegwynn defeated the fallen Titan Sargeras, she sealed his corpse within the temple that would come to be known as the Tomb of Sargeras. It lies still there, tempting those with the ambition to seize the power that remains within.",
      @"ReplaceableTextures\CommandButtons\BTNEyeOfSargeras.blp")
    {
      CreateRegion();
      _entrance = entrance;
      SetUnitAnimation(guldanRemains, "death");
      SetUnitInvulnerable(guldanRemains, true);
      AddObjective(new ObjectiveTime(900));
      _enterTombOfSargerasRegion =
        new ObjectiveAnyHeroWithLevelReachRect(10, Regions.Sargeras_Entrance, "the Tomb of Sargeras' entrance");
      AddObjective(_enterTombOfSargerasRegion);
      _preventAccessTriggers = CreatePreventAccessTriggers(interiorRects);
      HideUnitsInsideTomb(interiorRects);
      SetUnitInvulnerable(entranceDoor, true);
      _entranceDoor = entranceDoor;
      IsFactionQuest = false;
    }

    /// <inheritdoc />
    protected override string RewardDescription => "The Tomb of Sargeras opens";

    /// <inheritdoc />
    public override string RewardFlavour =>
      $"The Tomb of Sargeras has been opened by {_enterTombOfSargerasRegion.CompletingUnitName}.";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
      _rescueUnits.Clear();
      if (_preventAccessTriggers != null)
        foreach (var preventAccessTrigger in _preventAccessTriggers)
          DestroyTrigger(preventAccessTrigger);

      _preventAccessTriggers = null;
      SetUnitInvulnerable(_entranceDoor, false);
      _entranceDoor
        .TakeDamage(_enterTombOfSargerasRegion.CompletingUnit, 10000);
    }

    private void HideUnitsInsideTomb(IEnumerable<Rectangle> rectangles)
    {
      foreach (var rect in rectangles)
      foreach (var unit in GlobalGroup.EnumUnitsInRect(rect.Rect).Where(x => !BlzIsUnitInvulnerable(x)))
      {
        _rescueUnits.Add(unit);
        SetUnitInvulnerable(unit, true);
        ShowUnit(unit, false);
      }
    }

    private IEnumerable<trigger> CreatePreventAccessTriggers(IEnumerable<Rectangle> rectangles)
    {
      List<trigger> triggers = new();
      foreach (var rect in rectangles)
      {
        var enterTrigger = CreateTrigger();
        TriggerRegisterEnterRegion(enterTrigger, rect.Region, null);
        TriggerAddAction(enterTrigger, () => GetEnteringUnit().SetPosition(_entrance.Center));
        triggers.Add(enterTrigger);
      }

      return triggers;
    }
  }
}