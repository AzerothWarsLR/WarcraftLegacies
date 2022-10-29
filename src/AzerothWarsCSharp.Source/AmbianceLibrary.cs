using static War3Api.Common;
#pragma warning disable CS1591

namespace AzerothWarsCSharp.Source
{
  /// <summary>
  /// Provides ambiance sounds with predefined settings.
  /// </summary>
  public static class AmbianceLibrary
  {
    private static sound? _lordaeronSummerDay;
    private static sound? _cityscapeDay;
    private static sound? _dalaranRuinsDay;
    private static sound? _lordaeronFallDay;
    private static sound? _lordaeronSummerNight;
    private static sound? _blackCitadelOutlandDay;
    private static sound? _wetlandsday;
    private static sound? _ashenvaleDay;
    private static sound? _iceCrownNight;
    private static sound? _iceCrownDay;
    private static sound? _lordaeronWinterDay;
    private static sound? _lordaeronFallNight;
    private static sound? _blackCitadelOutlandNight;
    private static sound? _barrensDay;
    private static sound? _ashenvaleNight;
    private static sound? _wetlandsNight;
    private static sound? _northrendNight;
    private static sound? _northrendDay;
    private static sound? _lordaeronWinterNight;
    private static sound? _dalaranRuinsNight;
    
    public static sound LordaeronSummerDay =>
      _lordaeronSummerDay ??= CreateSound("Sound/Ambient/LordaeronSummer/LordaeronSummerDay.flac", true, true, true, 1,
        1, "DefaultEAXON");
    
    public static sound CityscapeDay =>
      _cityscapeDay ??= CreateSound("Sound/Ambient/CityScape/CityScapeDay.flac", true, true, true, 1, 1, "DefaultEAXON");
    
    public static sound DalaranRuinsDay =>
      _dalaranRuinsDay ??= CreateSound("Sound/Ambient/DalaranRuins/DalaranRuinsDay.flac", true, true, true, 1, 1, "DefaultEAXON");
    
    public static sound LordaeronSummerNight =>
      _lordaeronSummerNight ??= CreateSound("Sound/Ambient/LordaeronSummer/LordaeronSummerNight.flac", true, true, true, 1, 1, "DefaultEAXON");

    public static sound IceCrownDay =>
      _iceCrownDay ??= CreateSound("Sound/Ambient/IceCrown/IceCrownDay.flac", true, true, true, 1, 1, "DefaultEAXON");

    public static sound IceCrownNight =>
      _iceCrownNight ??=
        CreateSound("Sound/Ambient/IceCrown/IceCrownNight.flac", true, true, true, 1, 1, "DefaultEAXON");

    public static sound LordaeronFallDay =>
      _lordaeronFallDay ??= CreateSound("Sound/Ambient/LordaeronFall/LordaeronFallDay.flac", true, true, true, 1, 1,
        "DefaultEAXON");

    public static sound LordaeronFallNight =>
      _lordaeronFallNight ??= CreateSound("Sound/Ambient/LordaeronFall/LordaeronFallNight.flac", true, true, true, 1, 1,
        "DefaultEAXON");

    public static sound WetlandsNight =>
      _wetlandsNight ??= CreateSound("Sound/Ambient/SunkenRuins/WetlandsNight.flac", true, true, true, 1, 1,
        "DefaultEAXON");

    public static sound BlackCitadelOutlandNight =>
      _blackCitadelOutlandNight ??= CreateSound("Sound/Ambient/BlackCitadel/BlackCitadel_OutlandNight.flac", true, true,
        true, 1, 1, "DefaultEAXON");

    public static sound AshenvaleNight =>
      _ashenvaleNight ??= CreateSound("Sound/Ambient/Ashenvale/AshenvaleNight.flac", true, true, true, 1, 1,
        "DefaultEAXON");

    public static sound BarrensDay =>
      _barrensDay ??= CreateSound("Sound/Ambient/Barrens/BarrensDay.flac", true, true, true, 1, 1, "DefaultEAXON");

    public static sound LordaeronWinterDay =>
      _lordaeronWinterDay ??= CreateSound("Sound/Ambient/LordaeronWinter/LordaeronWinterDay.flac", true, true, true, 1,
        1, "DefaultEAXON");

    public static sound NorthrendDay =>
      _northrendDay ??=
        CreateSound("Sound/Ambient/Northrend/NorthrendDay.flac", true, true, true, 1, 1, "DefaultEAXON");
    
    public static sound LordaeronWinterNight =>
      _lordaeronWinterNight ??= CreateSound("Sound/Ambient/LordaeronSummer/LordaeronSummerDay.flac", true, true, true, 1,
        1, "DefaultEAXON");

    public static sound NorthrendNight =>
      _northrendNight ??= CreateSound("Sound/Ambient/LordaeronWinter/LordaeronWinterNight.flac", true, true, true, 1, 1,
        "DefaultEAXON");

    public static sound DalaranRuinsNight =>
      _dalaranRuinsNight ??= CreateSound("Sound/Ambient/DalaranRuins/DalaranRuinsNight.flac", true, true, true, 1, 1,
        "DefaultEAXON");

    public static sound BlackCitadelOutlandDay =>
      _blackCitadelOutlandDay ??= CreateSound("Sound/Ambient/BlackCitadel/BlackCitadel_OutlandDay.flac", true, true,
        true, 1, 1, "DefaultEAXON");

    public static sound AshenvaleDay =>
      _ashenvaleDay ??=
        CreateSound("Sound/Ambient/Ashenvale/AshenvaleDay.flac", true, true, true, 1, 1, "DefaultEAXON");

    public static sound Wetlandsday =>
      _wetlandsday ??=
        CreateSound("Sound/Ambient/SunkenRuins/Wetlandsday.flac", true, true, true, 1, 1, "DefaultEAXON");
  }
}