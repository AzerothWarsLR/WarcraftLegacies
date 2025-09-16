namespace MacroTools.Extensions
{
  public static class PlayerSoundExtensions
  {
    /// <summary>
    /// Plays the specified sound for the player.
    /// </summary>
    public static void PlaySound(this player whichPlayer, sound sound)
    {
      if (GetLocalPlayer() == whichPlayer)
        StartSound(sound);
    }

    /// <summary>
    /// Plays the specified music for the player.
    /// </summary>
    public static void PlayMusicThematic(this player whichPlayer, string musicPath)
    {
      if (GetLocalPlayer() == whichPlayer)
        PlayThematicMusic(musicPath);
    }
  }
}