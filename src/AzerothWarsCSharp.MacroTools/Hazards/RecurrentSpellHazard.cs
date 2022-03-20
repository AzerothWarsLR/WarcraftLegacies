using AzerothWarsCSharp.MacroTools.SpellSystem;

namespace AzerothWarsCSharp.MacroTools.Hazards
{
  public sealed class RecurrentSpellHazard : Hazard
  {
    public override bool Active { get; set; }

    private readonly int _dummySpellId;
    private readonly string _dummySpellOrder;
    private readonly int _level;

    protected override void OnPeriodic()
    {
      DummyCast.DummyCastPoint(GetOwningPlayer(Caster), _dummySpellId, _dummySpellOrder, _level, X, Y);
    }

    public override void OnCreate()
    {
      DummyCast.DummyCastPoint(GetOwningPlayer(Caster), _dummySpellId, _dummySpellOrder, _level, X, Y);
    }
    
    public RecurrentSpellHazard(string effectPath, unit caster, float x, float y, string dummySpellOrder, int level,
      int dummySpellId) : base(effectPath, caster, x, y)
    {
      _dummySpellOrder = dummySpellOrder;
      _level = level;
      _dummySpellId = dummySpellId;
    }
  }
}