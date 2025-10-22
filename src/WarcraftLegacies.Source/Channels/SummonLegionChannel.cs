using MacroTools.ChannelSystem;

namespace WarcraftLegacies.Source.Channels;

public sealed class SummonLegionChannel : Channel
{
  private readonly int _spellImmunityId;
  private readonly timer _timer;
  private readonly timerdialog _timerDialog;

  public SummonLegionChannel(unit caster, int spellId, int spellImmunityId) : base(caster, spellId)
  {
    _spellImmunityId = spellImmunityId;
    _timer = timer.Create();
    _timerDialog = timerdialog.Create(_timer);
  }

  public override void OnCreate()
  {
    Caster.AddAbility(_spellImmunityId);
    _timer.Start(Duration, false, null);
    _timerDialog.IsDisplayed = true;
    _timerDialog.SetTitle("Legion Summon");
    PingMinimap(Caster.X, Caster.Y, 8);
    foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
    {
      player.DisplayTextTo("The Burning Legion is being summoned!");
    }
  }

  /// <inheritdoc />
  protected override void OnDispose()
  {
    Caster.RemoveAbility(_spellImmunityId);
    _timer.Dispose();
    _timerDialog.Dispose();
  }
}
