using System;

namespace DesyncSafeAnalyzer.Attributes
{
  /// <summary>
  /// Indicates the property can be set to a given value for some set of clients, and a different value for other clients.
  /// <para>Accessing this variable from a function that is not desync-safe may cause a desynchronization.</para>
  /// </summary>
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
  public sealed class Desynchronizable : Attribute
  {
  }
}