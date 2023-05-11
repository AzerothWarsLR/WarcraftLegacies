using System;

namespace DesyncSafeAnalyzer.Tools
{
  /// <summary>
  /// Marks the method as being safe to call from unsynchronized code without risk of desynchronizing clients.
  /// </summary>
  [AttributeUsage(AttributeTargets.Method)]
  public sealed class DesyncSafeAttribute : Attribute
  {
  }
}
