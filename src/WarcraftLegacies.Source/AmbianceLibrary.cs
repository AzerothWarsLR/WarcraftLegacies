#pragma warning disable CS1591

namespace WarcraftLegacies.Source
{
  /// <summary>
  /// Provides ambiance sounds with predefined settings.
  /// </summary>
  public static class AmbianceLibrary
  {
    public static sound DalaranRuinsNight { get; } = InitDalaranRuinsNight();

    public static sound BlackCitadelOutlandNight { get; } = InitBlackCitadelOutlandNight();

    public static sound BlackCitadelOutlandDay { get; } = InitBlackCitadelOutlandDay();

    public static sound IceCrownNight { get; } = InitIceCrownNight();

    public static sound AshenvaleNight { get; } = InitAshenvaleNight();

    public static sound LordaeronFallDay { get; } = InitLordaeronFallDay();

    public static sound AshenvaleDay { get; } = InitAshenvaleDay();

    public static sound BarrensDay { get; } = InitBarrensDay();

    public static sound DalaranRuinsDay { get; } = InitDalaranRuinsDay();

    public static sound WetlandsNight { get; } = InitWetlandsNight();

    public static sound WetlandsDay { get; } = InitWetlandsDay();

    public static sound IceCrownDay { get; } = InitIceCrownDay();

    public static sound LordaeronSummerDay { get; } = InitLordaeronSummerDay();

    public static sound CityScapeDay { get; } = InitCityScapeDay();

    public static sound LordaeronSummerNight { get; } = InitLordaeronSummerNight();

    public static sound NorthrendDay { get; } = InitNorthrendDay();

    public static sound NorthrendNight { get; } = InitNorthrendNight();

    public static sound LordaeronWinterNight { get; } = InitLordaeronWinterNight();

    public static sound LordaeronFallNight { get; } = InitLordaeronFallNight();

    public static sound LordaeronWinterDay { get; } = InitLordaeronWinterDay();

    private static sound InitDalaranRuinsNight()
    {
      var s = CreateSound("Sound/Ambient/DalaranRuins/DalaranRuinsNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      SetSoundParamsFromLabel(s, "DalaranRuinsNight");
      SetSoundDuration(s, 114759);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 15);
      SetSoundDistances(s, 0, 10000.0f);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitBlackCitadelOutlandNight()
    {
      var s = CreateSound("Sound/Ambient/BlackCitadel/BlackCitadel_OutlandNight.flac", true, true, true, 1, 1,
        "DefaultEAXON");
      SetSoundParamsFromLabel(s, "BlackCitadelNight");
      SetSoundDuration(s, 116318);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 18);
      SetSoundDistances(s, 0, 10000.0f);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitBlackCitadelOutlandDay()
    {
      var s = CreateSound("Sound/Ambient/BlackCitadel/BlackCitadel_OutlandDay.flac", true, true, true, 1, 1,
        "DefaultEAXON");
      SetSoundParamsFromLabel(s, "BlackCitadelDay");
      SetSoundDuration(s, 119186);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 14);
      SetSoundDistances(s, 0, 10000f);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitIceCrownNight()
    {
      var s = CreateSound("Sound/Ambient/IceCrown/IceCrownNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      SetSoundParamsFromLabel(s, "IceCrownNight");
      SetSoundDuration(s, 123220);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 14);
      SetSoundDistances(s, 0, 10000f);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitAshenvaleNight()
    {
      var s = CreateSound("Sound/Ambient/Ashenvale/AshenvaleNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      SetSoundParamsFromLabel(s, "AshenvaleNight");
      SetSoundDuration(s, 119013);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 10);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitLordaeronFallDay()
    {
      var s = CreateSound("Sound/Ambient/LordaeronFall/LordaeronFallDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      SetSoundParamsFromLabel(s, "LordaeronFallDay");
      SetSoundDuration(s, 124766);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 10);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitAshenvaleDay()
    {
      var s = CreateSound("Sound/Ambient/Ashenvale/AshenvaleDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      SetSoundParamsFromLabel(s, "AshenvaleDay");
      SetSoundDuration(s, 47700);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 10);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitBarrensDay()
    {
      var s = CreateSound("Sound/Ambient/Barrens/BarrensDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      SetSoundParamsFromLabel(s, "BarrensDay");
      SetSoundDuration(s, 113856);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 20);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitDalaranRuinsDay()
    {
      var s = CreateSound("Sound/Ambient/DalaranRuins/DalaranRuinsDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      SetSoundParamsFromLabel(s, "DalaranRuinsDay");
      SetSoundDuration(s, 119795);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 20);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitWetlandsNight()
    {
      var s = CreateSound("Sound/Ambient/SunkenRuins/WetlandsNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      SetSoundParamsFromLabel(s, "SunkenRuinsNight");
      SetSoundDuration(s, 172730);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 5);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitWetlandsDay()
    {
      var s = CreateSound("Sound/Ambient/SunkenRuins/Wetlandsday.flac", true, true, true, 1, 1, "DefaultEAXON");
      SetSoundParamsFromLabel(s, "SunkenRuinsDay");
      SetSoundDuration(s, 175048);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 5);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitIceCrownDay()
    {
      var s = CreateSound("Sound/Ambient/IceCrown/IceCrownDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      SetSoundParamsFromLabel(s, "IceCrownDay");
      SetSoundDuration(s, 120528);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 14);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitLordaeronSummerDay()
    {
      var s = CreateSound("Sound/Ambient/LordaeronSummer/LordaeronSummerDay.flac", true, true, true, 1, 1,
        "DefaultEAXON");
      SetSoundParamsFromLabel(s, "LordaeronSummerDay");
      SetSoundDuration(s, 117210);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 10);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitCityScapeDay()
    {
      var s = CreateSound("Sound/Ambient/CityScape/CityScapeDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      SetSoundParamsFromLabel(s, "DalaranDay");
      SetSoundDuration(s, 253775);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 16);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitLordaeronSummerNight()
    {
      var s = CreateSound("Sound/Ambient/LordaeronSummer/LordaeronSummerNight.flac", true, true, true, 1, 1,
        "DefaultEAXON");
      SetSoundParamsFromLabel(s, "LordaeronSummerNight");
      SetSoundDuration(s, 122859);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 10);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitNorthrendDay()
    {
      var s = CreateSound("Sound/Ambient/Northrend/NorthrendDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      SetSoundParamsFromLabel(s, "NorthrendDay");
      SetSoundDuration(s, 114102);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 15);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitNorthrendNight()
    {
      var s = CreateSound("Sound/Ambient/Northrend/NorthrendNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      SetSoundParamsFromLabel(s, "DungeonNight");
      SetSoundDuration(s, 106607);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 25);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 400);
      return s;
    }

    private static sound InitLordaeronWinterNight()
    {
      var s = CreateSound("Sound/Ambient/LordaeronWinter/LordaeronWinterNight.flac", true, true, true, 1, 1,
        "DefaultEAXON");
      SetSoundParamsFromLabel(s, "LordaeronWinterNight");
      SetSoundDuration(s, 118060);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 10);
      SetSoundDistances(s, 0, 10000);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitLordaeronFallNight()
    {
      var s = CreateSound("Sound/Ambient/LordaeronFall/LordaeronFallNight.flac", true, true, true, 1, 1,
        "DefaultEAXON");
      SetSoundParamsFromLabel(s, "VillageFallNight");
      SetSoundDuration(s, 124342);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 10);
      SetSoundDistances(s, 0, 10000.0f);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }

    private static sound InitLordaeronWinterDay()
    {
      var s = CreateSound("Sound/Ambient/LordaeronWinter/LordaeronWinterDay.flac", true, true, true, 1, 1,
        "DefaultEAXON");
      SetSoundParamsFromLabel(s, "LordaeronWinterDay");
      SetSoundDuration(s, 117986);
      SetSoundChannel(s, 10);
      SetSoundVolume(s, 10);
      SetSoundDistances(s, 0, 10000.0f);
      SetSoundDistanceCutoff(s, 100);
      return s;
    }
  }
}