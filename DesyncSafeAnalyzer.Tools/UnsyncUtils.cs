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
    [DesyncSafe]
    public static void InvokeUnsync(Action functionToExecute, player whichPlayer)
    {
      if (GetLocalPlayer() == whichPlayer)
        functionToExecute();
    }
  }
}