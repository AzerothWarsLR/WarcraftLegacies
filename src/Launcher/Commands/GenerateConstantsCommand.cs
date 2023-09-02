using System.CommandLine;
using WCSharp.ConstantGenerator;

namespace Launcher.Commands
{
  public static class GenerateConstantsCommand
  {
    public static void RegisterGenerateConstantsCommand(this RootCommand rootCommand)
    {
      var command = new Command("generate-constants", "Generates constants based on a Warcraft 3 map.");
      rootCommand.Add(command);

      var baseMapPathArgument = new Argument<string>(
        name: "basemappath",
        description: "The Warcraft 3 map from which to extract constants.");
      command.AddArgument(baseMapPathArgument);
      
      var sourceCodeFolderPathArgument = new Argument<string>(
        name: "outputpath",
        description: "Where to put the generated constants.");
      command.AddArgument(sourceCodeFolderPathArgument);

      command.SetHandler(Run, baseMapPathArgument, sourceCodeFolderPathArgument);
    }

    private static void Run(string baseMapPath, string sourceCodeProjectFolderPath)
    {
      ConstantGenerator.Run(baseMapPath, sourceCodeProjectFolderPath, new ConstantGeneratorOptions
      {
        IncludeCode = true
      });
    }
  }
}