using AzerothWarsCSharp.MacroTools.ChannelSystem;

namespace AzerothWarsCSharp.MacroTools.Channels
{
  public sealed class SummonLegionChannel : SimpleChannel
  {
    private readonly int _spellImmunityId;
    private readonly timer _timer;
    private readonly timerdialog _timerDialog;

    protected override void OnApply()
    {
      UnitAddAbility(Caster, _spellImmunityId);
      TimerStart(_timer, Duration, false, null);
      TimerDialogDisplay(_timerDialog, true);
      TimerDialogSetTitle(_timerDialog, "Legion Summon");
      PingMinimap(GetUnitX(Caster), GetUnitY(Caster), 8);
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "The Burning Legion is being summoned!");
    }

    protected override void OnDispose()
    {
      UnitRemoveAbility(Caster, _spellImmunityId);
      DestroyTimer(_timer);
      DestroyTimerDialog(_timerDialog);
    }

    public SummonLegionChannel(unit caster, int spellId, int spellImmunityId) : base(caster, spellId)
    {
      _spellImmunityId = spellImmunityId;
      _timer = CreateTimer();
      _timerDialog = CreateTimerDialog(_timer);
    }
  }
}