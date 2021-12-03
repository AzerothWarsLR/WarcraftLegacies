namespace AzerothWarsCSharp.MacroTools
{
  public class Quest
  {
    public string Name { get; internal set; }
    public string Icon { get; internal set; }
    public Faction Faction { get; internal set; }
    
    public Quest(string name, string icon)
    {
      Name = name;
      Icon = icon;
    }
  }
}