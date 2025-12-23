using System.CommandLine;
using Launcher.CLI;

namespace Launcher;

internal static class Program
{
  private static int Main(string[] args)
  {
    return Create().Parse(args).Invoke();
  }

  private static RootCommand Create()
  {
    return
    [
      new Command("json-to-w3x")
      {
        MapCommandBuilder.Build(),
        MapCommandBuilder.Test(),
        MapCommandBuilder.Publish()
      },

      new Command("w3x-to-json")
      {
        MapCommandBuilder.Serialize()
      },

      new Command("generate")
      {
        MapCommandBuilder.Generate()
      }
    ];
  }
}
