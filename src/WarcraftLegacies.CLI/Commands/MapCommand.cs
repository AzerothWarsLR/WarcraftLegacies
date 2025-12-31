using System;
using System.CommandLine;
using Warcraft.Cartographer.Deserialization;
using WarcraftLegacies.CLI.Contexts;

namespace WarcraftLegacies.CLI.Commands;

internal sealed class MapCommand<T> : Command where T : MapCommandContext
{
  public Action<T> Configure { get; init; }

  public MapCommand(string name, string description = null) : base(name, description)
  {
    Argument<string> mapNameArg = new("map-name")
    {
      Description = "The directory containing the map."
    };

    Option<IncludeFromMap> includeFromMapOption = new("--include")
    {
      Aliases = { "-i" },
      Description = "A list of flags to indicate what should be included in map conversion.",
      DefaultValueFactory = _ => IncludeFromMap.AllExceptScript
    };

    Option<bool> deleteDestinationOption = new("--delete-destination")
    {
      Aliases = { "-d" },
      Description = "If true, the output directories or files will be deleted prior to map conversion. Defaults to true.",
      DefaultValueFactory = _ => true
    };

    Add(mapNameArg);
    Add(includeFromMapOption);
    Add(deleteDestinationOption);

    SetAction(result =>
    {
      var includeFromMap = result.GetValue(includeFromMapOption);
      var deleteDestination = result.GetValue(deleteDestinationOption);

      var ctx = CreateContext(result.GetValue(mapNameArg), includeFromMap, deleteDestination);
      Configure?.Invoke(ctx);
      ctx.Execute();
    });
  }

  private static T CreateContext(string mapName, IncludeFromMap include, bool deleteDestination) =>
    (T)Activator.CreateInstance(typeof(T), mapName, include, deleteDestination);
}
