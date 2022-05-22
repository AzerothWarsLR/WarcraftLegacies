using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.SpellSystem
{
  public abstract class Spell
  {
    protected Spell(int id)
    {
      Id = id;
    }

    public int Id { get; }

    public virtual void OnLearn(unit learner)
    {
    }

    public virtual void OnStop(unit caster)
    {
      
    }
    
    public virtual void OnCast(unit caster, unit target, float targetX, float targetY)
    {
    }

    protected int GetAbilityLevel(unit whichUnit)
    {
      return GetUnitAbilityLevel(whichUnit, Id);
    }
  }
}