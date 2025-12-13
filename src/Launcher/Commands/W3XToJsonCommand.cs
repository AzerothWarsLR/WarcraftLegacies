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

    var baseMapPath = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.Maps, $"{mapName}.w3x");
    var outputDirectory = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.MapData, mapName);

    new W3XToMapDataConverter(mapper).Convert(baseMapPath, outputDirectory);
    var constantsOutputPath = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.Src, "WarcraftLegacies.Shared");
    var regionsOutputPath = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.Src, "WarcraftLegacies.Source");

    GenerateConstants(baseMapPath, constantsOutputPath, regionsOutputPath);
  }

  private static readonly string[] _constantsHeader = ["﻿#pragma warning disable"];

  private static void GenerateConstants(string baseMapPath, string constantsOutputPath, string? regionsOutputPath)
  {
    try
    {
      Console.WriteLine("Generating Constants.cs and Regions.cs files...");
      ConstantGenerator.Run(baseMapPath, constantsOutputPath, new ConstantGeneratorOptions
      {
        IncludeCode = true
      });
      // ConstantGenerator always outputs order ids, which we already have in MacroTools.Shared.
      // We remove lines starting with 'public const int ORDER_' to avoid duplication.
      File.WriteAllLines($"{constantsOutputPath}/Constants.cs", _constantsHeader
        .Concat(File.ReadLines($"{constantsOutputPath}/Constants.cs").Where(l => !l.AsSpan().TrimStart().StartsWith("public const int ORDER_")))
        .ToArray());

      File.WriteAllLines($"{constantsOutputPath}/Regions.cs", _constantsHeader.Concat(File.ReadAllLines($"{constantsOutputPath}/Regions.cs")).ToArray());
      File.Move($"{constantsOutputPath}/Regions.cs", $"{regionsOutputPath}/Regions.cs", true);

    }
    catch (FileNotFoundException)
    {
      Console.WriteLine("Could not find TriggerStrings file. Skipping Constants generation step.");
    }
  }
}
