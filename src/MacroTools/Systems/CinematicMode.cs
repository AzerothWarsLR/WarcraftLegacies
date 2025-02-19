﻿using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Utils;
using WCSharp.Shared;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Systems
{
  /// <summary>
  /// Used to engage cinematic mode, which prevents players from taking actions and manipulates sound
  /// and weather effects for a cinematic experience.
  /// </summary>
  public static class CinematicMode
  {
    private static timer? _cinematicTimer;
    private static timer? _musicTimer;
    private static CinematicState _state = CinematicState.Inactive;
    private static List<unit>? _pausedUnits = new();

    public static CinematicState State => _state;
    
    /// <summary>
    /// Initiates cinematic mode.
    /// </summary>
    /// <param name="duration">How long cinematic mode should last.</param>
    public static void Setup(float duration)
    {
      _cinematicTimer = CreateTimer();
      TimerStart(_cinematicTimer, duration, false, TimerEnd);

      _musicTimer = CreateTimer();
      TimerStart(_musicTimer, 2.1f, false, PlayFactionMusic);

      FogEnable(false);
      FogMaskEnable(false);

      _pausedUnits = GlobalGroup
        .EnumUnitsInRect(Rectangle.WorldBounds);
      
      foreach (var unit in _pausedUnits)
        unit.PauseEx(true);

      _state = CinematicState.Active;
    }

    /// <summary>
    /// Ends cinematic mode early for all players.
    /// </summary>
    public static void EndEarly()
    {
      DestroyTimer(_cinematicTimer);
      TimerEnd();
    }

    /// <summary>
    /// Adds an existing unit to the list of paused units. Useful if a unit is added to the game during the initial
    /// cinematic window.
    /// </summary>
    public static void AddPausedUnit(unit whichUnit)
    {
      if (_state != CinematicState.Active)
        return;

      _pausedUnits?.Add(whichUnit);
      whichUnit.PauseEx(true);
    }
    
    private static void TimerEnd()
    {
      if (_state != CinematicState.Active)
        return;

      FogEnable(true);

      SetMapMusic("music", true, 0);

      VolumeGroupReset();
      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_AMBIENTSOUNDS, 0.4f);

      DestroyTimer(_cinematicTimer);
      DestroyTimer(_musicTimer);
      _state = CinematicState.Finished;

      if (_pausedUnits != null)
      {
        foreach (var unit in _pausedUnits)
          unit.PauseEx(false);
        _pausedUnits.Clear();
      }
    }

    private static void PlayFactionMusic()
    {
      foreach (var player in Util.EnumeratePlayers())
        player.PlayMusicThematic(player.GetFaction().CinematicMusic);
    }
  }
  
  public enum CinematicState
  {
    Inactive,
    Active,
    Finished
  }
}