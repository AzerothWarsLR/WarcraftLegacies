using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;

using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  /// Bring a unit to a location, where they will channel for some period of time. When it's over, the <see cref="QuestItemData"/> is completed.
  /// </summary>
  public sealed class QuestItemChannelRect : QuestItemData
  {
    private const string
      TARGET_EFFECT =
        "war3mapImported\\Fortitude Rune Aura.mdx";

    private readonly rect _targetRect;
    private readonly float _duration;
    private readonly Legend _targetLegend;
    private Channel? _channel;
    private readonly float _facing; //Which way the unit faces while it is channeling
    private readonly TriggerWrapper _entersRectTrig = new();

    public override Point Position => new(GetRectCenterX(_targetRect), GetRectCenterY(_targetRect));

    /// <summary>
    /// The Unit Type ID the entering unit must have to start channeling.
    /// </summary>
    public int RequiredUnitTypeId { private get; init; }

    private void OnRegionEnter()
    {
      var whichUnit = GetEnteringUnit();

      if (GetOwningPlayer(whichUnit) == Holder.Player && UnitAlive(whichUnit) &&
          Legend.GetFromUnit(GetTriggerUnit()) == _targetLegend && _channel == null &&
          Progress == QuestProgress.Incomplete)
      {
        if (RequiredUnitTypeId == 0 || RequiredUnitTypeId == GetUnitTypeId(GetTriggerUnit()))
        {
          _channel = new Channel(whichUnit, _duration, _facing, Position);
          _channel.Finished += OnChannelEnd;
        }
      }
    }

    private void OnChannelEnd(object? sender, Channel channel)
    {
      if (channel.FinishedWithoutInterruption)
      {
        Progress = QuestProgress.Complete;
      }

      channel.Finished -= OnChannelEnd;
      channel.Dispose();
    }

    public QuestItemChannelRect(Rectangle targetRect, string rectName, Legend whichLegend, float duration, float facing)
    {
      _targetRect = targetRect.Rect;
      region target = RectToRegion(_targetRect);
      _targetLegend = whichLegend;
      _duration = duration;
      Description = $"Have {whichLegend.Name} channel at {rectName} for {I2S(R2I(duration))} seconds";
      _facing = facing;

      MapEffectPath = TARGET_EFFECT;

      TriggerRegisterEnterRegion(_entersRectTrig.Trigger, target, null);
      TriggerAddAction(_entersRectTrig.Trigger, OnRegionEnter);
      DisplaysPosition = true;
    }
    
    
  }
}