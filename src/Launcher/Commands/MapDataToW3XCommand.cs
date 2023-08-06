using System.CommandLine;

namespace Launcher.Commands
{
  public static class MapDataToW3XCommand
  {
    public static void RegisterMapDataToW3XCommand(this RootCommand rootCommand)
    {
      var command = new Command("mapdata-to-w3x", "Converts raw map data into a Warcraft 3 map.");
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

    private static void Run()
    {
      
    }
  }
}