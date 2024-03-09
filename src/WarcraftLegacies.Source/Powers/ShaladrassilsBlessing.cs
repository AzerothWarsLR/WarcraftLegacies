using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Effects;
using WCSharp.Events;
using WCSharp.Shared.Data;


namespace WarcraftLegacies.Source.Powers
{
  /// <summary>
  /// When the player's Control Points take damage, they summon some Treants.
  /// </summary>
  public sealed class ShaladrassilsBlessing : Power
  {
    private readonly unit _shaladrassil;
    private readonly int _summonedUnitTypeId;
    private readonly float _duration;
    private readonly int _summonedUnitCount;
    private readonly int _manaCost;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShaladrassilsBlessing"/> class.
    /// </summary>
    /// <param name="shaladrassil">The unit that has to spend mana for the Power to work.</param>
    /// <param name="summonedUnitTypeId">The unit that is summoned.</param>
    /// <param name="duration">How long the summoned units last.</param>
    /// <param name="summonedUnitCount">How many units are summoned.</param>
    /// <param name="manaCost">The cost applied to Shaladrassil when summoning units.</param>
    public ShaladrassilsBlessing(unit shaladrassil, int summonedUnitTypeId, float duration, int summonedUnitCount, int manaCost)
    {
      _shaladrassil = shaladrassil;
      _summonedUnitTypeId = summonedUnitTypeId;
      _duration = duration;
      _summonedUnitCount = summonedUnitCount;
      _manaCost = manaCost;
      Description =
        $"When an undamaged Control Point you control takes damage and you control {shaladrassil.Name}, consume {_manaCost} mana from {GetUnitName(shaladrassil)} to summon {_summonedUnitCount} {GetObjectName(summonedUnitTypeId)}s to defend the Control Point for {_duration} seconds.";
      Name = $"{GetUnitName(shaladrassil)}'s Blessing";
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
      var owner = GetTriggerUnit().Owner;
      if (!GetTriggerUnit().IsControlPoint() 
          || _shaladrassil.Owner != owner
          || !(_shaladrassil.Mana >= _manaCost)
          || GetTriggerUnit().GetLifePercent() < 100)
        return;
      SummonTreants(owner, GetTriggerUnit().GetPosition());
      _shaladrassil.Mana += -_manaCost;
    }

    private void SummonTreants(player owningPlayer, Point point)
    {
      for (var i = 0; i < _summonedUnitCount; i++)
      {
        var treant = CreateUnit(owningPlayer, _summonedUnitTypeId, point.X, point.Y, 270);
        treant.ApplyTimedLife(0, _duration);
        treant.AddType(UNIT_TYPE_SUMMONED);
        treant.SetExploded(true);
        EffectSystem.Add(AddSpecialEffect(@"Objects\Spawnmodels\NightElf\EntBirthTarget\EntBirthTarget.mdl", treant.GetPosition().X,
          treant.GetPosition().Y), (float)0.03125);
      }
    }
  }
}