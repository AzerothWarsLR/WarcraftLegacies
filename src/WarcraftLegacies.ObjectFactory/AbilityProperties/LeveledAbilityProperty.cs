using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WarcraftLegacies.ObjectFactory.AbilityProperties
{
  /// <summary>
  /// A property of a Warcraft 3 ability factory object, with multiple levels.
  /// Each array index is a different level. If you attempt to access an unallocated index,
  /// the collection will try to return the value at the next available index.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class LeveledAbilityProperty<T> : IEnumerable<T>, ILeveledAbilityPropertyReadable
  {
    protected List<T> Values { get; set; } = new List<T>();
    protected string Name { get; private set; }
    public T Default { get; }

    protected abstract string ValueToString(T value);

    public void Add(T value)
    {
      Values.Add(value);
    }

    public string ToConcatenatedString(int level = 0)
    {
      StringBuilder stringBuilder = new();
      stringBuilder.Append($"|n|cffecce87{Name}|r: ");
      for (int i = 0; i < level; i++)
      {
        if (i + 1 == level || level == 0)
        {
          stringBuilder.Append(ValueToString(this[i]));
          if (i < Values.Count - 1 && level == 0)
          {
            stringBuilder.Append('/');
          }
        }
      }
      return stringBuilder.ToString();
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
      get
      {
        if (key < Values.Count) {
          return Values[key];
        }
        else if (key != 0)
        {
          return this[key - 1];
        }
        return Default;
      }
      set
      {
        if (key >= Values.Count)
        {
          Values.Add(value);
        } else
        {
          Values[key] = value;
        }
      }
    }

    public LeveledAbilityProperty(string name, T defaultValue)
    {
      Name = name;
      Default = defaultValue;
    }
  }
}