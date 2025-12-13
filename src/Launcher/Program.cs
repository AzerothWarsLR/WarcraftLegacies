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
    rootCommand.RegisterJsonToW3XCommand();
    rootCommand.RegisterW3XToJsonCommand();
    rootCommand.RegisterCSharpToLuaCommand();
    rootCommand.RegisterPublishCommand();
    rootCommand.RegisterTestCommand();
    return rootCommand.Invoke(args);
  }
}
