#nullable enable
using System;
using System.CommandLine;
using System.IO;
using System.Linq;
using AutoMapper;
using Launcher.Services;
using Launcher.Settings;
using WCSharp.ConstantGenerator;

namespace Launcher.Commands;

public static class W3XToJsonCommand
{
  public static void RegisterW3XToJsonCommand(this RootCommand rootCommand)
  {
    var command = new Command("w3x-to-json", "Converts a Warcraft 3 map file into raw map data.");
    rootCommand.Add(command);

    var mapNameArgument = new Argument<string>(
      name: "map-name",
      description: "The name of the Warcraft 3 map to convert into mapdata, located in the maps folder as a .w3x folder.");
    command.AddArgument(mapNameArgument);

    command.SetHandler(Run, mapNameArgument);
  }

  private static void Run(string mapName)
  {
    var autoMapperConfig = AutoMapperConfigurationProvider.GetConfiguration();
    var mapper = new Mapper(autoMapperConfig);
    var appSettings = AppSettings.Load();

    var baseMapPath = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.MapsPath, $"{mapName}.w3x");
    var outputDirectory = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.MapDataPath, mapName);

    new W3XToMapDataConverter(mapper).Convert(baseMapPath, outputDirectory);

    GenerateConstants(appSettings, mapName);
  }

  private static readonly string[] _constantsHeader = ["﻿#pragma warning disable"];

  private static void GenerateConstants(AppSettings appSettings, string mapName)
  {
    var triggerStringsPath = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.MapDataPath, mapName, "war3map.wts");
    if (!File.Exists(triggerStringsPath))
    {
      Console.WriteLine("Could not find TriggerStrings file. Skipping Constants generation step.");
      return;
    }

    var mapPath = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.MapsPath, $"{mapName}.w3x");

    var sharedProjectPath = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.SrcPath, $"{mapName}.Shared");
    var constantsPath = Path.Combine(sharedProjectPath, "Constants.cs");

    var sourceProjectPath = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.SrcPath, $"{mapName}.Source");
    var regionsPath = Path.Combine(sourceProjectPath, "Regions.cs");

    Console.WriteLine("Generating Constants.cs and Regions.cs files...");
    ConstantGenerator.Run(mapPath, sharedProjectPath, new ConstantGeneratorOptions
    {
      IncludeCode = true
    });
    // ConstantGenerator always outputs order ids, which we already have in MacroTools.Shared.
    // We remove lines starting with 'public const int ORDER_' to avoid duplication.
    File.WriteAllLines(constantsPath, _constantsHeader
      .Concat(File.ReadLines(constantsPath).Where(l => !l.AsSpan().TrimStart().StartsWith("public const int ORDER_")))
      .ToArray());

    File.WriteAllLines(regionsPath, _constantsHeader.Concat(File.ReadAllLines(regionsPath)).ToArray());
    File.Move(Path.Combine(sharedProjectPath, "Regions.cs"), regionsPath, true);
  }
}
