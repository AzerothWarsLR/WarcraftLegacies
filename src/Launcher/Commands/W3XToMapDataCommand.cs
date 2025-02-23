﻿#nullable enable
using System;
using System.CommandLine;
using System.IO;
using AutoMapper;
using Launcher.Services;
using WCSharp.ConstantGenerator;

namespace Launcher.Commands
{
  public static class W3XToMapDataCommand
  {
    public static void RegisterW3XToMapDataCommand(this RootCommand rootCommand)
    {
      var command = new Command("w3x-to-mapdata", "Converts a Warcraft 3 map file into raw map data.");
      rootCommand.Add(command);

      var baseMapPathArgument = new Argument<string>(
        name: "basemappath",
        description: "The Warcraft 3 map to convert into map data.");
      command.AddArgument(baseMapPathArgument);
      
      var outputDirectoryArgument = new Argument<string>(
        name: "outputDirectory",
        description: "A path to the directory in which the created map data will be stored.");
      command.AddArgument(outputDirectoryArgument);

      var constantsOutputPathOption = new Option<string>(
        name: "--constantsOutputPath",
        description: "Where to output the Constants files generated by the process.");
      command.AddOption(constantsOutputPathOption);
      
      var regionsOutputPathOption = new Option<string>(
        name: "--regionsOutputPath",
        description: "Where to output the Regions files generated by the process.");
      command.AddOption(regionsOutputPathOption);
      
      command.SetHandler(Run, baseMapPathArgument, outputDirectoryArgument, constantsOutputPathOption, regionsOutputPathOption);
    }

    private static void Run(string baseMapPath, string outputDirectory, string? constantsOutputPath, string? regionsOutputPath)
    {
      var autoMapperConfig = new AutoMapperConfigurationProvider().GetConfiguration();
      var mapper = new Mapper(autoMapperConfig);
      new W3XToMapDataConverter(mapper).Convert(baseMapPath, outputDirectory);
      if (constantsOutputPath != null) 
        GenerateConstants(baseMapPath, constantsOutputPath, regionsOutputPath);
    }

    private static void GenerateConstants(string baseMapPath, string constantsOutputPath, string? regionsOutputPath)
    {
      try
      {
        Console.WriteLine("Generating Constants.cs and Regions.cs files...");
        ConstantGenerator.Run(baseMapPath, constantsOutputPath, new ConstantGeneratorOptions
        {
          IncludeCode = true
        });
        if (regionsOutputPath != null)
          File.Move($"{constantsOutputPath}/Regions.cs", $"{regionsOutputPath}/Regions.cs", true);
      }
      catch (FileNotFoundException)
      {
        Console.WriteLine("Could not find TriggerStrings file. Skipping Constants generation step.");
      }
    }
  }
}