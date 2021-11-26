using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using CSharpLua;
using Microsoft.CodeAnalysis;
using War3Api.Object;
using War3Net.Build;
using War3Net.Build.Extensions;
using War3Net.Build.Object;
using War3Net.IO.Mpq;
using WCSharp.ConstantGenerator;
using AzerothWarsCSharp.ObjectFactory.Units;

namespace AzerothWarsCSharp.Launcher
{
  internal static class Program
  {
    // Input
    private const string SourceCodeProjectFolderPath = @"..\..\..\..\AzerothWarsCSharp.Source";
    private const string AssetsFolderPath = @"..\..\..\..\Assets\";
    private const string BaseMapPath = @"..\..\..\..\..\testsource.w3x";
    private const string BaseObjectPath = @"..\..\..\..\..\source.w3o"; //These objects get added into the map

    // Output
    private const string OutputFolderPath = @"..\..\..\..\artifacts";
    private const string OutputScriptName = @"war3map.lua";
    private const string OutputMapName = @"target.w3x";

    // Warcraft III
    private const string GraphicsApi = "Direct3D9";
#if DEBUG
    private const bool Debug = true;
#else
		private const bool Debug = false;
#endif

    private static void Main()
    {
      Console.WriteLine("The following actions are available:");
      Console.WriteLine("1. Generate constants");
      Console.WriteLine("2. Compile map");
      Console.WriteLine("3. Compile and run map");
      MakeDecision();
    }

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
        default:
          Console.WriteLine($"{Environment.NewLine}Invalid input. Please choose again.");
          MakeDecision();
          break;
      }
    }

    private static void Build(bool launch)
    {
      // Ensure these folders exist
      Directory.CreateDirectory(AssetsFolderPath);
      Directory.CreateDirectory(OutputFolderPath);

      // Load existing map data
      var map = Map.Open(BaseMapPath);
      var builder = new MapBuilder(map);
      builder.AddFiles(BaseMapPath, "*", SearchOption.AllDirectories);
      builder.AddFiles(AssetsFolderPath, "*", SearchOption.AllDirectories);

      // Set debug options if necessary, configure compiler
      const string csc = Debug ? "-debug -define:DEBUG" : null;
      var csproj = Directory.EnumerateFiles(SourceCodeProjectFolderPath, "*.csproj", SearchOption.TopDirectoryOnly).Single();
      var compiler = new Compiler(csproj, OutputFolderPath, string.Empty, null!, "War3Api.*;WCSharp.*", "", csc, false, null, string.Empty)
      {
        IsExportMetadata = true,
        IsModule = false,
        IsInlineSimpleProperty = false,
        IsPreventDebugObject = true,
        IsCommentsDisabled = !Debug
      };

      // Collect required paths and compile
      var coreSystemFiles = CSharpLua.CoreSystem.CoreSystemProvider.GetCoreSystemFiles();
      var blizzardJ = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Warcraft III/JassHelper/Blizzard.j");
      var commonJ = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Warcraft III/JassHelper/common.j");
      var compileResult = map.CompileScript(compiler, coreSystemFiles, blizzardJ, commonJ);

      // If compilation failed, output an error
      if (!compileResult.Success)
      {
        throw new Exception(compileResult.Diagnostics.First(x => x.Severity == DiagnosticSeverity.Error).GetMessage());
      }

      // Update war3map.lua so you can inspect the generated Lua code easily
      File.WriteAllText(Path.Combine(OutputFolderPath, OutputScriptName), map.Script);

      //Generate and write object data
      WriteObjectData(map, GenerateObjectDatabase());

      // Build w3x file
      var archiveCreateOptions = new MpqArchiveCreateOptions
      {
        ListFileCreateMode = MpqFileCreateMode.Overwrite,
        AttributesCreateMode = MpqFileCreateMode.Prune,
        BlockSize = 3,
      };
      builder.Build(Path.Combine(OutputFolderPath, OutputMapName), archiveCreateOptions);

      // Launch if that option was selected
      if (launch)
      {
        var wc3Exe = ConfigurationManager.AppSettings["wc3exe"];
        if (File.Exists(wc3Exe))
        {
          var commandLineArgs = new StringBuilder();
          var isReforged = Version.Parse(FileVersionInfo.GetVersionInfo(wc3Exe).FileVersion) >= new Version(1, 32);
          if (isReforged)
          {
            commandLineArgs.Append(" -launch");
          }
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
    }

    /// <summary>
    /// Takes some ObjectData, process it a bit, then adds it to the given ObjectDatabase.
    /// </summary>
    private static ObjectDatabase ProcessAdditionalObjectData(ObjectDatabase destinationObjectDatabase, ObjectData objectData)
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