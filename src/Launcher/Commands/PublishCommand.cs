using System.CommandLine;
using Launcher.Services;

namespace Launcher.Commands
{
  public static class PublishCommand
  {
    public static void RegisterPublishCommand(this RootCommand rootCommand)
    {
      var command = new Command("publish", "Publish the map with the specified filename.");
      rootCommand.Add(command);

      var baseMapPathArgument = new Argument<string>(
        name: "basemappath",
        description: "The Warcraft 3 map to use as a base.");
      command.AddArgument(baseMapPathArgument);
      
      var sourceCodeFolderPathArgument = new Argument<string>(
        name: "sourcecodepath",
        description: "A directory containing the C# code to be included in the map.");
      command.AddArgument(sourceCodeFolderPathArgument);

      command.SetHandler(Run, baseMapPathArgument, sourceCodeFolderPathArgument);
    }

    private static void Run(string baseMapPath, string sourceCodeProjectFolderPath)
    {
      var config = Program.GetAppConfiguration();
      new MapBuilderService().Build(baseMapPath, sourceCodeProjectFolderPath, false, config);
    }
  }
}