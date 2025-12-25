using Launcher.Services;

namespace Launcher.CLI.Contexts;

internal sealed class MapSerializationContext : MapCommandContext
{
  public W3XToMapDataConverterOptions Options { get; }

  public MapSerializationContext(string mapName) : base(mapName)
  {
    Options = W3XToMapDataConverterOptions.Create(Paths);
  }

  public override void Execute()
  {
    var converter = new W3XToMapDataConverter(W3XToMapDataConverterOptions.Create(Paths));
    converter.Convert(Paths.W3XFolderPath);
  }
}
