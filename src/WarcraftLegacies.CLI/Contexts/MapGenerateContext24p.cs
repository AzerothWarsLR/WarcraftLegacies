using Warcraft.Cartographer.Deserialization;
using Warcraft.Cartographer.Generation;
using WarcraftLegacies.CLI.Settings;

namespace WarcraftLegacies.CLI.Contexts;

internal sealed class MapGenerateContext24p : MapCommandContext
{
  public ConstantsGeneratorOptions GeneratorOptions { get; }

  public MapDataToMapConverterOptions SerializerOptions { get; }

  public MapGenerateContext24p(bool deleteDestination)
    : base("WarcraftLegacies24p", IncludeFromMap.All, deleteDestination)
  {
    GeneratorOptions = ConstantsGeneratorOptions.CreateFor24p(Paths);
    SerializerOptions = DefaultOptionsFactory.CreateMapDataToMapConverterOptions(Paths);
  }

  public override void Execute()
  {
    var conversionService = new MapDataToMapConverter(SerializerOptions);
    var (map, _) = conversionService.ConvertToMapAndAdditionalFiles();

    var generator = new ConstantsGenerator(GeneratorOptions);
    generator.GenerateConstants(map);
  }
}
