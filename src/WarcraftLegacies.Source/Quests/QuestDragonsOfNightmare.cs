using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests
{
  /// <summary>
  /// Spawns 2 dragons in different locations. Activates portals connecting the two locations after the dragons have been killed.
  /// </summary>
  public class QuestDragonsOfNightmare : QuestData
  {
    private readonly unit _nightmareDragonKalimdor;
    private readonly unit _nightmareDragonEk;
    private readonly string _portalOneLocation;
    private readonly string _portalTwoLocation;

    private readonly unit _innerWaygate;
    private readonly unit _outerWaygate;

    private timer _timer;


    /// <summary>
    /// Initilaizes the quest <see cref="QuestDragonsOfNightmare"/>
    /// </summary>
    /// <param name="nightmareDragonKalimdor">The unit that has to be killed to complete the objective</param>
    /// <param name="nightmareDragonEk">The unit that has to be killed to complete the objective</param>
    /// <param name="portalOneLocation">The name of the first portal's location</param>
    /// <param name="portalTwoLocation">The name of the second portal's location</param>
    /// <param name="preplacedUnitSystem">A system for finding preplaced units</param>
    public QuestDragonsOfNightmare(unit nightmareDragonKalimdor, unit nightmareDragonEk, string portalOneLocation, string portalTwoLocation, PreplacedUnitSystem preplacedUnitSystem) : base("Dragons of Nightmare",
      "Ragnaros hides within the Elemental Plane known as the Firelands. Outside Shadowforge City, the Dark Iron dwarves have been trying to summon him forth into Azeroth. Their efforts until now have proved ineffective, but we could succeed where they have not.",
      @"ReplaceableTextures\CommandButtons\BTNHeroAvatarOfFlame.blp")
    {
      _nightmareDragonKalimdor = nightmareDragonKalimdor.Show(false);
      _nightmareDragonEk = nightmareDragonEk.Show(false);
      _portalOneLocation = portalOneLocation;
      _portalTwoLocation = portalTwoLocation;
      AddObjective(new ObjectiveKillUnit(nightmareDragonKalimdor));
      AddObjective(new ObjectiveKillUnit(nightmareDragonEk));
      AddObjective(new ObjectiveTime(2700));
      _timer = CreateTimer().Start(2700, false, OnTimeElapsed);

    }

    private void OnTimeElapsed()
    {
      DestroyTimer(_timer);
      _nightmareDragonEk.Show(true);
      _nightmareDragonKalimdor.Show(true);
    }

    /// <inheritdoc/>
    protected override string RewardDescription => $"A portal between {_portalOneLocation} and {_portalTwoLocation} is now open";

    /// <inheritdoc/>
    protected override string RewardFlavour => $"The Nightmare Dragons {_nightmareDragonKalimdor.GetProperName()} and {_nightmareDragonEk.GetProperName()} have been defeated.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {

    }
  }
}
