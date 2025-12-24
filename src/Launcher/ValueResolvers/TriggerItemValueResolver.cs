using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Launcher.DataTransferObjects;
using War3Net.Build.Script;

namespace Launcher.ValueResolvers;

public sealed class TriggerItemValueResolver : IValueResolver<MapTriggersDto, MapTriggers, List<TriggerItem>>
{
  /// <inheritdoc />
  public List<TriggerItem> Resolve(MapTriggersDto source, MapTriggers destination, List<TriggerItem> destMember, ResolutionContext context) =>
    source.TriggerItems
      .Where(IsValid)
      .Select(ToTriggerItem)
      .ToList();

  private static bool IsValid(TriggerItemDto triggerItemDto) => triggerItemDto.Name != "<DELETED>";

  private static TriggerItem ToTriggerItem(TriggerItemDto triggerItemDto)
  {
    return triggerItemDto.Type switch
    {
      TriggerItemType.RootCategory => ToTriggerCategoryDefinition(triggerItemDto),
      TriggerItemType.UNK1 => ToTriggerDefinition(triggerItemDto),
      TriggerItemType.Category => ToTriggerCategoryDefinition(triggerItemDto),
      TriggerItemType.Gui => ToTriggerDefinition(triggerItemDto),
      TriggerItemType.Comment => ToTriggerDefinition(triggerItemDto),
      TriggerItemType.Script => ToTriggerDefinition(triggerItemDto),
      TriggerItemType.Variable => ToTriggerVariableDefinition(triggerItemDto),
      TriggerItemType.UNK7 => ToTriggerDefinition(triggerItemDto),
      _ => throw new ArgumentOutOfRangeException(nameof(triggerItemDto))
    };
  }

  private static TriggerDefinition ToTriggerDefinition(TriggerItemDto triggerItemDto)
  {
    return new TriggerDefinition
    {
      Name = triggerItemDto.Name,
      Id = triggerItemDto.Id,
      ParentId = triggerItemDto.ParentId,
      Description = triggerItemDto.IsDescription,
      IsComment = triggerItemDto.IsComment,
      IsEnabled = triggerItemDto.IsEnabled,
      IsCustomTextTrigger = triggerItemDto.IsCustomTextTrigger,
      IsInitiallyOn = triggerItemDto.IsInitiallyOn,
      RunOnMapInit = triggerItemDto.RunOnMapInit,
      Functions = triggerItemDto.Functions ?? []
    };
  }

  private static TriggerCategoryDefinition ToTriggerCategoryDefinition(TriggerItemDto triggerItemDto)
  {
    return new TriggerCategoryDefinition
    {
      Name = triggerItemDto.Name,
      Id = triggerItemDto.Id,
      ParentId = triggerItemDto.ParentId,
      IsComment = triggerItemDto.IsComment,
      IsExpanded = false
    };
  }

  private static TriggerVariableDefinition ToTriggerVariableDefinition(TriggerItemDto triggerItemDto)
  {
    return new TriggerVariableDefinition
    {
      Name = triggerItemDto.Name,
      Id = triggerItemDto.Id,
      ParentId = triggerItemDto.ParentId
    };
  }
}
