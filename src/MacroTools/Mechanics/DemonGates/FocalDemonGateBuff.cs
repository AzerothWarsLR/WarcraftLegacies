using System;
using WCSharp.Buffs;
using static War3Api.Common;

namespace MacroTools.Mechanics.DemonGates
{
  /// <summary>
  /// Units spawned at Demon Gates spawn at the Focal Demon Gate instead, if one exists.
  /// </summary>
  public sealed class FocalDemonGateBuff : PassiveBuff
  {
    /// <summary>
    /// The <see cref="FocalDemonGateBuff"/>. There can only ever be up to one in the game at a time.
    /// </summary>
    public static FocalDemonGateBuff? Instance { get; private set; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="FocalDemonGateBuff"/> class.
    /// </summary>
    /// <param name="target"><inheritdoc /></param>
    public FocalDemonGateBuff(unit target) : base(target, target)
    {
    }
    
    /// <inheritdoc />
    public override void OnApply()
    {
      if (Instance == null)
        Instance = this;
      else
        throw new Exception($"Tried to create a second {nameof(FocalDemonGateBuff)}. There can only be one.");
    }

    /// <inheritdoc />
    public override void OnDispose() => Instance = null;
  }
}