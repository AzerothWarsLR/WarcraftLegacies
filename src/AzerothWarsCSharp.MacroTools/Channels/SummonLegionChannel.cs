using AzerothWarsCSharp.MacroTools.ChannelSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Channels
{
  public sealed class SummonLegionChannel : SimpleChannel
  {
    private readonly int _spellImmunityId;
    private readonly timer _timer;
    private readonly timerdialog _timerDialog;

    public override void OnApply()
    {
      UnitAddAbility(Caster, _spellImmunityId);
      TimerDialogDisplay(_timerDialog, true);
      TimerDialogSetTitle(_timerDialog, "Legion Summon");
      TimerStart(_timer, 180, false, null);
      var ability = BlzGetUnitAbility(Caster, SpellId);
      BlzGetAbilityRealLevelField(ability, ABILITY_RLF_DURATION_NORMAL, GetUnitAbilityLevel(Caster, SpellId));
      PingMinimap(GetUnitX(Caster), GetUnitY(Caster), 8);
    }

    public override void OnDispose()
    {
      UnitRemoveAbility(Caster, _spellImmunityId);
      DestroyTimer(_timer);
      DestroyTimerDialog(_timerDialog);
    }

    public override void OnExpire()
    {
      foreach (var player in GeneralHelpers.GetAllPlayers()) SetPlayerAbilityAvailable(player, SpellId, false);
    }

    public SummonLegionChannel(unit caster, int spellId, int spellImmunityId) : base(caster, spellId)
    {
      _spellImmunityId = spellImmunityId;
      _timer = CreateTimer();
      _timerDialog = CreateTimerDialog(_timer);
    }
  }
}