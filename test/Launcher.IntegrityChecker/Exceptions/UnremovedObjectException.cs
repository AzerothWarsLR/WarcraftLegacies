namespace Launcher.IntegrityChecker.Exceptions;

public sealed class UnremovedObjectException : Exception
{
  public UnremovedObjectException(string message) : base(message) { }
  public UnremovedObjectException(string message, Exception innerException) : base(message, innerException) { }
}
