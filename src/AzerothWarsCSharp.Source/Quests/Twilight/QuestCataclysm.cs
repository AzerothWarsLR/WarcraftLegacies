using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.Mechanics.TwilightHammer;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestCataclysm : QuestData
  {
    private static readonly int CataclysmResearch = FourCC("R05E");
    private readonly PowerCorruptWorker _corruptWorkerPower;

    public QuestCataclysm(PowerCorruptWorker corruptWorkerPower) : base("The Cataclysm",
      "The Old God's will is finnicky, you are not privy to when their plan will be set in motion, but when it is, your cult will be ready to welcome it.",
      "ReplaceableTextures\\CommandButtons\\BTNDeathwing.blp")
    {
      _corruptWorkerPower = corruptWorkerPower;
      AddObjective(new ObjectiveTimeRandom(1360, 1780));
      Global = true;
      Required = true;
    }

    protected override string CompletionPopup => "Deathwing is here, Doomsday is at hand, the Cataclysm as begun!";

    protected override string RewardDescription =>
      "Cultists all over the world join your cause actively, Deathwing as a super demihero and the 2 elemental ascendant heroes.";

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, CataclysmResearch, 1);
      PlayThematicMusic("war3mapImported\\TwilightTheme.mp3");
      SetPlayerTechResearched(CthunSetup.Cthun.Player, FourCC("R07D"), 1);
      IssueImmediateOrder(LegendNeutral.LegendGrimbatol.Unit, "unrobogoblin");
      LegendTwilight.LEGEND_DEATHWING.ForceCreate(completingFaction.Player ?? Player(GetBJPlayerNeutralVictim()),
        Regions.TwilightOutside.Center, 0);
      GeneralHelpers.CameraSetEarthquakeNoise(30);
      if (completingFaction.Player != null)
        _corruptWorkerPower.ConvertAllWorkers(completingFaction.Player);
      completingFaction.RemovePower(_corruptWorkerPower);
      var timer = CreateTimer();
      TimerStart(timer, 3, false, ClearCameraNoise);
    }

    private static void ClearCameraNoise()
    {
      DestroyTimer(GetExpiredTimer());
      CameraSetSourceNoise(0, 0);
      CameraSetTargetNoise(0, 0);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(CataclysmResearch, Faction.UNLIMITED);
    }
  }
}