using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

using War3Net.Build;

namespace War3Map.Template.Launcher
{
    internal static class Program
    {
        // Input
        private const string SourceCodeProjectFolderPath = @"..\..\..\..\War3Map.Template.Source";
        private const string AssetsFolderPath = @".\Assets\";

        // Output
        private const string OutputFolderPath = @"..\..\..\..\artifacts";
        private const string OutputMapName = @"Testmap.w3x";

        // Warcraft III
        private const string Warcraft3ExecutableFilePath = null;
        private const string GraphicsApi = "Direct3D9";
        private const bool PauseGameOnLoseFocus = false;

        private static void Main()
        {
            // Build and launch
            var mapBuilder = new LegacyMapBuilder(OutputMapName);
            var options = CompilerOptions.GetCompilerOptions(SourceCodeProjectFolderPath, OutputFolderPath);

            var buildResult = mapBuilder.Build(options, AssetsFolderPath);
            if (buildResult.Success)
            {
                var mapPath = Path.Combine(OutputFolderPath, OutputMapName);
                var absoluteMapPath = new FileInfo(mapPath).FullName;

#if DEBUG
                if (Warcraft3ExecutableFilePath != null)
                {
                    var commandLineArgs = new StringBuilder();
                    var isReforged = Version.Parse(FileVersionInfo.GetVersionInfo(Warcraft3ExecutableFilePath).FileVersion) >= new Version(1, 32);
                    if (isReforged)
                    {
                        commandLineArgs.Append("-launch ");
                    }
                    else if (GraphicsApi != null)
                    {
                        commandLineArgs.Append($"-graphicsapi {GraphicsApi} ");
                    }

                    if (!PauseGameOnLoseFocus)
                    {
                        commandLineArgs.Append("-nowfpause ");
                    }

                    commandLineArgs.Append($"-loadfile \"{absoluteMapPath}\"");

                    Process.Start(Warcraft3ExecutableFilePath, commandLineArgs.ToString());
                }
                else
#endif
                {
                    Process.Start("explorer.exe", $"/select, \"{absoluteMapPath}\"");
                }
            }
            else
            {
                throw new Exception(buildResult.Diagnostics.Where(diagnostic => diagnostic.Severity == Microsoft.CodeAnalysis.DiagnosticSeverity.Error).First().GetMessage());
            }
        }
    }
}