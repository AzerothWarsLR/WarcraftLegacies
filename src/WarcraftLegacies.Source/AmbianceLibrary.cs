namespace WarcraftLegacies.Source;

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
    var s = sound.CreateFromFile("Sound/Ambient/DalaranRuins/DalaranRuinsNight.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("DalaranRuinsNight");
    s.Duration = 114759;
    s.SetChannel(10);
    s.SetVolume(15);
    s.SetDistances(0, 10000.0f);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitBlackCitadelOutlandNight()
  {
    var s = sound.CreateFromFile("Sound/Ambient/BlackCitadel/BlackCitadel_OutlandNight.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("BlackCitadelNight");
    s.Duration = 116318;
    s.SetChannel(10);
    s.SetVolume(18);
    s.SetDistances(0, 10000.0f);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitBlackCitadelOutlandDay()
  {
    var s = sound.CreateFromFile("Sound/Ambient/BlackCitadel/BlackCitadel_OutlandDay.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("BlackCitadelDay");
    s.Duration = 119186;
    s.SetChannel(10);
    s.SetVolume(14);
    s.SetDistances(0, 10000f);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitIceCrownNight()
  {
    var s = sound.CreateFromFile("Sound/Ambient/IceCrown/IceCrownNight.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("IceCrownNight");
    s.Duration = 123220;
    s.SetChannel(10);
    s.SetVolume(14);
    s.SetDistances(0, 10000f);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitAshenvaleNight()
  {
    var s = sound.CreateFromFile("Sound/Ambient/Ashenvale/AshenvaleNight.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("AshenvaleNight");
    s.Duration = 119013;
    s.SetChannel(10);
    s.SetVolume(10);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitLordaeronFallDay()
  {
    var s = sound.CreateFromFile("Sound/Ambient/LordaeronFall/LordaeronFallDay.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("LordaeronFallDay");
    s.Duration = 124766;
    s.SetChannel(10);
    s.SetVolume(10);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitAshenvaleDay()
  {
    var s = sound.CreateFromFile("Sound/Ambient/Ashenvale/AshenvaleDay.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("AshenvaleDay");
    s.Duration = 47700;
    s.SetChannel(10);
    s.SetVolume(10);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitBarrensDay()
  {
    var s = sound.CreateFromFile("Sound/Ambient/Barrens/BarrensDay.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("BarrensDay");
    s.Duration = 113856;
    s.SetChannel(10);
    s.SetVolume(20);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitDalaranRuinsDay()
  {
    var s = sound.CreateFromFile("Sound/Ambient/DalaranRuins/DalaranRuinsDay.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("DalaranRuinsDay");
    s.Duration = 119795;
    s.SetChannel(10);
    s.SetVolume(20);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitWetlandsNight()
  {
    var s = sound.CreateFromFile("Sound/Ambient/SunkenRuins/WetlandsNight.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("SunkenRuinsNight");
    s.Duration = 172730;
    s.SetChannel(10);
    s.SetVolume(5);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitWetlandsDay()
  {
    var s = sound.CreateFromFile("Sound/Ambient/SunkenRuins/Wetlandsday.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("SunkenRuinsDay");
    s.Duration = 175048;
    s.SetChannel(10);
    s.SetVolume(5);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitIceCrownDay()
  {
    var s = sound.CreateFromFile("Sound/Ambient/IceCrown/IceCrownDay.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("IceCrownDay");
    s.Duration = 120528;
    s.SetChannel(10);
    s.SetVolume(14);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitLordaeronSummerDay()
  {
    var s = sound.CreateFromFile("Sound/Ambient/LordaeronSummer/LordaeronSummerDay.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("LordaeronSummerDay");
    s.Duration = 117210;
    s.SetChannel(10);
    s.SetVolume(10);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitCityScapeDay()
  {
    var s = sound.CreateFromFile("Sound/Ambient/CityScape/CityScapeDay.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("DalaranDay");
    s.Duration = 253775;
    s.SetChannel(10);
    s.SetVolume(16);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitLordaeronSummerNight()
  {
    var s = sound.CreateFromFile("Sound/Ambient/LordaeronSummer/LordaeronSummerNight.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("LordaeronSummerNight");
    s.Duration = 122859;
    s.SetChannel(10);
    s.SetVolume(10);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitNorthrendDay()
  {
    var s = sound.CreateFromFile("Sound/Ambient/Northrend/NorthrendDay.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("NorthrendDay");
    s.Duration = 114102;
    s.SetChannel(10);
    s.SetVolume(15);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitNorthrendNight()
  {
    var s = sound.CreateFromFile("Sound/Ambient/Northrend/NorthrendNight.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("DungeonNight");
    s.Duration = 106607;
    s.SetChannel(10);
    s.SetVolume(25);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(400);
    return s;
  }

  private static sound InitLordaeronWinterNight()
  {
    var s = sound.CreateFromFile("Sound/Ambient/LordaeronWinter/LordaeronWinterNight.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("LordaeronWinterNight");
    s.Duration = 118060;
    s.SetChannel(10);
    s.SetVolume(10);
    s.SetDistances(0, 10000);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitLordaeronFallNight()
  {
    var s = sound.CreateFromFile("Sound/Ambient/LordaeronFall/LordaeronFallNight.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("VillageFallNight");
    s.Duration = 124342;
    s.SetChannel(10);
    s.SetVolume(10);
    s.SetDistances(0, 10000.0f);
    s.SetDistanceCutoff(100);
    return s;
  }

  private static sound InitLordaeronWinterDay()
  {
    var s = sound.CreateFromFile("Sound/Ambient/LordaeronWinter/LordaeronWinterDay.flac", true, true, true, 1, 1, "DefaultEAXON");
    s.SetParamsFromLabel("LordaeronWinterDay");
    s.Duration = 117986;
    s.SetChannel(10);
    s.SetVolume(10);
    s.SetDistances(0, 10000.0f);
    s.SetDistanceCutoff(100);
    return s;
  }
}
