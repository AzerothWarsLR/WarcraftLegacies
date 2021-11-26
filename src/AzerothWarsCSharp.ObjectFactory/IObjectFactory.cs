using War3Api.Object;

namespace AzerothWarsCSharp.ObjectFactory
{
  public interface IObjectFactory<T>
  {
    public T Generate(string newRawCode, ObjectDatabase objectDatabase);
  }
}