using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using MacroTools.Extensions;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests
{

  /// <summary>
  /// Repair the Thandol Span to make it walkabale again
  /// </summary>
  public class QuestThandolSpan : QuestData
  {

    private destructable ThandolSpan { get; }

    /// <inheritdoc />
    public QuestThandolSpan(PreplacedUnitSystem preplacedUnitSystem) : base("Thandol Span",
      "The massive stone bridges connecting the Wetlands of northern Khaz Modan with the Arathi Highlands of southeastern Lordaeron, known as the Thandol Span is one of the greatest engineering projects ever completed by the dwarves." +
      "The mighty bridges recently suffered heavy damage due to a Dark Iron. Repair them to connect the two areas once again.",
      BlzGetAbilityIcon(LegendSentinels.BlackrookHold.UnitType))
    {
      ThandolSpan = preplacedUnitSystem.GetDestructable(FourCC("LT08"), new Point(15695, 457));
      
      AddObjective(new ObjectiveUnitReachesFullHealth(LegendNeutral.ThandolSpanDestroyed.Unit));
      CreateTrigger()
        .RegisterUnitEvent(LegendNeutral.ThandolSpanDestroyed.Unit, EVENT_UNIT_DAMAGED)
        .AddAction(OnDamaged);
    }

    /// <inheritdoc />
    protected override string RewardFlavour =>
      "The mighty Thandol Span has been repaired.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Connect the Wetlands of northern Khaz Modan with the Arathi Highlands of southeastern Lordaeron";

    /// <inheritdoc />
    protected override void OnComplete(Faction whichFaction)
    {
      DestructableRestoreLife(ThandolSpan, GetDestructableMaxLife(ThandolSpan), true);
    }

    private void OnDamaged()
    {
      if (!(GetEventDamage() + 1 >= GetUnitState(LegendNeutral.ThandolSpanDestroyed.Unit, UNIT_STATE_LIFE))) return;
      BlzSetEventDamage(0);
      SetUnitState(LegendNeutral.ThandolSpanDestroyed.Unit, UNIT_STATE_LIFE, GetUnitState(LegendNeutral.ThandolSpanDestroyed.Unit, UNIT_STATE_MAX_LIFE) * 0.05f);
    }
  }
}
