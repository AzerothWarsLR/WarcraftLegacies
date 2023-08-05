using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Launcher.DataTransferObjects;
using Launcher.Extensions;
using War3Net.Build.Script;

namespace Launcher.ValueResolvers
{
  public sealed class TriggerItemValueResolver : IValueResolver<MapTriggersDto, MapTriggers, List<TriggerItem>>
  {
    /// <inheritdoc />
    public List<TriggerItem> Resolve(MapTriggersDto source, MapTriggers destination, List<TriggerItem> destMember, ResolutionContext context)
    {
      return source.TriggerItems.Select(x => x.ToTriggerItem()).ToList();
    }
  }
}