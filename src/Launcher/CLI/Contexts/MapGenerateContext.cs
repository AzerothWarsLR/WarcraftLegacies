using Launcher.Services;

namespace Launcher.CLI.Contexts;

internal sealed class MapGenerateContext : MapCommandContext
{
  public ConstantsGeneratorOptions GeneratorOptions { get; }

  public MapDataToMapConverterOptions SerializerOptions { get; }

  public MapGenerateContext(string mapName) : base(mapName)
  {
    GeneratorOptions = ConstantsGeneratorOptions.Create(Paths);
    SerializerOptions = MapDataToMapConverterOptions.Create(Paths);
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
