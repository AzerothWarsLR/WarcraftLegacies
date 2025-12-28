using Warcraft.Cartographer.Paths;

namespace Warcraft.Cartographer.Deserialization;

public sealed class MapDataToMapConverterOptions
{
  public required MapDataPathOptions MapDataPaths { get; init; }
}
