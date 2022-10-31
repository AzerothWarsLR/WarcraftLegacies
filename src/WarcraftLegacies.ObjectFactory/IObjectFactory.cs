using War3Api.Object;

namespace WarcraftLegacies.ObjectFactory
{
  public interface IObjectFactory<T>
  {
    public T Generate(string newRawCode, ObjectDatabase objectDatabase);
  }
}