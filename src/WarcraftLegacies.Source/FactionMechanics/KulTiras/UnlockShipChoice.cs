using MacroTools.UserInterface;


namespace WarcraftLegacies.Source.FactionMechanics.KulTiras;

public sealed class UnlockShipChoice : IChoice
{
  public string Name { get; }
  public UnlockShipChoiceType Type { get; }

  public UnlockShipChoice(string name, UnlockShipChoiceType type)
  {
    Name = name;
    Type = type;
  }
}

public enum UnlockShipChoiceType
{
  TeleportTroops,
  DoNothing
}
