namespace MacroTools.GameModes;

/// <summary>A game mode that players can vote on. Once one is chosen, it determines the game's basic settings.</summary>
public interface IGameMode
{
  /// <summary>A user friendly name that players will see.</summary>
  public string Name { get; }

  /// <summary>Fired when this <see cref="IGameMode"/> is successfully voted on.</summary>
  public void OnChoose();
}
