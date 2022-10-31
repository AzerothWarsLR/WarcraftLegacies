using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static WarcraftLegacies.MacroTools.Libraries.GeneralHelpers;

namespace WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  ///   Bring a unit to a location, where they will channel for some period of time. When it's over, the
  ///   <see cref="Objective" /> is completed.
  /// </summary>
  public sealed class ObjectiveChannelRect : Objective
  {
    private const string
      TARGET_EFFECT =
        "war3mapImported\\Fortitude Rune Aura.mdx";

    private readonly float _duration;
    private readonly TriggerWrapper _entersRectTrig = new();
    private readonly float _facing; //Which way the unit faces while it is channeling
    private readonly Legend _targetLegend;

    private readonly rect _targetRect;
    private Channel? _channel;

    public ObjectiveChannelRect(Rectangle targetRect, string rectName, Legend whichLegend, float duration, float facing)
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

    public override Point Position => new(GetRectCenterX(_targetRect), GetRectCenterY(_targetRect));

    /// <summary>
    ///   The Unit Type ID the entering unit must have to start channeling.
    /// </summary>
    public int RequiredUnitTypeId { private get; init; }

    private void OnRegionEnter()
    {
      var whichUnit = GetEnteringUnit();

      if (EligibleFactions.Contains(GetOwningPlayer(whichUnit)) && UnitAlive(whichUnit) &&
          Legend.GetFromUnit(GetTriggerUnit()) == _targetLegend && _channel == null &&
          Progress == QuestProgress.Incomplete)
        if (RequiredUnitTypeId == 0 || RequiredUnitTypeId == GetUnitTypeId(GetTriggerUnit()))
        {
          _channel = new Channel(whichUnit, _duration, _facing, Position);
          _channel.Finished += OnChannelEnd;
        }
    }

    private void OnChannelEnd(object? sender, Channel channel)
    {
      if (channel.FinishedWithoutInterruption) Progress = QuestProgress.Complete;

      channel.Finished -= OnChannelEnd;
      channel.Dispose();
    }
  }
}