using War3Net.Build.Info;

namespace Launcher.DataTransferObjects;

public sealed class PlayerDataDto
{
  public int Id { get; set; }

  public PlayerController Controller { get; set; }

  public PlayerRace Race { get; set; }

  public PlayerFlags Flags { get; set; }

  public string Name { get; set; }

  public Vector2Dto StartPosition { get; set; }

  public int AllyLowPriorityFlags { get; set; }

  public int AllyHighPriorityFlags { get; set; }

  public int EnemyLowPriorityFlags { get; set; }

  public int EnemyHighPriorityFlags { get; set; }

  public override string ToString() => Name;
}
