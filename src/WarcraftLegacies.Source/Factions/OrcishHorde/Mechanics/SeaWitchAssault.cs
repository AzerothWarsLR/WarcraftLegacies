using System.Collections.Generic;
using System.Linq;
using MacroTools.Dialogues;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using WCSharp.Events;
using WarcraftLegacies.Source.Factions.OrcishHorde.Quests;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Mechanics;

/// <summary>
/// Spawns four waves of murlocs against the Orcish Horde's landing island, with an independent Sea Witch
/// that can be killed for an early win or try to flee once at low health. Clearing the fourth wave, or
/// killing the Sea Witch, completes <see cref="QuestCountdownToExtinction"/>. Stops if the Great Hall dies.
/// </summary>
public sealed class SeaWitchAssault
{
  private const int TotalWaves = 4;
  private const float FirstWaveDelaySeconds = 75f;
  private const float TickInterval = 2f;
  private const float NextWaveDelaySeconds = 5f;
  private const float SpawnFacing = 0f;
  private const float SeaWitchTeleportHealthPercent = 33f;
  private const float SeaWitchTeleportCastSeconds = 5f;
  private const float SeaWitchSpawnDelayMinSeconds = 5f;
  private const float SeaWitchSpawnDelayMaxSeconds = 15f;
  private const string SeaWitchTeleportEffectPath = @"Abilities\Spells\Human\MassTeleport\MassTeleportCaster.mdl";
  private const string SeaWitchTeleportEffectAttachPoint = "origin";

  private static readonly Dialogue SeaWitchAppearsDialogue = new(
    @"Sound\Dialogue\TutorialCampaign\Demo05\D05SeaWitch16.flac",
    "Your efforts are futile, land dwellers. The darkness of the deeps is all that awaits you.",
    "Sea Witch");

  private static readonly Dialogue SeaWitchWave3Dialogue = new(
    @"Sound\Dialogue\TutorialCampaign\Demo05\D05SeaWitch18.flac",
    "Soon this land will be consumed by the tides! Prepare for the sea's cold embrace.",
    "Sea Witch");

  private static readonly Dialogue SeaWitchWave4Dialogue = new(
    @"Sound\Dialogue\TutorialCampaign\Demo05\D05SeaWitch20.flac",
    "Yes! At last, the end draws near. Your deaths are only the beginning - soon all land dwellers will be entombed in a watery grave.",
    "Sea Witch");

  private static readonly Dialogue SeaWitchEscapesDialogue = new(
    @"Sound\Dialogue\TutorialCampaign\Demo04\D04SeaWitch39.flac",
    "Make peace with your gods, land lovers. You cannot escape the currents of death so easily.",
    "Sea Witch");

  private static readonly Dialogue RepairsWave2Dialogue = new(
    @"Sound\Dialogue\TutorialCampaign\Demo05\D05Grunt17.flac",
    "We still need more time to finish the repairs, warchief.",
    "Grunt");

  private static readonly Dialogue RepairsWave3Dialogue = new(
    @"Sound\Dialogue\TutorialCampaign\Demo05\D05Grunt19.flac",
    "It won't be much longer now, warchief - the ships are nearly ready.",
    "Grunt");

  private static readonly Dialogue RepairsWave4Dialogue = new(
    @"Sound\Dialogue\TutorialCampaign\Demo05\D05Thrall21.flac",
    "Hold the line, my warriors! Our freedom is at hand!",
    "Thrall");

  private readonly Faction _orcishHorde;
  private readonly QuestCountdownToExtinction _quest;
  private readonly unit _greatHall;
  private readonly Point _attackTarget;
  private readonly Rectangle[] _spawnRegions;
  private readonly List<unit> _activeWaveUnits = new();
  private readonly HashSet<unit> _greatHallTargeters = new();

  private int _currentWave;
  private int _waveUnitCounter;
  private bool _concluded;
  private unit? _seaWitch;
  private bool _seaWitchCasting;
  private bool _seaWitchTeleportAttempted;
  private effect? _teleportEffect;
  private trigger? _teleportEndCastTrigger;
  private timer? _waveTimer;
  private timer? _waveDialogTimer;
  private timerdialog? _waveDialog;
  private timer? _waveClearCheckTimer;
  private timer? _seaWitchCheckTimer;
  private timer? _seaWitchSpawnTimer;
  private timer? _teleportTimer;

  /// <summary>
  /// Initializes a new instance of the <see cref="SeaWitchAssault"/> class and schedules the first wave.
  /// </summary>
  /// <param name="orcishHorde">The faction this assault is fighting. Used only to queue dialogue.</param>
  /// <param name="quest">The quest this assault is completing.</param>
  /// <param name="greatHall">The starting Great Hall. Its death stops the assault.</param>
  /// <param name="darkspearIsles">The landing island. Waves attack-move toward its center.</param>
  /// <param name="seaWitchSpawn1">One of wave 1's, wave 4's, and the Sea Witch's possible spawns.</param>
  /// <param name="seaWitchSpawn2">One of wave 2's, wave 4's, and the Sea Witch's possible spawns.</param>
  /// <param name="seaWitchSpawn3">One of wave 3's, wave 4's, and the Sea Witch's possible spawns.</param>
  public SeaWitchAssault(Faction orcishHorde, QuestCountdownToExtinction quest, unit greatHall,
    Rectangle darkspearIsles, Rectangle seaWitchSpawn1, Rectangle seaWitchSpawn2, Rectangle seaWitchSpawn3)
  {
    _orcishHorde = orcishHorde;
    _quest = quest;
    _greatHall = greatHall;
    _attackTarget = darkspearIsles.Center;
    _spawnRegions = new[] { seaWitchSpawn1, seaWitchSpawn2, seaWitchSpawn3 };

    PlayerUnitEvents.Register(UnitEvent.Dies, StopAssault, greatHall);

    GameTimeManager.RegisterOnTurn(1, () =>
    {
      if (_concluded)
      {
        return;
      }

      _seaWitchCheckTimer = timer.Create();
      _seaWitchCheckTimer.Start(TickInterval, true, CheckSeaWitchTeleport);

      _waveTimer = timer.Create();
      _waveTimer.Start(FirstWaveDelaySeconds, false, () =>
      {
        _waveTimer?.Dispose();
        _waveTimer = null;
        SpawnWave(1);
      });
    });
  }

  private void SpawnWave(int waveNumber)
  {
    if (_concluded)
    {
      return;
    }

    _currentWave = waveNumber;
    _activeWaveUnits.Clear();
    _greatHallTargeters.Clear();
    _waveUnitCounter = 0;
    UpdateWaveDialog(waveNumber);

    switch (waveNumber)
    {
      case 1:
        SpawnGroup(_spawnRegions[0], UNIT_O07B_MURLOC_TIDERUNNER_DARKSPEAR_ISLES, 3);
        SpawnGroup(_spawnRegions[0], UNIT_O07C_MURLOC_HUNTSMAN_DARKSPEAR_ISLES, 2);
        break;
      case 2:
        SpawnGroup(_spawnRegions[1], UNIT_O07B_MURLOC_TIDERUNNER_DARKSPEAR_ISLES, 5);
        SpawnGroup(_spawnRegions[1], UNIT_O07C_MURLOC_HUNTSMAN_DARKSPEAR_ISLES, 3);
        SpawnGroup(_spawnRegions[1], UNIT_O07D_MURLOC_NIGHTCRAWLER_DARKSPEAR_ISLES, 1);
        _orcishHorde.Player?.QueueDialogue(RepairsWave2Dialogue);
        break;
      case 3:
        SpawnGroup(_spawnRegions[2], UNIT_O07B_MURLOC_TIDERUNNER_DARKSPEAR_ISLES, 4);
        SpawnGroup(_spawnRegions[2], UNIT_O07C_MURLOC_HUNTSMAN_DARKSPEAR_ISLES, 2);
        SpawnGroup(_spawnRegions[2], UNIT_O07D_MURLOC_NIGHTCRAWLER_DARKSPEAR_ISLES, 2);
        _orcishHorde.Player?.QueueDialogue(RepairsWave3Dialogue);
        break;
      case 4:
        foreach (var spawnRegion in _spawnRegions)
        {
          SpawnGroup(spawnRegion, UNIT_O07B_MURLOC_TIDERUNNER_DARKSPEAR_ISLES, 3);
          SpawnGroup(spawnRegion, UNIT_O07C_MURLOC_HUNTSMAN_DARKSPEAR_ISLES, 1);
          SpawnGroup(spawnRegion, UNIT_O07D_MURLOC_NIGHTCRAWLER_DARKSPEAR_ISLES, 1);
        }

        SpawnGroup(_spawnRegions[2], UNIT_N00R_MURLOC_SORCERER_NEUTRAL_HOSTILE_BOSS, 1);
        _orcishHorde.Player?.QueueDialogue(RepairsWave4Dialogue);
        break;
    }

    var seaWitchSpawnDelay = GetRandomReal(SeaWitchSpawnDelayMinSeconds, SeaWitchSpawnDelayMaxSeconds);
    _seaWitchSpawnTimer?.Dispose();
    _seaWitchSpawnTimer = timer.Create();
    _seaWitchSpawnTimer.Start(seaWitchSpawnDelay, false, () =>
    {
      _seaWitchSpawnTimer?.Dispose();
      _seaWitchSpawnTimer = null;
      if (!_concluded)
      {
        SpawnSeaWitch();
      }
    });

    _waveClearCheckTimer ??= timer.Create();
    _waveClearCheckTimer.Start(TickInterval, true, CheckWaveCleared);
  }

  private void UpdateWaveDialog(int waveNumber)
  {
    var orcPlayer = _orcishHorde.Player;
    if (orcPlayer == null)
    {
      return;
    }

    if (_waveDialog == null)
    {
      _waveDialogTimer = timer.Create();
      _waveDialog = timerdialog.Create(_waveDialogTimer);
      TimerDialogSetTimeColor(_waveDialog, 0, 0, 0, 0);
      if (player.LocalPlayer == orcPlayer)
      {
        _waveDialog.IsDisplayed = true;
      }
    }

    _waveDialog.SetTitle($"Wave {waveNumber}/{TotalWaves}");
  }

  private void SpawnGroup(Rectangle spawnRegion, int unitTypeId, int count)
  {
    for (var i = 0; i < count; i++)
    {
      var spawnPoint = spawnRegion.GetRandomPoint();
      var spawned = unit.Create(player.NeutralAggressive, unitTypeId, spawnPoint.X, spawnPoint.Y, SpawnFacing);

      if (_waveUnitCounter % 3 == 0)
      {
        _greatHallTargeters.Add(spawned);
        spawned.IssueOrder(ORDER_ATTACK, _greatHall);
      }
      else
      {
        spawned.IssueOrder(ORDER_ATTACK, _attackTarget.X, _attackTarget.Y);
      }

      _waveUnitCounter++;
      _activeWaveUnits.Add(spawned);
    }
  }

  private void SpawnSeaWitch()
  {
    if (_seaWitch != null && _seaWitch.Alive)
    {
      return;
    }

    var spawnRegion = _spawnRegions[GetRandomInt(0, _spawnRegions.Length - 1)];
    var spawnPoint = spawnRegion.GetRandomPoint();
    var seaWitch = unit.Create(player.NeutralAggressive, UNIT_O079_SEA_WITCH_DARKSPEAR_ISLES, spawnPoint.X,
      spawnPoint.Y, SpawnFacing);
    seaWitch.IssueOrder(ORDER_ATTACK, _attackTarget.X, _attackTarget.Y);

    _seaWitch = seaWitch;
    _seaWitchCasting = false;
    _seaWitchTeleportAttempted = false;
    PlayerUnitEvents.Register(UnitEvent.Dies, OnSeaWitchKilled, seaWitch);

    var spawnDialogue = _currentWave switch
    {
      1 => SeaWitchAppearsDialogue,
      3 => SeaWitchWave3Dialogue,
      4 => SeaWitchWave4Dialogue,
      _ => null
    };
    if (spawnDialogue != null)
    {
      _orcishHorde.Player?.QueueDialogue(spawnDialogue);
    }
  }

  private void CheckSeaWitchTeleport()
  {
    if (_concluded)
    {
      return;
    }

    if (_seaWitch != null && _seaWitch.Alive && !_seaWitchCasting)
    {
      _seaWitch.IssueOrder(ORDER_ATTACK, _attackTarget.X, _attackTarget.Y);
    }

    if (_seaWitchCasting || _seaWitchTeleportAttempted || _seaWitch == null || !_seaWitch.Alive)
    {
      return;
    }

    var seaWitch = _seaWitch;
    var lifePercent = seaWitch.GetLifePercent();
    if (lifePercent > SeaWitchTeleportHealthPercent)
    {
      return;
    }

    _seaWitchCasting = true;
    seaWitch.IssueOrder(ORDER_CHANNEL);
    PauseUnit(seaWitch, true);

    _teleportEffect?.Dispose();
    _teleportEffect = effect.Create(SeaWitchTeleportEffectPath, seaWitch, SeaWitchTeleportEffectAttachPoint);

    _teleportEndCastTrigger?.Dispose();
    _teleportEndCastTrigger = trigger.Create();
    _teleportEndCastTrigger.RegisterUnitEvent(seaWitch, unitevent.SpellEndCast);
    _teleportEndCastTrigger.AddAction(() => OnSeaWitchTeleportInterrupted(seaWitch));

    _teleportTimer?.Dispose();
    _teleportTimer = timer.Create();
    _teleportTimer.Start(SeaWitchTeleportCastSeconds, false, () => OnSeaWitchTeleportFinished(seaWitch));
  }

  private void OnSeaWitchTeleportFinished(unit seaWitch)
  {
    if (!_seaWitchCasting)
    {
      return;
    }

    CleanupTeleportTracking();

    _seaWitchCasting = false;
    _orcishHorde.Player?.QueueDialogue(SeaWitchEscapesDialogue);
    seaWitch.Dispose();
  }

  private void OnSeaWitchTeleportInterrupted(unit seaWitch)
  {
    if (!_seaWitchCasting)
    {
      return;
    }

    CleanupTeleportTracking();

    _seaWitchCasting = false;
    _seaWitchTeleportAttempted = true;

    if (!seaWitch.Alive)
    {
      return;
    }

    PauseUnit(seaWitch, false);
    seaWitch.IssueOrder(ORDER_ATTACK, _attackTarget.X, _attackTarget.Y);
  }

  private void CleanupTeleportTracking()
  {
    _teleportTimer?.Dispose();
    _teleportTimer = null;
    _teleportEndCastTrigger?.Dispose();
    _teleportEndCastTrigger = null;
    _teleportEffect?.Dispose();
    _teleportEffect = null;
  }

  private void OnSeaWitchKilled()
  {
    Conclude();
  }

  private void CheckWaveCleared()
  {
    foreach (var waveUnit in _activeWaveUnits)
    {
      if (!waveUnit.Alive)
      {
        continue;
      }

      if (_greatHallTargeters.Contains(waveUnit))
      {
        waveUnit.IssueOrder(ORDER_ATTACK, _greatHall);
      }
      else
      {
        waveUnit.IssueOrder(ORDER_ATTACK, _attackTarget.X, _attackTarget.Y);
      }
    }

    if (_activeWaveUnits.Any(waveUnit => waveUnit.Alive))
    {
      return;
    }

    _waveClearCheckTimer?.Dispose();
    _waveClearCheckTimer = null;

    if (_currentWave >= 4)
    {
      Conclude();
      return;
    }

    var nextWave = _currentWave + 1;
    _waveTimer = timer.Create();
    _waveTimer.Start(NextWaveDelaySeconds, false, () =>
    {
      _waveTimer?.Dispose();
      _waveTimer = null;
      SpawnWave(nextWave);
    });
  }

  private void Conclude()
  {
    if (_concluded)
    {
      return;
    }

    StopAssault();
    _quest.SurviveAssault.MarkSurvived();
  }

  private void StopAssault()
  {
    if (_concluded)
    {
      return;
    }

    _concluded = true;
    _waveTimer?.Dispose();
    _waveTimer = null;
    _waveClearCheckTimer?.Dispose();
    _waveClearCheckTimer = null;
    _seaWitchCheckTimer?.Dispose();
    _seaWitchCheckTimer = null;
    _seaWitchSpawnTimer?.Dispose();
    _seaWitchSpawnTimer = null;
    _waveDialog?.Dispose();
    _waveDialog = null;
    _waveDialogTimer?.Dispose();
    _waveDialogTimer = null;
    CleanupTeleportTracking();
  }
}
