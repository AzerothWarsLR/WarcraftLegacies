using System;

namespace MacroTools.Exceptions;

/// <summary>
/// The exception that is thrown when trying to initialize a system that has already been initialized.
/// </summary>
public sealed class SystemAlreadyInitializedException : Exception
{
  /// <summary>
  /// Initializes a new instance of the <see cref="SystemAlreadyInitializedException"/> class with a specified system name.
  /// </summary>
  public SystemAlreadyInitializedException(string systemName)
    : base($"Tried to initialize {systemName} when it has already been initialized.")
  {
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="SystemAlreadyInitializedException"/> class with a specified system
  /// name and inner exception message.
  /// </summary>
  public SystemAlreadyInitializedException(string systemName, Exception inner)
    : base($"Tried to initialize {systemName} when it has already been initialized.", inner)
  {
  }
}
