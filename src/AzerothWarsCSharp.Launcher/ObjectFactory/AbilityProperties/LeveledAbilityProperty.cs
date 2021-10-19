using System.Collections;
using System.Collections.Generic;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties
{
  public abstract class LeveledAbilityProperty<T> : IEnumerable<T>
  {
    protected IList<T> Values { get; set; } = new List<T>();
    protected string Name { get; private set; }

    public void Add(T value)
    {
      Values.Add(value);
    }

    public IEnumerator<T> GetEnumerator()
    {
      return Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public T this[int key]
    {
      get =>  key < Values.Count ? Values[key] : default;
      set => Values[key] = value;
    }

    public T Default { get; }

    public LeveledAbilityProperty(string name, T defaultValue)
    {
      Name = name;
      Default = defaultValue;
    }
  }
}