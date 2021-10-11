using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory
{
  public interface IObjectFactory<T>
  {
    public T Generate(string newRawCode, ObjectDatabase objectDatabase);
  }
}