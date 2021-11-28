using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using AzerothWarsCSharp.IntegrityChecker;
using AzerothWarsCSharp.ObjectFactory.Units;
using War3Api.Object;
using War3Net.Build;
using War3Net.Build.Extensions;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.IO.Mpq;
using WCSharp.ConstantGenerator;

namespace AzerothWarsCSharp.Launcher
{
  internal static class Program
  {
    // Input
    private const string SourceCodeProjectFolderPath = @"..\..\..\..\AzerothWarsCSharp.Source";
    private const string JassHelperPath = @"..\..\..\..\..\build\JassHelper\jasshelper.exe";

    /// <summary>
    ///   Folder containing loose JASS files that will be added to the final result.
    /// </summary>
    private const string JassFolderPath = @"..\..\..\..\..\jass\";
    private const string BaseMapPath = @"..\..\..\..\..\maps\source.w3x";

    /// <summary>
    ///   File containing Warcraft 3 objects that will be added to the final result.
    /// </summary>
    private const string BaseObjectPath = @"..\..\..\..\..\source.w3o";

    // Output
    private const string OutputFolderPath = @"..\..\..\..\..\artifacts";
    private const string CompiledJassFolderPath = @"..\..\..\..\..\artifacts\compiledJass\";
    private const string OutputMapName = @"target.w3x";

    // Warcraft III
    private const string GraphicsApi = "Direct3D9";

    /// <summary>
    ///   Entry point for the program.
    /// </summary>
    private static void Main()
    {
      Console.WriteLine("The following actions are available:");
      Console.WriteLine("1. Generate constants");
      Console.WriteLine("2. Compile map");
      Console.WriteLine("3. Compile and run map");
      Console.WriteLine("4. Find unused models");
      MakeDecision();
    }

    /// <summary>
    ///   Prompts the user for some build options.
    /// </summary>
    private static void MakeDecision()
    {
      Console.Write("Please type the number of your desired action: ");
      switch (Console.ReadKey().Key)
      {
        case ConsoleKey.D1:
          ConstantGenerator.Run(BaseMapPath, SourceCodeProjectFolderPath, new ConstantGeneratorOptions
          {
            IncludeCode = false
          });
          break;
        case ConsoleKey.D2:
          Build(false);
          break;
        case ConsoleKey.D3:
          Build(true);
          break;
        case ConsoleKey.D4:
          DisplayUnusedModels();
          break;
        default:
          Console.WriteLine($"{Environment.NewLine}Invalid input. Please choose again.");
          MakeDecision();
          break;
      }
    }

    private static void DisplayUnusedModels()
    {
      //List directories which may have models in them
      var modelFolderPaths = new List<string>()
      {
        Path.Combine(BaseMapPath, "war3mapImported"),
        BaseMapPath
      };
      
      //Get all models in relevant directories
      var modelFilePaths = new List<string>();
      foreach (var path in modelFolderPaths)
      {
        modelFilePaths.AddRange(Directory.EnumerateFiles(path, "*.mdx"));
      }

      //Get object data
      using var fileStream = File.OpenRead(BaseObjectPath);
      using var binaryReader = new BinaryReader(fileStream);
      var objectData = binaryReader.ReadObjectData(false);
      
      //Get and display unused models
      var unusedModels = MapIntegrityChecker.FindUnusedModels(objectData, modelFilePaths, BaseMapPath);
      foreach (var unusedModel in unusedModels)
      {
        Console.WriteLine(unusedModel.RelativePathMdx);
      }
    }
    
    /// <summary>
    ///   Builds the Warcraft 3 map.
    /// </summary>
    private static void Build(bool launch)
    {
      // Ensure these folders exist
      Directory.CreateDirectory(OutputFolderPath);
      Directory.CreateDirectory(CompiledJassFolderPath);

      //Collect required paths
      var blizzardJ = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "Warcraft III/JassHelper/Blizzard.j");
      var commonJ = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "Warcraft III/JassHelper/common.j");

      //Load loose JASS code into temporary map file
      var jassHelper = new JassHelper(JassHelperPath, commonJ, blizzardJ, OutputFolderPath);
      var mergedJassFilePath = Path.Combine(CompiledJassFolderPath, "war3map.j");
      jassHelper.CombineVJassWithJass(Path.Combine(BaseMapPath, "war3map.j"), new[] {JassFolderPath}, mergedJassFilePath);

      // Load existing map data
      var map = Map.Open(BaseMapPath);
      var builder = new MapBuilder(map);
      builder.AddFiles(BaseMapPath, "*", SearchOption.AllDirectories);
      
      //Transpile the JASS file to a Lua file
      map.Info.ScriptLanguage = ScriptLanguage.Lua;
      map.Script = ScriptTranspiler.JassToLua(File.ReadAllText(mergedJassFilePath));
      
      // Build w3x file
      var archiveCreateOptions = new MpqArchiveCreateOptions
      {
        ListFileCreateMode = MpqFileCreateMode.Overwrite,
        AttributesCreateMode = MpqFileCreateMode.Prune,
        BlockSize = 3
      };
      builder.Build(Path.Combine(OutputFolderPath, OutputMapName), archiveCreateOptions);

      // Launch if that option was selected
      if (launch) LaunchGame();
    }

    /// <summary>
    /// Launches Warcraft 3.
    /// </summary>
    private static void LaunchGame()
    {
      var wc3Exe = ConfigurationManager.AppSettings["wc3exe"];
      if (File.Exists(wc3Exe))
      {
        var commandLineArgs = new StringBuilder();
        var isReforged = Version.Parse(FileVersionInfo.GetVersionInfo(wc3Exe).FileVersion) >= new Version(1, 32);
        if (isReforged) commandLineArgs.Append(" -launch");
        commandLineArgs.Append($" -graphicsapi {GraphicsApi}");
        commandLineArgs.Append(" -nowfpause");

        var mapPath = Path.Combine(OutputFolderPath, OutputMapName);
        var absoluteMapPath = new FileInfo(mapPath).FullName;
        commandLineArgs.Append($" -loadfile \"{absoluteMapPath}\"");

        Process.Start(wc3Exe, commandLineArgs.ToString());
      }
      else
      {
        throw new Exception("Please set wc3exe in Launcher/app.config to the path of your Warcraft III executable.");
      }
    }

    /// <summary>
    ///   Takes some ObjectData, process it a bit, then adds it to the given ObjectDatabase.
    /// </summary>
    private static ObjectDatabase ProcessAdditionalObjectData(ObjectDatabase destinationObjectDatabase,
      ObjectData objectData)
    {
      var tempObjectDatabase = new ObjectDatabase();
      tempObjectDatabase.AddObjects(objectData);
      foreach (var unit in tempObjectDatabase.GetUnits())
      {
        var unitFactory = new UnitFactory(unit);
        unitFactory.Generate(unit.NewId, destinationObjectDatabase);
      }

      return destinationObjectDatabase;
    }

    /// <summary>
    /// Take a file containing some object data, process it a bit, then add it to the ObjectDatabase.
    /// </summary>
    private static ObjectDatabase ProcessAdditionalObjectData(ObjectDatabase objectDatabase, string objectDataPath)
    {
      using var fileStream = File.OpenRead(objectDataPath);
      using var binaryReader = new BinaryReader(fileStream);
      var objectData = binaryReader.ReadObjectData(false);
      ProcessAdditionalObjectData(objectDatabase, objectData);
      return objectDatabase;
    }

    private static ObjectDatabase GenerateObjectDatabase()
    {
      ObjectDatabase objectDatabase = new();
      //Human.GenerateObjectData(objectDatabase);
      ProcessAdditionalObjectData(objectDatabase, BaseObjectPath);
      return objectDatabase;
    }

    private static void WriteObjectData(Map map, ObjectDatabase objectDatabase)
    {
      var objectData = objectDatabase.GetAllData();
      map.UnitObjectData = objectData.UnitData;
      map.ItemObjectData = objectData.ItemData;
      map.DestructableObjectData = objectData.DestructableData;
      map.DoodadObjectData = objectData.DoodadData;
      map.AbilityObjectData = objectData.AbilityData;
      map.BuffObjectData = objectData.BuffData;
      map.UpgradeObjectData = objectData.UpgradeData;
    }
  }
}