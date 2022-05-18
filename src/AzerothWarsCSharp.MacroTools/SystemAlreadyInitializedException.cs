using System;

namespace AzerothWarsCSharp.MacroTools
{
  public sealed class SystemAlreadyInitializedException : Exception
  {
    public SystemAlreadyInitializedException()
    {
    }

    public SystemAlreadyInitializedException(string message)
      : base(message)
    {
    }

    public SystemAlreadyInitializedException(string message, Exception inner)
      : base(message, inner)
    {
    }
  }
}