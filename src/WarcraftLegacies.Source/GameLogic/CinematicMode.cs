using MacroTools.Extensions;
using System;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>
  /// Used to engage cinematic mode, which prevents players from taking actions and manipulates sound
  /// and weather effects for a cinematic experience.
  /// </summary>
  public class CinematicMode : ILinkedTimer
  {
    private timer _cinermaticTimer;
    private timer _musicTimer;
    private CinematicState _state = CinematicState.Inactive;
    private readonly ILinkedTimer _linkedTimer;

    private float Timeout { get; }

    /// <inheritdoc/>
    public EventHandler? OnTimerEnds { get; set; }


    /// <summary>
    /// Initiates cinematic mode.
    /// </summary>
    /// <param name="timeout">How long cinematic mode should last.</param>
    /// <param name="linkedTimer">this timer will start at the same time as cinematic mosw</param>
    public CinematicMode(float timeout, ILinkedTimer linkedTimer)
    {
      Timeout = timeout;
      _linkedTimer = linkedTimer;
    }

    /// <inheritdoc/>
    public void StartTimer()
    {
     
      _cinermaticTimer = CreateTimer();
      TimerStart(_cinermaticTimer, Timeout, false, TimerEnd);

      _musicTimer = CreateTimer();
      TimerStart(_musicTimer, 2.1f, false, PlayFactionMusic);
      FogEnable(false);
      FogMaskEnable(false);

      Player(21).ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400, 1.00f);
      Player(19).ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400, 1.00f);
      Player(8).ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400, 1.00f);

      ShowInterface(false, 0.5f);
      ForceCinematicSubtitles(true);
      EnableUserControl(false);
      _state = CinematicState.Active;
      _linkedTimer.StartTimer();
    }

    /// <summary>
    /// Ends cinematic mode early for all players.
    /// </summary>
    public void EndEarly()
    {
      DestroyTimer(_cinermaticTimer);
      TimerEnd();
    }

    private void TimerEnd()
    {
      if (_state != CinematicState.Active)
        return;

      FogEnable(true);
      ResetToGameCamera(1);
      ShowInterface(true, 2);
      EnableUserControl(true);
      ForceCinematicSubtitles(false);
      SetMapMusic("music", true, 0);
      SetCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400f, 1f);

      VolumeGroupReset();
      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_AMBIENTSOUNDS, 0.4f);

      DestroyTimer(_cinermaticTimer);
      DestroyTimer(_musicTimer);
      _state = CinematicState.Finished;
      OnTimerEnds?.Invoke(this, new EventArgs());
    }

    private static void PlayFactionMusic()
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        if (GetLocalPlayer() == player)
        {
          PlayThematicMusic(player.GetFaction()?.CinematicMusic);
        }
      }
    }

  }
}