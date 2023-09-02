using War3Net.Build.Common;
using War3Net.Build.Info;

namespace Launcher.DataTransferObjects
{
  public sealed class PlayerDataDto
  {
    public int Id { get; set; }

    public PlayerController Controller { get; set; }

    public PlayerRace Race { get; set; }

    public PlayerFlags Flags { get; set; }

    public string Name { get; set; }

    public Vector2Dto StartPosition { get; set; }

    public Bitmask32 AllyLowPriorityFlags { get; set; }

    public Bitmask32 AllyHighPriorityFlags { get; set; }

    public Bitmask32 EnemyLowPriorityFlags { get; set; }

    public Bitmask32 EnemyHighPriorityFlags { get; set; }

    public override string ToString() => Name;
  }
}