using System.Collections.Generic;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.BlackEmpire
{
  public sealed class QuestWakingDream : QuestData
  {

    public QuestWakingDream(LegendaryHero zaqul) : base("Waking Dream",
      "Countless ages ago, Warlord Zon'ozz was one of my strongest generals. In this new time of need, he needs to be called to Azeroth once more to wage war in my name.",
      @"ReplaceableTextures\CommandButtons\BTNDarkPortal.blp")
    {
      AddObjective(new ObjectiveChannelRect(Regions.FeralasEmeraldPortal, "the Feralas Emerald Portal", zaqul, 180, 270, Title));
      ResearchId = UPGRADE_RBWD_QUEST_COMPLETED_WAKING_DREAM;

    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "Zon'ozz has joined my ranks once more.";

    /// <inheritdoc/>
    protected override string RewardDescription => $"Learn to train {GetObjectName(UNIT_U00P_LIEUTENANT_OF_N_ZOTH)}s from the {GetObjectName(UNIT_N0AV_ALTAR_OF_MADNESS_YOGG_ALTAR)}";

   
  }
}