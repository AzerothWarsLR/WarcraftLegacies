using System;
using System.CommandLine;
using Launcher.CLI.Contexts;

namespace Launcher.CLI.Commands;

internal sealed class MapCommand<T> : Command where T : MapCommandContext
{
  public Action<T> Configure { get; init; }

  public MapCommand(string name, string description = null) : base(name, description)
  {
    Argument<string> mapNameArg = new("map-name")
    {
      Description = "The directory containing the map."
    };

    Add(mapNameArg);

    SetAction(result =>
    {
      var ctx = CreateContext(result.GetValue(mapNameArg));
      Configure?.Invoke(ctx);
      ctx.Execute();
    });
  }

  private static T CreateContext(string mapName) => (T)Activator.CreateInstance(typeof(T), mapName);
}
