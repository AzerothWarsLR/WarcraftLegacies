using Warcraft.Cartographer.Deserialization;
using Warcraft.Cartographer.Serialization;

namespace WarcraftLegacies.CLI.Contexts;

internal sealed class MapSerializationContext : MapCommandContext
{
  public W3XToMapDataConverterOptions Options { get; }

  public MapSerializationContext(string mapName, IncludeFromMap include, bool deleteDestination) : base(mapName, include, deleteDestination)
  {
    Options = W3XToMapDataConverterOptions.Create(Paths);
    Options.IncludeFromMap = include;
    Options.DeleteDestinations = deleteDestination;
  }

  public override void Execute()
  {
    var converter = new W3XToMapDataConverter(Options);
    converter.Convert(Paths.W3XFolderPath);
  }
}
