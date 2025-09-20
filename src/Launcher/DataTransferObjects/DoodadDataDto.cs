using System.Collections.Generic;
using War3Net.Build.Common;
using War3Net.Build.Widget;

namespace Launcher.DataTransferObjects;

public sealed class DoodadDataDto
{
  public DoodadState State { get; set; }

  public byte Life { get; set; }

  public int TypeId { get; set; }

  public int Variation { get; set; }

  public Vector3Dto Position { get; set; }

  public float Rotation { get; set; }

  public Vector3Dto Scale { get; set; }

  public int SkinId { get; set; }

  public int MapItemTableId { get; set; }

  public List<RandomItemSet> ItemTableSets { get; init; }

  public int CreationNumber { get; set; }
}
