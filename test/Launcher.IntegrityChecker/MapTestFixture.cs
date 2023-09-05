using CSharpLua;
using Launcher.Services;
using Launcher.Settings;
using Microsoft.CodeAnalysis;
using War3Net.Build;
using War3Net.Build.Extensions;

namespace Launcher.IntegrityChecker
{
  public sealed class MapTestFixture
  {
    public Map Map { get; }

    public IEnumerable<PathData> ImportedFiles { get; }

    public MapTestFixture()
    {
      (Map, ImportedFiles) = MapDataProvider.GetMapData;
      AddCSharpCode(Map, @"..\..\..\..\WarcraftLegacies.Source\", @"..\..\..\..\..\\artifacts\");
    }
    
    private static void AddCSharpCode(Map map, string projectFolderPath, string artifactsPath)
    {
      var csproj = Directory.EnumerateFiles(projectFolderPath, "*.csproj", SearchOption.TopDirectoryOnly).Single();
      var compiler = new Compiler(csproj, artifactsPath, string.Empty, null!,
        "War3Api.*;WCSharp.*;MacroTools.*", "", null, false, null,
        string.Empty)
      {
        IsExportMetadata = true,
        IsModule = false,
        IsInlineSimpleProperty = false,
        IsPreventDebugObject = true,
        IsCommentsDisabled = true
      };
      
      var coreSystemFiles = CoreSystemProvider.GetCoreSystemFiles();
      var blizzardJ = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "Warcraft III/JassHelper/Blizzard.j");
      var commonJ = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "Warcraft III/JassHelper/common.j");
      var mapScriptBuilder = new MapScriptBuilder();
      mapScriptBuilder.SetDefaultOptionsForCSharpLua();
      mapScriptBuilder.ForceGenerateGlobalDestructableVariable = false;
      
      var compileResult = map.CompileScript(compiler, mapScriptBuilder, coreSystemFiles, blizzardJ, commonJ);
      
      if (!compileResult.Success)
        throw new Exception(compileResult.Diagnostics.First(x => x.Severity == DiagnosticSeverity.Error).GetMessage());
    }
  }
}