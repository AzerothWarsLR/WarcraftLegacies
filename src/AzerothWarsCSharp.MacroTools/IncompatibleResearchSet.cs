using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Events;

using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  /// <summary>
  /// An IncompatibleResearchSet is a list of Researchs which are mutually exclusive with each other.
  /// This means that if one of these Researchs is started, the other 2 are disabled
  /// and only re-enabled if the first research is cancelled.
  /// </summary>
  public class IncompatibleResearchSet{
    private const int BIG_NUMBER = 5000; //This is here to disable and enable techs via addition and subtraction
    private static readonly List<IncompatibleResearchSet> IncompatibleResearchSets = new();

    private readonly List<int> _researches = new();

    public void Add(int researchId){
      _researches.Add(researchId);
    }

    private void DisableResearches( ){
      var i = 0;
      var p = PlayerData.ByHandle(GetTriggerPlayer());
      while(true){
        if (_researches[i] == 0){ break; }
        if (_researches[i] != GetResearched()){
          p.ModObjectLimit(_researches[i], -BIG_NUMBER);
        }
        i += 1;
      }
    }

    private void EnableResearches( ){
      var i = 0;
      var p = PlayerData.ByHandle(GetTriggerPlayer());
      while(true){
        if (_researches[i] == 0){ break; }
        if (_researches[i] != GetResearched()){
          p.ModObjectLimit(_researches[i], BIG_NUMBER);
        }
        i += 1;
      }
    }

    //Flag is true for START, and false for CANCEL
    private static void DoResearch(bool flag){
      foreach (var incompatibleResearchSet in IncompatibleResearchSets)
      {
        foreach (var research in incompatibleResearchSet._researches)
        {
          if (research == GetResearched())
          {
            if (flag)
            {
              incompatibleResearchSet.DisableResearches();
              return;
            }
            incompatibleResearchSet.EnableResearches();
            return;
          }
        }
      }
    }

    private IncompatibleResearchSet ( ){ }

    public static void Create()
    {
      IncompatibleResearchSets.Add(new IncompatibleResearchSet());
    }
    
    private static void ResearchStart( ){
      DoResearch(true);
    }

    private static void ResearchCancel( ){
      DoResearch(false);
    }

    public static void Setup( )
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsStarted, ResearchStart);
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, ResearchCancel);
    }

  }
}
