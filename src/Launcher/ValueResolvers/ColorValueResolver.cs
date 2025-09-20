using System.Drawing;
using AutoMapper;
using Launcher.DataTransferObjects;
using Region = War3Net.Build.Environment.Region;

namespace Launcher.ValueResolvers;

/// <summary>
/// Allow a <see cref="RegionDto"/>'s <see cref="RegionDto.Color"/> to be converted into a <see cref="Region"/>'s
/// equivalent <see cref="Region.Color"/>.
/// </summary>
public sealed class ColorValueResolver : IValueResolver<RegionDto, Region, Color>
{
  /// <inheritdoc />
  public Color Resolve(RegionDto source, Region destination, Color destMember, ResolutionContext context)
  {
    var sourceColor = source.Color;
    return Color.FromArgb(sourceColor.A, sourceColor.R, sourceColor.G, sourceColor.B);
  }
}
