using System;
using static War3Api.Common;

namespace DesyncSafeAnalyzer.Attributes
{
  /// <summary>
  /// Provides methods that make it easier to safely call unsynchronized code.
  /// </summary>
  public static class UnsyncUtils
  {
    /// <summary>
    /// Executes the specified function for a specific client.
    /// </summary>
    /// <param name="functionToExecute">The function to be executed.</param>
    /// <param name="whichPlayer">The client to execute the function for.</param>
    public static void InvokeForClient(Action functionToExecute, player whichPlayer)
    {
      if (GetLocalPlayer() == whichPlayer)
        functionToExecute();
    }

    /// <summary>
    /// Creates and returns a special effect, which can have a different model per client.
    /// </summary>
    /// <param name="modelNameFunction">A function that determines the model of the effect based on characteristics of the local player.</param>
    /// <param name="x">The x position of the effect.</param>
    /// <param name="y">The y position of the effect.</param>
    public static effect AddSpecialEffectUnsync(Func<player, string> modelNameFunction, float x, float y) =>
      AddSpecialEffect(modelNameFunction(GetLocalPlayer()), x, y);
    
    /// <summary>
    /// Creates and returns a special effect, which can have a different model per client.
    /// </summary>
    /// <param name="modelNameFunction">A function that determines the model of the effect based on characteristics of the local player.</param>
    /// <param name="targetWidget">The thing to attach the effect to.</param>
    /// <param name="attachPointName">Where to attach the effect.</param>
    public static effect AddSpecialEffectTargetUnsync(Func<player, string> modelNameFunction, widget targetWidget, string attachPointName) =>
      AddSpecialEffectTarget(modelNameFunction(GetLocalPlayer()), targetWidget, attachPointName);
  }
}