using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  /// <summary>
  /// Draenei need to bring a unit to each of their bases to acquire them.
  /// </summary>
  public sealed class QuestWarnBase : QuestData
  {
    private readonly string _baseName;
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestWarnBase"/> class.
    /// </summary>
    /// <param name="baseRect">Units in this area will be made rescuable, then rescued when the quest is completed.</param>
    /// <param name="baseName">The name of the base that can be rescued.</param>
    /// <param name="icon"><inheritdoc /></param>
    public QuestWarnBase(Rectangle baseRect, string baseName, string icon) : base($"Warn {baseName}", $"The city of {baseName} has to be warned of the imminent Orc invasion.", icon)
    {
      _baseName = baseName;
      AddObjective(new ObjectiveAnyUnitInRect(baseRect, baseName, false));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = baseRect.PrepareUnitsForRescue(Player(PLAYER_NEUTRAL_PASSIVE),false,false);
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => $"The messenger has arrived. {_baseName} has been reached in time.";

    /// <inheritdoc />
    protected override string RewardDescription => $"Control of all buildings in {_baseName}";
    
    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player == null) 
        return;
      completingFaction.Player.RescueGroup(_rescueUnits);
      _rescueUnits.Clear();
    }
    
    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
      _rescueUnits.Clear();
    }
  }
}