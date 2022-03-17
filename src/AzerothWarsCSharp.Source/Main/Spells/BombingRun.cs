namespace AzerothWarsCSharp.Source.Main.Spells
{
  public class BombingRun{

  
    private const int ABIL_ID = FourCC(A0S5);
    private const int LOCUSTSWARM_ID = FourCC(A0S1);
  

    private static void Cast( ){
      DummyChannelInstantFromPoint(GetOwningPlayer(GetTriggerUnit()), LOCUSTSWARM_ID, "locustswarm", 1, GetSpellTargetX(), GetSpellTargetY(), 15);
    }

    private static void OnInit( ){
      RegisterSpellEffectAction(ABIL_ID,  Cast);
    }

  }
}
