namespace MacroTools.Spells;

/// <summary>
/// Represents a method that determines whether a target unit should be affected by a spell cast by a specified caster.
/// </summary>
/// <param name="caster">The unit casting the spell.</param>
/// <param name="target">The unit to evaluate as a potential target.</param>
/// <returns>
/// <c>true</c> if the spell cast by <paramref name="caster"/> should affect <paramref name="target"/>; otherwise, <c>false</c>.
/// </returns>
public delegate bool CastFilter(unit caster, unit target);
