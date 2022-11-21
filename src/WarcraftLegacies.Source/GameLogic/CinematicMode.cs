using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic
{
  /// <summary>
  /// Used to engage cinematic mode, which prevents players from taking actions and manipulates sound
  /// and weather effects for a cinematic experience.
  /// </summary>
  public static class CinematicMode
  {
    private static timer? _timer;
    private static CinematicState _state = CinematicState.Inactive;
    
    private static void End()
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
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        player.GetFaction()?.SetObjectLevel(Constants.UPGRADE_R068_INTRO_FINISHED, 1);

      VolumeGroupReset();
      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_AMBIENTSOUNDS, 0.4f);

      DestroyTimer(_timer);
      _state = CinematicState.Finished;
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

    /// <summary>
    /// Ends cinematic mode early for all players.
    /// </summary>
    public static void EndEarly()
    {
      DestroyTimer(_timer);
      End();
    }
    
    /// <summary>
    /// Initiates cinematic mode.
    /// </summary>
    /// <param name="timeout">How long cinematic mode should last.</param>
    public static void Start(float timeout)
    {
      _timer = CreateTimer();
      TimerStart(_timer, timeout, false, End);

      var musicTimer = CreateTimer();
      TimerStart(musicTimer, 2.1f, false, PlayFactionMusic);
      
      FogEnable(false);
      FogMaskEnable(false);
      
      ForsakenSetup.Forsaken?.Player?.SetupCamera(Cameras.Forsaken1, true, 0);

      Player(21).ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400, 1.00f);
      Player(19).ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400, 1.00f);
      Player(8).ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400, 1.00f);

      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_MUSIC, 0.45f);
      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_AMBIENTSOUNDS, 0);
      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_UI, 0);
      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_SPELLS, 0.4f);

      ShowInterface(false, 0.5f);
      ForceCinematicSubtitles(true);
      EnableUserControl(false);

      _state = CinematicState.Active;
    }
  }
}