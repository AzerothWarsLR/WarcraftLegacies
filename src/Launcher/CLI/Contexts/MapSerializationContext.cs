using AutoMapper;
using Launcher.Services;

namespace Launcher.CLI.Contexts;

internal sealed class MapSerializationContext(string mapName) : MapCommandContext(mapName)
{
  public override void Execute()
  {
    var converter = new W3XToMapDataConverter(new Mapper(AutoMapperConfigurationProvider.GetConfiguration()),
      W3XToMapDataConverterOptions.Create(Paths));
    converter.Convert(Paths.W3XFolderPath);
  }
}
