using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using MacroTools.Extensions;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;
using MacroTools;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests
{

  /// <summary>
  /// Repair the Thandol Span to make it walkabale again
  /// </summary>
  public sealed class QuestThandolSpan : QuestData
  {

    private readonly destructable _thandolSpan;
    private readonly unit _thandolSpanDestroyed;
    /// <inheritdoc />
    public QuestThandolSpan(PreplacedUnitSystem preplacedUnitSystem) : base("Thandol Span",
      "The massive stone bridges connecting the Wetlands of northern Khaz Modan with the Arathi Highlands of southeastern Lordaeron, known as the Thandol Span is one of the greatest engineering projects ever completed by the dwarves." +
      "The mighty bridges recently suffered heavy damage due to a Dark Iron. Repair them to connect the two areas once again.", "")//Add icon here
    {
      _thandolSpan = preplacedUnitSystem.GetDestructable(FourCC("LT08"), new Point(15695, 457));
      _thandolSpanDestroyed = preplacedUnitSystem.GetUnit(Constants.UNIT_H06G_THANDOL_SPAM_BRIDGE_NEUTRAL_HOSTILE, new Point(15695, 457));
      AddObjective(new ObjectiveUnitReachesFullHealth(_thandolSpanDestroyed));
      CreateTrigger()
        .RegisterUnitEvent(_thandolSpanDestroyed, EVENT_UNIT_DAMAGED)
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
      DestructableRestoreLife(_thandolSpan, GetDestructableMaxLife(_thandolSpan), true);
    }

    private void OnDamaged()
    {
      if (!(GetEventDamage() + 1 >= GetUnitState(_thandolSpanDestroyed, UNIT_STATE_LIFE))) return;
      BlzSetEventDamage(0);
      _thandolSpanDestroyed.SetLifePercent(0.05f);
    }
  }
}
