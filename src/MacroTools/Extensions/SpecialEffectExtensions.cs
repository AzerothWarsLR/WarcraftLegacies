using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace MacroTools.Extensions
{
  /// <summary>
  /// Provides a useful set of extension methods for Warcraft 3 effects,
  /// which are purely visual representations of game models.
  /// </summary>
  public static class SpecialEffectExtensions
  {
    /// <summary>
    /// Sets the size of the effect.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static effect SetScale(this effect effect, float scale)
    {
      BlzSetSpecialEffectScale(effect, scale);
      return effect;
    }

    /// <summary>
    /// Sets the effect's yaw rotation instantly.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static effect SetYaw(this effect effect, float yaw)
    {
      BlzSetSpecialEffectYaw(effect, yaw);
      return effect;
    }
    
    /// <summary>
    /// Sets the effect's alpha level, determing how visible it is.
    /// <para>255 is fully visible, 0 is invisible.</para>
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static effect SetAlpha(this effect effect, int alpha)
    {
      BlzSetSpecialEffectAlpha(effect, alpha);
      return effect;
    }
    
    /// <summary>
    /// Sets how quickly an animation progresses.
    /// <para>1 is full speed, 0 is paused.</para>
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static effect SetTimeScale(this effect effect, float scale)
    {
      BlzSetSpecialEffectTimeScale(effect, scale);
      return effect;
    }
    
    /// <summary>
    /// Sets the effect's color.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static effect SetColor(this effect effect, int red, int green, int blue)
    {
      BlzSetSpecialEffectColor(effect, red, green, blue);
      return effect;
    }
    
    /// <summary>
    /// Sets the effect's color to be the same as the provided player's.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static effect SetColor(this effect effect, player playerToCopy)
    {
      BlzSetSpecialEffectColorByPlayer(effect, playerToCopy);
      return effect;
    }

    /// <summary>
    /// Causes the effect to be removed after the provided duration has elapsed.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static effect SetLifespan(this effect effect, float lifespan = 0.03125F)
    {
      EffectSystem.Add(effect, lifespan);
      return effect;
    }

    /// <summary>
    /// Sets the effect's height above the ground.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static effect SetHeight(this effect effect, float height)
    {
      BlzSetSpecialEffectHeight(effect, height);
      return effect;
    }
    
    /// <summary>
    /// Sets the effect's position in the game world.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static effect SetPosition(this effect effect, Point point)
    {
      BlzSetSpecialEffectPosition(effect, point.X, point.Y, 0);
      return effect;
    }

    /// <summary>
    /// Destroys the effect.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static effect Destroy(this effect effect)
    {
      DestroyEffect(effect);
      return effect;
    }
  }
}