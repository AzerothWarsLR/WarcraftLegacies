namespace AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties
{
  public interface ILeveledAbilityPropertyReadable
  {
    /// <summary>
    /// Renders this entire property as a string series, like "Mana Cost: 10/20/30/40".
    /// If a level other than 0 is passed in, instead render one specific level's information, like "Mana Cost: 20".
    /// </summary>
    /// <param name="level"></param>
    /// <param name="isPercentage"></param>
    /// <returns></returns>
    public string ToConcatenatedString(int level = 0);
  }
}