using System.CommandLine;
using Launcher.Commands;

namespace Launcher;

internal static class Program
{
  /// <summary>
  ///   Entry point for the program.
  /// </summary>
  private static int Main(string[] args)
  {
    var rootCommand = new RootCommand();
    rootCommand.RegisterMapDataToW3XCommand();
    rootCommand.RegisterW3XToMapDataCommand();
    rootCommand.RegisterCSharpToLuaCommand();
    return rootCommand.Invoke(args);
  }
}
