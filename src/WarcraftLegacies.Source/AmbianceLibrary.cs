using MacroTools.Extensions;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source
{
  /// <summary>
  /// Provides ambiance sounds with predefined settings.
  /// </summary>
  public static class AmbianceLibrary
  {
    public static sound DalaranRuinsNight { get; }=
      CreateSound("Sound/Ambient/DalaranRuins/DalaranRuinsNight.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("DalaranRuinsNight")
        .SetDuration(114759)
        .SetChannel(10)
        .SetVolume(15)
        .SetDistances(0, 10000.0f)
        .SetDistanceCutoff(100);

    public static sound BlackCitadelOutlandNight { get; }=
      CreateSound("Sound/Ambient/BlackCitadel/BlackCitadel_OutlandNight.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("BlackCitadelNight")
        .SetDuration(116318)
        .SetChannel(10)
        .SetVolume(18)
        .SetDistances(0, 10000.0f)
        .SetDistanceCutoff(100);

    public static sound BlackCitadelOutlandDay { get; }=
      CreateSound("Sound/Ambient/BlackCitadel/BlackCitadel_OutlandDay.flac",
        true, true, true, 1, 1, "DefaultEAXON")
      .SetParamsFromLabel("BlackCitadelDay")
      .SetDuration(119186)
      .SetChannel(10)
      .SetVolume(14)
      .SetDistances(0, 10000f)
      .SetDistanceCutoff(100);

    public static sound IceCrownNight { get; }=
      CreateSound("Sound/Ambient/IceCrown/IceCrownNight.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("IceCrownNight")
        .SetDuration(123220)
        .SetChannel(10)
        .SetVolume(14)
        .SetDistances(0, 10000f)
        .SetDistanceCutoff(100);

    public static sound AshenvaleNight { get; }=
      CreateSound("Sound/Ambient/Ashenvale/AshenvaleNight.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("AshenvaleNight")
        .SetDuration(119013)
        .SetChannel(10)
        .SetVolume(10)
        .SetDistances(0, 10000)
        .SetDistanceCutoff(100);

    public static sound LordaeronFallDay { get; }=
      CreateSound("Sound/Ambient/LordaeronFall/LordaeronFallDay.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("LordaeronFallDay")
        .SetDuration(124766)
        .SetChannel(10)
        .SetVolume(10)
        .SetDistances(0, 10000)
        .SetDistanceCutoff(100);

    public static sound AshenvaleDay { get; }=
      CreateSound("Sound/Ambient/Ashenvale/AshenvaleDay.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("AshenvaleDay")
        .SetDuration(47700)
        .SetChannel(10)
        .SetVolume(10)
        .SetDistances(0, 10000)
        .SetDistanceCutoff(100);

    public static sound BarrensDay { get; }=
      CreateSound("Sound/Ambient/Barrens/BarrensDay.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("BarrensDay")
        .SetDuration(113856)
        .SetChannel(10)
        .SetVolume(20)
        .SetDistances(0, 10000)
        .SetDistanceCutoff(100);

    public static sound DalaranRuinsDay { get; }=
      CreateSound("Sound/Ambient/DalaranRuins/DalaranRuinsDay.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("DalaranRuinsDay")
        .SetDuration(119795)
        .SetChannel(10)
        .SetVolume(20)
        .SetDistances(0, 10000)
        .SetDistanceCutoff(100);

    public static sound WetlandsNight { get; }=
      CreateSound("Sound/Ambient/SunkenRuins/WetlandsNight.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("SunkenRuinsNight")
        .SetDuration(172730)
        .SetChannel(10)
        .SetVolume(5)
        .SetDistances(0, 10000)
        .SetDistanceCutoff(100);

    public static sound Wetlandsday { get; }=
      CreateSound("Sound/Ambient/SunkenRuins/Wetlandsday.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("SunkenRuinsDay")
        .SetDuration(175048)
        .SetChannel(10)
        .SetVolume(5)
        .SetDistances(0, 10000)
        .SetDistanceCutoff(100);

    public static sound IceCrownDay { get; }=
      CreateSound("Sound/Ambient/IceCrown/IceCrownDay.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("IceCrownDay")
        .SetDuration(120528)
        .SetChannel(10)
        .SetVolume(14)
        .SetDistances(0, 10000)
        .SetDistanceCutoff(100);

    public static sound LordaeronSummerDay { get; }=
      CreateSound("Sound/Ambient/LordaeronSummer/LordaeronSummerDay.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("LordaeronSummerDay")
        .SetDuration(117210)
        .SetChannel(10)
        .SetVolume(10)
        .SetDistances(0, 10000)
        .SetDistanceCutoff(100);

    public static sound CityScapeDay { get; }=
      CreateSound("Sound/Ambient/CityScape/CityScapeDay.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("DalaranDay")
        .SetDuration(253775)
        .SetChannel(10)
        .SetVolume(16)
        .SetDistances(0, 10000)
        .SetDistanceCutoff(100);

    public static sound LordaeronSummerNight { get; }=
      CreateSound("Sound/Ambient/LordaeronSummer/LordaeronSummerNight.flac",
        true, true, true, 1, 1, "DefaultEAXON")
      .SetParamsFromLabel("LordaeronSummerNight")
      .SetDuration(122859)
      .SetChannel(10)
      .SetVolume(10)
      .SetDistances(0, 10000)
      .SetDistanceCutoff(100);

    public static sound NorthrendDay { get; }=
      CreateSound("Sound/Ambient/Northrend/NorthrendDay.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("NorthrendDay")
        .SetDuration(114102)
        .SetChannel(10)
        .SetVolume(15)
        .SetDistances(0, 10000)
        .SetDistanceCutoff(100);

    public static sound NorthrendNight { get; }=
      CreateSound("Sound/Ambient/Northrend/NorthrendNight.flac", true, true, true, 1, 1, "DefaultEAXON")
      .SetParamsFromLabel("DungeonNight")
      .SetDuration(106607)
      .SetChannel(10)
      .SetVolume(25)
      .SetDistances(0, 10000)
      .SetDistanceCutoff(400);
    
    public static sound LordaeronWinterNight { get; }=
      CreateSound("Sound/Ambient/LordaeronWinter/LordaeronWinterNight.flac",
        true, true, true, 1, 1, "DefaultEAXON")
      .SetParamsFromLabel("LordaeronWinterNight")
      .SetDuration(118060)
      .SetChannel(10)
      .SetVolume(10)
      .SetDistances(0, 10000)
      .SetDistanceCutoff(100);

    public static sound LordaeronFallNight { get; }=
      CreateSound("Sound/Ambient/LordaeronFall/LordaeronFallNight.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("VillageFallNight")
        .SetDuration(124342)
        .SetChannel(10)
        .SetVolume(10)
        .SetDistances(0, 10000.0f)
        .SetDistanceCutoff(100);

    public static sound LordaeronWinterDay { get; }=
      CreateSound("Sound/Ambient/LordaeronWinter/LordaeronWinterDay.flac", true, true, true, 1, 1, "DefaultEAXON")
        .SetParamsFromLabel("LordaeronWinterDay")
        .SetDuration(117986)
        .SetChannel(10)
        .SetVolume(10)
        .SetDistances(0, 10000.0f)
        .SetDistanceCutoff(100);
  }
}