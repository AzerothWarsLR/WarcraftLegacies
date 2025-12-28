using System.CommandLine;
using WarcraftLegacies.CLI.Commands;

namespace WarcraftLegacies.CLI;

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
        MapCommandFactory.Build(),
        MapCommandFactory.Test(),
        MapCommandFactory.Publish()
      },

      new Command("w3x-to-json")
      {
        MapCommandFactory.Serialize()
      },

      new Command("generate")
      {
        MapCommandFactory.Generate()
      }
    ];
  }
}
