using MacroTools.Channels;
using MacroTools.Extensions;
using MacroTools.Instances;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Legion.Spells;

public sealed class SummonLegion : Spell
{
  private readonly int _spellImmunityId;

  public float Duration { get; set; } = 180;

  /// <inheritdoc />
  public override void OnStartCast(unit caster, unit target, Point targetPoint)
  {
    if (InstanceSystem.GetPointInstance(caster.GetPosition()) == null)
    {
      return;
    }

    timer.Create().Start(1f, false, () =>
    {
      caster.IssueOrder("stop");
      @event.ExpiredTimer.Dispose();
    });
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var channel = new SummonLegionChannel(caster, Id, _spellImmunityId)
    {
      Duration = Duration
    };
    ChannelManager.Add(channel);
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="SummonLegion"/> class.
  /// </summary>
  /// <param name="id"><inheritdoc /></param>
  /// <param name="spellImmunityId">An ability ID that grants the caster Spell Immunity.</param>
  public SummonLegion(int id, int spellImmunityId) : base(id)
  {
    _spellImmunityId = spellImmunityId;
  }
}

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
