using System;

namespace MacroTools
{
  public sealed class SystemNotInitializedException : Exception
  {
    public SystemNotInitializedException()
    {
    }

    public SystemNotInitializedException(string message)
      : base(message)
    {
    }

    public SystemNotInitializedException(string message, Exception inner)
      : base(message, inner)
    {
    }
  }
}