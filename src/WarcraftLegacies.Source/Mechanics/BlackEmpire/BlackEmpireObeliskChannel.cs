using System;
using MacroTools.ChannelSystem;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.Libraries;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Mechanics.BlackEmpire
{
  public sealed class BlackEmpireObeliskChannel : SimpleChannel
  {
    private const string PROGRESS_EFFECT = "war3mapImported\\Progressbar10sec.mdx";
    private const float PROGRESS_SCALE = 1.5f;
    private const float PROGRESS_HEIGHT = 125f;

    private readonly int _obeliskUnitTypeId;
    private readonly ControlPoint _target;
    private bool _finished; //True if the Channel completed sucessfully
    private unit? _obelisk;
    private effect? _sfxProgress;

    public BlackEmpireObeliskChannel(unit caster, int spellId, int obeliskUnitTypeId, ControlPoint target) : base(
      caster, spellId)
    {
      _obeliskUnitTypeId = obeliskUnitTypeId;
      _target = target;
    }

    public static event EventHandler<ControlPoint>? ObeliskSummoned;

    protected override void OnDispose()
    {
      if (!_finished)
      {
        RemoveUnit(_obelisk);
      }

      BlzSetSpecialEffectPosition(_sfxProgress, -100000, -100000,
        0); //Has no death animation so needs to be moved off the map
      DestroyEffect(_sfxProgress);
      SetUnitInvulnerable(Caster, true);
    }

    protected override void OnExpire()
    {
      _finished = true;
      ObeliskSummoned?.Invoke(this, _target);
    }

    protected override void OnApply()
    {
      var controlPointPosition = _target.Unit.GetPosition();
      _obelisk = CreateUnit(Caster.OwningPlayer(), _obeliskUnitTypeId, controlPointPosition.X, controlPointPosition.Y,
        0);
      SetUnitInvulnerable(Caster, false);
      SetUnitOwner(_target.Unit, Caster.OwningPlayer(), true);
      _sfxProgress = AddSpecialEffect(PROGRESS_EFFECT, controlPointPosition.X, controlPointPosition.Y);
      BlzSetSpecialEffectTimeScale(_sfxProgress, 10 / Duration);
      BlzSetSpecialEffectColorByPlayer(_sfxProgress, GetOwningPlayer(Caster));
      BlzSetSpecialEffectScale(_sfxProgress, PROGRESS_SCALE);
      BlzSetSpecialEffectHeight(_sfxProgress,
        PROGRESS_HEIGHT + GeneralHelpers.GetPositionZ(controlPointPosition.X, controlPointPosition.Y));
    }
  }
}