using WCSharp.Shared.Data;

namespace MacroTools.Extensions;

public static class PlayerCameraExtensions
{
  /// <summary>
  /// Applies a particular camera field to the player's view.
  /// </summary>
  public static player ApplyCameraField(this player whichPlayer, camerafield whichField, float value, float duration)
  {
    if (player.LocalPlayer == whichPlayer)
    {
      SetCameraField(whichField, value, duration);
    }

    return whichPlayer;
  }

  public static player RepositionCamera(this player whichPlayer, float x, float y)
  {
    if (player.LocalPlayer == whichPlayer)
    {
      SetCameraPosition(x, y);
    }

    return whichPlayer;
  }

  public static player RepositionCamera(this player whichPlayer, Point position)
  {
    if (player.LocalPlayer == whichPlayer)
    {
      SetCameraPosition(position.X, position.Y);
    }

    return whichPlayer;
  }
}
