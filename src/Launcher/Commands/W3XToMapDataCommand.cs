using System.CommandLine;

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