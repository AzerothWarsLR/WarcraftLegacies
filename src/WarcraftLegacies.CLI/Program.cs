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
      },

      // One published map can carry several languages. A build made with `--locale` is folded into the published
      // map by `merge-locales`, and `locales` reports which language each file of the result is stored for. Both
      // were written but never registered here, so neither could be run.
      MapCommandFactory.MergeLocales(),
      MapCommandFactory.Locales()
    ];
  }
}
