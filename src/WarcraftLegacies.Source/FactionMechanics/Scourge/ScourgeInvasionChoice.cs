using MacroTools.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.FactionMechanics.Scourge
{
  public sealed class ScourgeInvasionChoice : IChoice
  {
    public Rectangle? Location { get; }
    public Point AttackTarget { get; set; }

    
    /// <inheritdoc />
    public string Name { get; }
    
    public ScourgeInvasionChoice(Rectangle? location, string name)
    {
      Location = location;
      Name = name;
    }
  }
}