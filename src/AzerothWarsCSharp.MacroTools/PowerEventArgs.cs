namespace AzerothWarsCSharp.MacroTools
{
  public class PowerEventArgs
  {
    public Power Power { get; }
    
    public PowerEventArgs(Power power)
    {
      Power = power;
    }
  }
}