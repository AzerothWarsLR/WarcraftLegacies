using System.Linq;
using MacroTools;
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
    private static weathereffect? _illidanRain;
    private static weathereffect? _illidanWind;
    private static weathereffect? _illidanRain2;
    private static weathereffect? _illidanWind2;
    private static timer? _timer;
    private static CinematicState _state = CinematicState.Inactive;
    
    private static void Cleanup()
    {
      if (_state != CinematicState.Active)
      {
        return;
      }
      
      FogEnable(true);

      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        SetMapMusic("music", true, 0);
        player.GetFaction()?.SetObjectLevel(Constants.UPGRADE_R068_INTRO_FINISHED, 1);
        player.ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400, 1);
        ForceCinematicSubtitles(false);
        if (GetLocalPlayer() != player) continue;
        ResetToGameCamera(1);
        ShowInterface(true, 2);
        EnableUserControl(true);
      }
      
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
      Cleanup();
    }
    
    public static void Start(float timeout)
    {
      _timer = CreateTimer();
      TimerStart(_timer, timeout, false, Cleanup);

      var musicTimer = CreateTimer();
      TimerStart(musicTimer, 2.1f, false, PlayFactionMusic);
      
      FogEnable(false);
      FogMaskEnable(false);
      
      ForsakenSetup.Forsaken?.Player?.SetupCamera(Cameras.Forsaken1, true, 0);
      //Todo: uncomment below
      //NzothSetup.Nzoth.Player.SetupCamera(Cameras.Nazsjatar1, true, 0); 

      Player(21).ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400, 1.00f);
      Player(19).ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400, 1.00f);
      Player(8).ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400, 1.00f);

      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_MUSIC, 0.45f);
      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_AMBIENTSOUNDS, 0);
      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_UI, 0);
      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_SPELLS, 0.4f);
      
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        if (GetLocalPlayer() == player)
        {
          ShowInterface(false, 0.5f);
        }
      }

      ForceCinematicSubtitles(true);

      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        if (GetLocalPlayer() == player)
        {
          EnableUserControl(false);
        }
      }

      _state = CinematicState.Active;
    }
  }
}