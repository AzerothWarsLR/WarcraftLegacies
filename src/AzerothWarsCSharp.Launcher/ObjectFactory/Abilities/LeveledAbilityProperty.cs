using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzerothWarsCSharp.Launcher
{
  public class LeveledAbilityProperty<T> : IEnumerable<T> where T : struct
  {
    private readonly IList<T> _values = new List<T>();
    private readonly string _name;

    public void Add(T value)
    {
      _values.Add(value);
    }

    public IEnumerator<T> GetEnumerator()
    {
      return _values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    private static string NumberToString(T number, bool isPercentage = false)
    {
      var mult = isPercentage ? 100 : 1;
      if (isPercentage)
      {
        if (number is int intNumber)
        {
          return (intNumber * mult).ToString("n0");
        }
        if (number is float floatNumber)
        {
          return (floatNumber * mult).ToString("n0");
        }
      }
      return string.Empty;
    }

    /// <summary>
    /// Returns a formatted string conversion of the value at the specified index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="isPercentage"></param>
    /// <returns></returns>
    public string ValueToString(int index = 0, bool isPercentage = true)
    {
      if (isPercentage)
      {
        return NumberToString(_values[index]);
      }
      return string.Empty;
    }

    /// <summary>
    /// Convert the values in this property to a string series, like 10/20/30/40.
    /// </summary>
    /// <param name="isPercentage"></param>
    /// <returns></returns>
    public string ToConcatenatedString(bool isPercentage = false)
    {
      StringBuilder stringBuilder = new();
      stringBuilder.Append($"|n|cffecce87{_name}|r: ");
      for (int i = 0; i < _values.Count; i++)
      {
        var number = _values[i];
        if (isPercentage)
        {
          stringBuilder.Append(NumberToString(number, true));
          stringBuilder.Append('%');
        }
        else
        {
          stringBuilder.Append(number);
        }
        if (i < _values.Count - 1)
        {
          stringBuilder.Append('/');
        }
      }
      return stringBuilder.ToString();
    }

    public T[] ToArray()
    {
      return _values.ToArray();
    }

    public T this[int key]
    {
      get =>  key < _values.Count ? _values[key] : default;
      set => _values[key] = value;
    }

    public LeveledAbilityProperty(string name)
    {
      _name = name;
    }
  }
}