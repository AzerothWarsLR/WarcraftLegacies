using AzerothWarsCSharp.MacroTools.ChannelSystem;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public sealed class BlackEmpireObeliskSpell : Spell
  {
    private readonly int _obeliskUnitTypeId;

    public BlackEmpireObeliskSpell(int id, int obeliskUnitTypeId) : base(id)
    {
      _obeliskUnitTypeId = obeliskUnitTypeId;
    }

    public float Duration { get; init; } = 10;

    public override void OnCast(unit caster, unit target, float targetX, float targetY)
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