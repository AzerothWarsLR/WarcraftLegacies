using System.Linq;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Game_Logic
{
  public enum CinematicState
  {
    Inactive,
    Active,
    Finished
  }
  
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

      foreach (var player in GeneralHelpers.GetAllPlayers())
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
      SetUnitTimeScale(PreplacedUnitSystem.GetUnit(Constants.UNIT_EILL_THE_BETRAYER_NAGA), 1);

      EnableWeatherEffect(_illidanRain, false);
      EnableWeatherEffect(_illidanWind, false);
      RemoveWeatherEffect(_illidanRain);
      RemoveWeatherEffect(_illidanWind);
      EnableWeatherEffect(_illidanRain2, false);
      EnableWeatherEffect(_illidanWind2, false);
      RemoveWeatherEffect(_illidanRain2);
      RemoveWeatherEffect(_illidanWind2);
      DestroyTimer(_timer);

      _state = CinematicState.Finished;
    }

    private static void PlayFactionMusic()
    {
      foreach (var player in GeneralHelpers.GetAllPlayers())
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

      //Todo: uncomment below
      //DraeneiSetup.Draenei?.Player?.SetCameraLimits(Regions.DraeneiCamLock);
      if (DraeneiSetup.Draenei?.Player == GetLocalPlayer())
      {
        BlzChangeMinimapTerrainTex("war3mapImported\\OutlandMinimap.blp");
      }

      ForsakenSetup.Forsaken.Player?.SetupCamera(Cameras.Forsaken1, true, 0);
      //Todo: uncomment below
      //NzothSetup.Nzoth.Player.SetupCamera(Cameras.Nazsjatar1, true, 0); 

      Player(21).ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400, 1.00f);
      Player(19).ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400, 1.00f);
      Player(8).ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, 2400, 1.00f);

      _illidanRain = AddWeatherEffect(Regions.IllidanWeather.Rect, FourCC("RAhr"));
      EnableWeatherEffect(_illidanRain, true);

      _illidanWind = AddWeatherEffect(Regions.IllidanWeather.Rect, FourCC("WNcw"));
      EnableWeatherEffect(_illidanWind, true);

      _illidanRain2 = AddWeatherEffect(Regions.IllidanAmbiance2.Rect, FourCC("Rahr"));
      EnableWeatherEffect(_illidanRain2, true);

      _illidanWind2 = AddWeatherEffect(Regions.IllidanAmbiance2.Rect, FourCC("WNwc"));
      EnableWeatherEffect(_illidanWind2, true);

      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_MUSIC, 0.45f);
      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_AMBIENTSOUNDS, 0);
      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_UI, 0);
      VolumeGroupSetVolume(SOUND_VOLUMEGROUP_SPELLS, 0.4f);

      var allPlayers = GeneralHelpers.GetAllPlayers().ToList();
      foreach (var player in allPlayers)
      {
        if (GetLocalPlayer() == player)
        {
          ShowInterface(false, 0.5f);
        }
      }

      ForceCinematicSubtitles(true);

      foreach (var player in allPlayers)
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