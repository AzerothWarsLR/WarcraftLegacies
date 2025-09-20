using System;
using System.Collections.Generic;
using Launcher.DataTransferObjects;
using War3Net.Build.Script;

namespace Launcher.Extensions;

public static class TriggerItemDtoExtensions
{
  public static TriggerItem ToTriggerItem(this TriggerItemDto triggerItemDto)
  {
    return triggerItemDto.Type switch
    {
      TriggerItemType.RootCategory => triggerItemDto.ToTriggerCategoryDefinition(),
      TriggerItemType.UNK1 => triggerItemDto.ToTriggerDefinition(),
      TriggerItemType.Category => triggerItemDto.ToTriggerCategoryDefinition(),
      TriggerItemType.Gui => triggerItemDto.ToTriggerDefinition(),
      TriggerItemType.Comment => triggerItemDto.ToTriggerDefinition(),
      TriggerItemType.Script => triggerItemDto.ToTriggerDefinition(),
      TriggerItemType.Variable => triggerItemDto.ToTriggerVariableDefinition(),
      TriggerItemType.UNK7 => triggerItemDto.ToTriggerDefinition(),
      _ => throw new ArgumentOutOfRangeException(nameof(triggerItemDto))
    };
  }

  private static TriggerItem ToTriggerDefinition(this TriggerItemDto triggerItemDto)
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
      Functions = triggerItemDto.Functions ?? new List<TriggerFunction>()
    };
  }

  private static TriggerCategoryDefinition ToTriggerCategoryDefinition(this TriggerItemDto triggerItemDto)
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

  private static TriggerVariableDefinition ToTriggerVariableDefinition(this TriggerItemDto triggerItemDto)
  {
    return new TriggerVariableDefinition
    {
      Name = triggerItemDto.Name,
      Id = triggerItemDto.Id,
      ParentId = triggerItemDto.ParentId
    };
  }
}
