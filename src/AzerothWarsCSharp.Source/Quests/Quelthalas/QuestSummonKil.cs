using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestSummonKil : QuestData
  {
    public QuestSummonKil() : base("The Great Deceiver",
      "The greater demon Kil'jaeden has been scheming for aeons. Will Kael finally be the one to summon him and consume Azeroth?",
      "ReplaceableTextures\\CommandButtons\\BTNKiljaedin.blp")
    {
      AddObjective(new ObjectiveChannelRect(Regions.KaelSunwellChannel, "The Sunwell", LegendQuelthalas.LegendKael,
        180, 270));
      Global = true;
      Required = true;
    }

    protected override string CompletionPopup => "The greater demon Kil'jaeden has been summoned to Azeroth";

    protected override string RewardDescription => "The hero Kil'jaeden";

    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player == null) return;
      UnitRemoveAbility(LegendQuelthalas.LegendKael.Unit, Constants.ABILITY_A0R7_INSTILL_RAGE_YOGG);
      LegendQuelthalas.LegendKiljaeden.ForceCreate(completingFaction.Player, Regions.Sunwell.Center, 244);
    }
  }
}