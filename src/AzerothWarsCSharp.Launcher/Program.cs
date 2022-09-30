using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using CSharpLua;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using War3Net.Build;
using War3Net.Build.Extensions;
using War3Net.Build.Info;
using War3Net.IO.Mpq;
using WCSharp.ConstantGenerator;
using CoreSystemProvider = CSharpLua.CoreSystem.CoreSystemProvider;

namespace AzerothWarsCSharp.Launcher
{
  internal static class Program
  {
    // Input
    private const string SourceCodeProjectFolderPath = @"..\..\..\..\AzerothWarsCSharp.Source";
    private const string TestSourceCodeProjectFolderPath = @"..\..\..\..\AzerothWarsCSharp.TestSource";
    private const string AssetsFolderPath = @"..\..\..\..\Assets\";
    private const string BaseMapPath = @"..\..\..\..\..\maps\source.w3x";
    private const string TestMapPath = @"..\..\..\..\..\maps\testsource.w3x";

    // Output
    private const string OutputFolderPath = @"..\..\..\..\..\artifacts";
    private const string OutputScriptName = @"war3map.lua";
    private const string OutputMapName = @"target.w3x";

    // Warcraft III
    private const string GraphicsApi = "Direct3D9";
#if DEBUG
    private const bool Debug = true;
#else
		private const bool Debug = false;
#endif

    /// <summary>
    ///   Entry point for the program.
    /// </summary>
    private static void Main()
    {
      Console.WriteLine("The following actions are available:");
      Console.WriteLine("1. Generate constants");
      Console.WriteLine("2. Compile map");
      Console.WriteLine("3. Compile and run map");
      Console.WriteLine("4. Compile and run test map");

      IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
      
      MakeDecision(config);
    }

    /// <summary>
    ///   Prompts the user for some build options.
    /// </summary>
    private static void MakeDecision(IConfiguration config)
    {
      Console.Write("Please type the number of your desired action: ");
      switch (Console.ReadKey().Key)
      {
        case ConsoleKey.D1:
          ConstantGenerator.Run(BaseMapPath, SourceCodeProjectFolderPath, new ConstantGeneratorOptions
          {
            IncludeCode = true
          });
          break;
        case ConsoleKey.D2:
          Build(BaseMapPath, SourceCodeProjectFolderPath, false, config);
          break;
        case ConsoleKey.D3:
          Build(BaseMapPath, SourceCodeProjectFolderPath, true, config);
          break;
        case ConsoleKey.D4:
          Build(TestMapPath, TestSourceCodeProjectFolderPath, true, config);
          break;
        default:
          Console.WriteLine($"{Environment.NewLine}Invalid input. Please choose again.");
          MakeDecision(config);
          break;
      }
    }

    /// <summary>
    ///   Builds the Warcraft 3 map.
    /// </summary>
    private static void Build(string baseMapPath, string projectFolderPath, bool launch, IConfiguration config)
    {
      // Ensure these folders exist
      Directory.CreateDirectory(AssetsFolderPath);
      Directory.CreateDirectory(OutputFolderPath);

      // Load existing map data
      var map = Map.Open(baseMapPath);

      FixDoodadData(map);
      var launchSettings = config.GetRequiredSection(nameof(LaunchSettings)).Get<LaunchSettings>();
      SetTestPlayerSlot(map, launchSettings.TestingPlayerSlot);
      var builder = new MapBuilder(map);
      builder.AddFiles(baseMapPath, "*", SearchOption.AllDirectories);
      builder.AddFiles(AssetsFolderPath, "*", SearchOption.AllDirectories);

      //ObjectEditor.SupplmentMapWithObjectData(map);

      // Set debug options if necessary, configure compiler
      const string csc = Debug ? "-debug -define:DEBUG" : null;
      var csproj = Directory.EnumerateFiles(projectFolderPath, "*.csproj", SearchOption.TopDirectoryOnly).Single();
      var compiler = new Compiler(csproj, OutputFolderPath, string.Empty, null,
        "War3Api.*;WCSharp.*;AzerothWarsCSharp.MacroTools.*", "", csc, false, null,
        string.Empty)
      {
        IsExportMetadata = true,
        IsModule = false,
        IsInlineSimpleProperty = false,
        IsPreventDebugObject = true,
        IsCommentsDisabled = !Debug
      };

      // Collect required paths and compile
      var coreSystemFiles = CoreSystemProvider.GetCoreSystemFiles();
      var blizzardJ = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "Warcraft III/JassHelper/Blizzard.j");
      var commonJ = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "Warcraft III/JassHelper/common.j");
      var compileResult = map.CompileScript(compiler, coreSystemFiles, blizzardJ, commonJ);

      // If compilation failed, output an error
      if (!compileResult.Success)
        throw new Exception(compileResult.Diagnostics.First(x => x.Severity == DiagnosticSeverity.Error).GetMessage());

      // Update war3map.lua so you can inspect the generated Lua code easily
      File.WriteAllText(Path.Combine(OutputFolderPath, OutputScriptName), map.Script);

      // Build w3x file
      var archiveCreateOptions = new MpqArchiveCreateOptions
      {
        BlockSize = 3,
        AttributesCreateMode = MpqFileCreateMode.Overwrite,
        ListFileCreateMode = MpqFileCreateMode.Overwrite
      };

      builder.Build(Path.Combine(OutputFolderPath, OutputMapName), archiveCreateOptions);
      if (launch) 
        LaunchGame(launchSettings);
    }

    /// <summary>
    ///   Makes all players prior to the given player slot computers,
    ///   so that the given player slot is what the tester will play as when the map is launched.
    /// </summary>
    private static void SetTestPlayerSlot(Map map, int playerSlot)
    {
      foreach (var player in map.Info.Players)
        if (player.Id < playerSlot)
          player.Controller = PlayerController.Computer;
    }

    private static void FixDoodadData(Map map)
    {
      if (map.Doodads != null)
      {
        var i = 0;
        foreach (var doodad in map.Doodads.Doodads)
        {
          doodad.CreationNumber = i;
          i++;
        }
      }
    }

    private static void LaunchGame(LaunchSettings launchSettings)
    {
      var wc3Exe = launchSettings.Warcraft3ExecutablePath;
      if (File.Exists(wc3Exe))
      {
        var commandLineArgs = new StringBuilder();
        var isReforged = Version.Parse(FileVersionInfo.GetVersionInfo(wc3Exe).FileVersion) >= new Version(1, 32);
        commandLineArgs.Append(isReforged ? " -launch" : $" -graphicsapi {GraphicsApi}");

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
}