using WCSharp.Effects;
using WCSharp.Shared.Data;
using static War3Api.Common;

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
    public static void SetScale(this effect effect, float scale)
    {
      BlzSetSpecialEffectScale(effect, scale);
    }

    /// <summary>
    /// Sets the effect's yaw rotation instantly.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static void SetYaw(this effect effect, float yaw)
    {
      BlzSetSpecialEffectYaw(effect, yaw);
    }
    
    /// <summary>
    /// Sets the effect's alpha level, determing how visible it is.
    /// <para>255 is fully visible, 0 is invisible.</para>
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static void SetAlpha(this effect effect, int alpha)
    {
      BlzSetSpecialEffectAlpha(effect, alpha);
    }
    
    /// <summary>
    /// Sets how quickly an animation progresses.
    /// <para>1 is full speed, 0 is paused.</para>
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static void SetTimeScale(this effect effect, float scale)
    {
      BlzSetSpecialEffectTimeScale(effect, scale);
    }
    
    /// <summary>
    /// Sets the effect's color.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static void SetColor(this effect effect, int red, int green, int blue)
    {
      BlzSetSpecialEffectColor(effect, red, green, blue);
    }
    
    /// <summary>
    /// Sets the effect's color to be the same as the provided player's.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static void SetColor(this effect effect, player playerToCopy)
    {
      BlzSetSpecialEffectColorByPlayer(effect, playerToCopy);
    }

    /// <summary>
    /// Causes the effect to be removed after the provided duration has elapsed.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static void SetLifespan(this effect effect, float lifespan = 0.03125F)
    {
      EffectSystem.Add(effect, lifespan);
    }

    /// <summary>
    /// Sets the effect's height above the ground.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static void SetHeight(this effect effect, float height)
    {
      BlzSetSpecialEffectHeight(effect, height);
    }
    
    /// <summary>
    /// Sets the effect's position in the game world.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static void SetPosition(this effect effect, Point point)
    {
      BlzSetSpecialEffectPosition(effect, point.X, point.Y, 0);
    }

    /// <summary>
    /// Destroys the effect.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static void Destroy(this effect effect)
    {
      DestroyEffect(effect);
    }
  }
}