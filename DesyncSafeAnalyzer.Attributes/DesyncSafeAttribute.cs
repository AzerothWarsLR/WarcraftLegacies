using System;
using System.Collections.Generic;
using System.Text;

namespace DesyncSafeAnalyzer.Attributes
{
  /// <summary>
  /// Marks the method as being safe to call from unsynchronized code without risk of desynchronizing clients.
  /// </summary>
  [AttributeUsage(AttributeTargets.Method)]
  public sealed class DesyncSafeAttribute : Attribute
  {
  }
}
