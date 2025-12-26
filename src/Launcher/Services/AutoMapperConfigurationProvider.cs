using AutoMapper;

namespace Launcher.Services;

public sealed class AutoMapperConfigurationProvider
{
  public static MapperConfiguration GetConfiguration()
  {
    var autoMapperConfig = new MapperConfiguration(cfg =>
    {
    });
    return autoMapperConfig;
  }
}
