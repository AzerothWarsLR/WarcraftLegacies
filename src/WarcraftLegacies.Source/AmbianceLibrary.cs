using MacroTools.Extensions;


#pragma warning disable CS1591

namespace WarcraftLegacies.Source
{
  /// <summary>
  /// Provides ambiance sounds with predefined settings.
  /// </summary>
  public static class AmbianceLibrary
  {
    static AmbianceLibrary()
    {
      BlackCitadelOutlandNight = CreateAmbiance("Sound/Ambient/BlackCitadel/BlackCitadel_OutlandNight.flac");
      BlackCitadelOutlandNight.SetParamsFromLabel("BlackCitadelNight");
      BlackCitadelOutlandNight.SetDuration(116318);
      BlackCitadelOutlandNight.SetVolume(18);
      BlackCitadelOutlandNight.SetDistanceCutoff(100);

      BlackCitadelOutlandDay = CreateAmbiance("Sound/Ambient/BlackCitadel/BlackCitadel_OutlandDay.flac");
      BlackCitadelOutlandDay.SetParamsFromLabel("BlackCitadelDay");
      BlackCitadelOutlandDay.SetDuration(119186);
      BlackCitadelOutlandDay.SetVolume(14);
      BlackCitadelOutlandDay.SetDistanceCutoff(100);

      IceCrownNight = CreateAmbiance("Sound/Ambient/IceCrown/IceCrownNight.flac");
      IceCrownNight.SetParamsFromLabel("IceCrownNight");
      IceCrownNight.SetDuration(123220);
      IceCrownNight.SetVolume(14);
      IceCrownNight.SetDistanceCutoff(100);

      LordaeronFallDay = CreateAmbiance("Sound/Ambient/LordaeronFall/LordaeronFallDay.flac");
      LordaeronFallDay.SetParamsFromLabel("LordaeronFallDay");
      LordaeronFallDay.SetDuration(124766);
      LordaeronFallDay.SetVolume(10);
      LordaeronFallDay.SetDistanceCutoff(100);

      AshenvaleDay = CreateAmbiance("Sound/Ambient/Ashenvale/AshenvaleDay.flac");
      AshenvaleDay.SetParamsFromLabel("AshenvaleDay");
      AshenvaleDay.SetDuration(47700);
      AshenvaleDay.SetVolume(10);
      AshenvaleDay.SetDistanceCutoff(100);

      BarrensDay = CreateAmbiance("Sound/Ambient/Barrens/BarrensDay.flac");
      BarrensDay.SetParamsFromLabel("BarrensDay");
      BarrensDay.SetDuration(113856);
      BarrensDay.SetVolume(20);
      BarrensDay.SetDistanceCutoff(100);

      DalaranRuinsDay = CreateAmbiance("Sound/Ambient/DalaranRuins/DalaranRuinsDay.flac");
      DalaranRuinsDay.SetParamsFromLabel("DalaranRuinsDay");
      DalaranRuinsDay.SetDuration(119795);
      DalaranRuinsDay.SetVolume(20);
      DalaranRuinsDay.SetDistanceCutoff(100);

      WetlandsNight = CreateAmbiance("Sound/Ambient/SunkenRuins/WetlandsNight.flac");
      WetlandsNight.SetParamsFromLabel("SunkenRuinsNight");
      WetlandsNight.SetDuration(172730);
      WetlandsNight.SetVolume(5);
      WetlandsNight.SetDistanceCutoff(100);

      Wetlandsday = CreateAmbiance("Sound/Ambient/SunkenRuins/Wetlandsday.flac");
      Wetlandsday.SetParamsFromLabel("SunkenRuinsDay");
      Wetlandsday.SetDuration(175048);
      Wetlandsday.SetVolume(5);
      Wetlandsday.SetDistanceCutoff(100);

      IceCrownDay = CreateAmbiance("Sound/Ambient/IceCrown/IceCrownDay.flac");
      IceCrownDay.SetParamsFromLabel("IceCrownDay");
      IceCrownDay.SetDuration(120528);
      IceCrownDay.SetVolume(14);
      IceCrownDay.SetDistanceCutoff(100);

      LordaeronSummerDay = CreateAmbiance("Sound/Ambient/LordaeronSummer/LordaeronSummerDay.flac");
      LordaeronSummerDay.SetParamsFromLabel("LordaeronSummerDay");
      LordaeronSummerDay.SetDuration(117210);
      LordaeronSummerDay.SetVolume(10);
      LordaeronSummerDay.SetDistanceCutoff(100);

      CityScapeDay = CreateAmbiance("Sound/Ambient/CityScape/CityScapeDay.flac");
      CityScapeDay.SetParamsFromLabel("DalaranDay");
      CityScapeDay.SetDuration(253775);
      CityScapeDay.SetVolume(16);
      CityScapeDay.SetDistanceCutoff(100);

      LordaeronSummerNight = CreateAmbiance("Sound/Ambient/LordaeronSummer/LordaeronSummerNight.flac");
      LordaeronSummerNight.SetParamsFromLabel("LordaeronSummerNight");
      LordaeronSummerNight.SetDuration(122859);
      LordaeronSummerNight.SetVolume(10);
      LordaeronSummerNight.SetDistanceCutoff(100);

      NorthrendDay = CreateAmbiance("Sound/Ambient/Northrend/NorthrendDay.flac");
      NorthrendDay.SetParamsFromLabel("NorthrendDay");
      NorthrendDay.SetDuration(114102);
      NorthrendDay.SetVolume(15);
      NorthrendDay.SetDistanceCutoff(100);

      NorthrendNight = CreateAmbiance("Sound/Ambient/Northrend/NorthrendNight.flac");
      NorthrendNight.SetParamsFromLabel("DungeonNight");
      NorthrendNight.SetDuration(106607);
      NorthrendNight.SetVolume(25);
      NorthrendNight.SetDistanceCutoff(400);

      LordaeronWinterNight = CreateAmbiance("Sound/Ambient/LordaeronWinter/LordaeronWinterNight.flac");
      LordaeronWinterNight.SetParamsFromLabel("LordaeronWinterNight");
      LordaeronWinterNight.SetDuration(118060);
      LordaeronWinterNight.SetVolume(10);
      LordaeronWinterNight.SetDistanceCutoff(100);

      LordaeronFallNight = CreateAmbiance("Sound/Ambient/LordaeronFall/LordaeronFallNight.flac");
      LordaeronFallNight.SetParamsFromLabel("VillageFallNight");
      LordaeronFallNight.SetDuration(124342);
      LordaeronFallNight.SetVolume(10);
      LordaeronFallNight.SetDistanceCutoff(100);

      LordaeronWinterDay = CreateAmbiance("Sound/Ambient/LordaeronWinter/LordaeronWinterDay.flac");
      LordaeronWinterDay.SetParamsFromLabel("LordaeronWinterDay");
      LordaeronWinterDay.SetDuration(117986);
      LordaeronWinterDay.SetVolume(10);
      LordaeronWinterDay.SetDistanceCutoff(100);

      AshenvaleNight = CreateAmbiance("Sound/Ambient/Ashenvale/AshenvaleNight.flac");
      AshenvaleNight.SetParamsFromLabel("AshenvaleNight");
      AshenvaleNight.SetDuration(119013);
      AshenvaleNight.SetVolume(10);
      AshenvaleNight.SetDistanceCutoff(100);
    }

    private static sound CreateAmbiance(string fileName)
    {
      var ambiance = CreateSound(fileName, true, true, true, 1, 1, "DefaultEAXON");
      ambiance.SetDistances(0, 10000);
      ambiance.SetChannel(10);
      return ambiance;
    }

    public static sound BlackCitadelOutlandNight { get; }

    public static sound BlackCitadelOutlandDay { get; }

    public static sound IceCrownNight { get; }

    public static sound AshenvaleNight { get; }

    public static sound LordaeronFallDay { get; }

    public static sound AshenvaleDay { get; }

    public static sound BarrensDay { get; }

    public static sound DalaranRuinsDay { get; }

    public static sound WetlandsNight { get; }

    public static sound Wetlandsday { get; }

    public static sound IceCrownDay { get; }

    public static sound LordaeronSummerDay { get; }

    public static sound CityScapeDay { get; }

    public static sound LordaeronSummerNight { get; }

    public static sound NorthrendDay { get; }

    public static sound NorthrendNight { get; }
    
    public static sound LordaeronWinterNight { get; }

    public static sound LordaeronFallNight { get; }

    public static sound LordaeronWinterDay { get; }
  }
}