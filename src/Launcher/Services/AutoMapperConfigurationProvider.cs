using System.Numerics;
using AutoMapper;
using Launcher.DataTransferObjects;
using War3Net.Build.Widget;

namespace Launcher.Services;

public sealed class AutoMapperConfigurationProvider
{
  public static MapperConfiguration GetConfiguration()
  {
    var autoMapperConfig = new MapperConfiguration(cfg =>
    {
      cfg.CreateMap<DoodadDataDto, DoodadData>().ReverseMap();
      cfg.CreateMap<Vector3Dto, Vector3>().ReverseMap();
    });
    return autoMapperConfig;
  }
}
