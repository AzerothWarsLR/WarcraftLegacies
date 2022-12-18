using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Powers
{
  /// <summary>
  /// When the player's Control Points take damage, they summon some Treants.
  /// </summary>
  public sealed class ShaladrassilsBlessing : Power
  {
    /// <summary>
    /// How long the summoned units last.
    /// </summary>
    public float Duration { get; init; } = 60;

    /// <summary>
    /// How many units are summoned.
    /// </summary>
    public int SummonedUnitCount { get; init; } = 1;

    /// <summary>
    /// The cost applied to Shaladrassil when summoning units.
    /// </summary>
    public float ManaCost { get; init; } = 0;

    /// <summary>
    /// If Shaladrassil has this item, the Power summons twice as many units.
    /// </summary>
    public item? AmplifierItem { get; init; }

    private readonly unit _shaladrassil;
    private readonly int _summonedUnitTypeId;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShaladrassilsBlessing"/> class.
    /// </summary>
    /// <param name="shaladrassil">The unit that has to spend mana for the Power to work.</param>
    /// <param name="summonedUnitTypeId">The unit that is summoned.</param>
    public ShaladrassilsBlessing(unit shaladrassil, int summonedUnitTypeId)
    {
      _shaladrassil = shaladrassil;
      _summonedUnitTypeId = summonedUnitTypeId;
      Description =
        $"When a Control Point you control takes damage, consume {ManaCost} from {GetUnitName(shaladrassil)} to summon {SummonedUnitCount} {summonedUnitTypeId}s to defend it. If {_shaladrassil.GetName()} has {GetItemName(AmplifierItem)}, summon {_summonedUnitTypeId*2} instead.";
      Name = $"Blessing of {GetUnitName(shaladrassil)}";
    }

    /// <inheritdoc />
    public override void OnAdd(player whichPlayer)
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakesDamage, OnPlayerTakesDamage, GetPlayerId(whichPlayer));
    }

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer)
    {
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerTakesDamage, OnPlayerTakesDamage, GetPlayerId(whichPlayer));
    }

    private void OnPlayerTakesDamage()
    {
      if (!GetTriggerUnit().IsControlPoint() || !(_shaladrassil.GetMana() >= ManaCost))
        return;
      SummonTreants(GetTriggerUnit().OwningPlayer(), GetTriggerUnit().GetPosition());
      _shaladrassil.RestoreMana(-ManaCost);
    }

    private void SummonTreants(player owningPlayer, Point point)
    {
      var summonedUnitCount = UnitHasItem(_shaladrassil, AmplifierItem) ? SummonedUnitCount * 2 : SummonedUnitCount;
      for (var i = 0; i < summonedUnitCount; i++)
      {
        var treant = CreateUnit(owningPlayer, _summonedUnitTypeId, point.X, point.Y, 270)
          .SetTimedLife(60);
        AddSpecialEffect(@"Objects\Spawnmodels\NightElf\EntBirthTarget\EntBirthTarget.mdl", treant.GetPosition().X,
            treant.GetPosition().Y)
          .SetLifespan();
      }
    }
  }
}