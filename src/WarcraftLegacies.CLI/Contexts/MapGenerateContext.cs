using Warcraft.Cartographer.Deserialization;
using Warcraft.Cartographer.Generation;
using WarcraftLegacies.CLI.Settings;

namespace WarcraftLegacies.CLI.Contexts;

internal sealed class MapGenerateContext : MapCommandContext
{
  public ConstantsGeneratorOptions GeneratorOptions { get; }

  public MapDataToMapConverterOptions SerializerOptions { get; }

  public MapGenerateContext(string mapName, IncludeFromMap include, bool deleteDestination) : base(mapName, include, deleteDestination)
  {
    GeneratorOptions = ConstantsGeneratorOptions.Create(Paths);
    SerializerOptions = DefaultOptionsFactory.CreateMapDataToMapConverterOptions(Paths);
  }

  /// <inheritdoc />
  public override void Execute()
  {
    var conversionService = new MapDataToMapConverter(SerializerOptions);
    var (map, _) = conversionService.ConvertToMapAndAdditionalFiles();

    var constantsGenerator = new ConstantsGenerator(GeneratorOptions);
    constantsGenerator.GenerateConstants(map);
  }
}
