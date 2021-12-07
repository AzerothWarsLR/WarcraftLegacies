using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  /// <summary>
  ///   A unique item. Artifacts appear in the Artifact Menu and can be targets of Quest Objectives.
  /// </summary>
  public class Artifact
  {
    private const float PingDuration = 3;
    private readonly item _item;

    public Artifact(item item)
    {
      _item = item;
    }

    public string IconPath => BlzGetItemIconPath(_item);

    public float FalseX { get; set; } = 0;

    public float FalseY { get; set; } = 0;

    public unit? OwningUnit => null;

    public player? Owner { get; }

    public Faction? OwningFaction { get; }

    public string Name => GetItemName(_item);

    public ArtifactStatus Status { get; }

    public void Ping(player whichPlayer)
    {
      if (GetLocalPlayer() == whichPlayer)
      {
        if (Status == ArtifactStatus.Special)
        {
          PingMinimap(FalseX, FalseY, PingDuration);
          return;
        }

        if (OwningUnit != null)
        {
          PingMinimap(GetUnitX(OwningUnit), GetUnitY(OwningUnit), PingDuration);
          return;
        }

        PingMinimap(GetItemX(_item), GetItemY(_item), PingDuration);
      }
    }

    public event EventHandler<ArtifactEventArgs>? OwnerChanged;

    public event EventHandler<ArtifactEventArgs>? StatusChanged;

    ~Artifact()
    {
      RemoveItem(_item);
    }
  }
}