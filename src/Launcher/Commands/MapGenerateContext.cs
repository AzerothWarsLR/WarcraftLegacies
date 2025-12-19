using AutoMapper;
using Launcher.Services;

namespace Launcher.Commands;

internal sealed class MapGenerateContext : MapCommandContext
{
  public ConstantsGeneratorOptions GeneratorOptions { get; }

  public MapGenerateContext(string mapName) : base(mapName)
  {
    GeneratorOptions = ConstantsGeneratorOptions.Create(Paths);
  }

  /// <inheritdoc />
  public override void Execute()
  {
    var autoMapperConfig = AutoMapperConfigurationProvider.GetConfiguration();
    var mapper = new Mapper(autoMapperConfig);
    var conversionService = new MapDataToMapConverter(mapper);
    var (map, _) = conversionService.ConvertToMapAndAdditionalFiles(Paths.MapDataPath);

    var constantsGenerator = new ConstantsGenerator(GeneratorOptions);
    constantsGenerator.GenerateConstants(map);
  }
}
