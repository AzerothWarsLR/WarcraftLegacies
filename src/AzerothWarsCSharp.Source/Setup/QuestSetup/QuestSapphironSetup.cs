using AzerothWarsCSharp.Source.Libraries;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  class QuestSapphironSetup
  {
    private static readonly int SAPPHIRON_ID = FourCC("ubdd");
    private static readonly int SAPPHIRON_RESEARCH = FourCC("R025");

    public static void Initialize()
    {
      var questKillSapphiron = new QuestEx()
      {
        Title = "Sapphiron",
        Description = "Kill Sapphiron the Blue Dragon to reanimate her as a Frost Wyrm.",
        Icon = "ReplaceableTextures\\CommandButtons\\BTNFrostWyrm.blp",
        CompletionPopup = "Sapphiron has been slain, and has been reanimated as a mighty Frost Worm under the command of the Scourge.",
        CompletionDescription = "The demihero Sapphiron",
        OnAdd = (Faction owner) =>
        {
          owner.ModObjectLimit(SAPPHIRON_RESEARCH, Faction.UNLIMITED);
        },
        OnComplete = (Faction owner) =>
        {
          CreateUnit(owner.Player, SAPPHIRON_ID, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()), GetUnitFacing(GetTriggerUnit()));
          SetPlayerTechResearched(owner.Player, SAPPHIRON_RESEARCH, 1);
        },
      };
      questKillSapphiron.AddObjective(new ObjectiveKillUnit(questKillSapphiron, null));
      ScourgeSetup.Scourge.AddQuest(questKillSapphiron);
    }
  }
}