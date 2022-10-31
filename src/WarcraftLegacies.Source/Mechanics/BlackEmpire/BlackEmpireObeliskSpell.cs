using MacroTools.ChannelSystem;
using MacroTools.ControlPointSystem;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Mechanics.BlackEmpire
{
  public sealed class BlackEmpireObeliskSpell : Spell
  {
    private readonly int _obeliskUnitTypeId;

    public BlackEmpireObeliskSpell(int id, int obeliskUnitTypeId) : base(id)
    {
      _obeliskUnitTypeId = obeliskUnitTypeId;
    }

    public float Duration { get; init; } = 10;

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      if (ControlPointManager.UnitIsControlPoint(target))
      {
        var controlPointTarget = ControlPointManager.GetFromUnitType(GetUnitTypeId(target));
        if (controlPointTarget == BlackEmpirePortalManager.CurrentObjective.NearbyControlPoint)
        {
          var channel = new BlackEmpireObeliskChannel(caster, Id, _obeliskUnitTypeId, controlPointTarget)
          {
            Duration = Duration
          };
          ChannelManager.Add(channel);
        }
      }
    }
  }
}