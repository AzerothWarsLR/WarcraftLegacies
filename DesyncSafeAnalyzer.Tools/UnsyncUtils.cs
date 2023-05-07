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
    /// Executes the specified function for player clients that meet a particular condition.
    /// </summary>
    /// <param name="functionToExecute">The function to be executed.</param>
    /// <param name="condition">The condition that the local machine must meet in order for the function to be executed.</param>
    public static void InvokeUnsync(Action functionToExecute, Func<player, bool> condition)
    {
      if (condition.Invoke(GetLocalPlayer()))
        functionToExecute();
    }
  }
}