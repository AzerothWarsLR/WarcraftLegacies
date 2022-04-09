namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemEitherOf : QuestItemData
  {
    private static int count = 0;
    private static thistype[] byIndex;

    private readonly QuestItemData questItemA;
    private readonly QuestItemData questItemB;

    private X()
    {
      return questItemA.X;
    }

    private Y()
    {
      return questItemA.Y;
    }

    public QuestItemEitherOf(QuestItemData questItemA, QuestItemData questItemB)
    {
      this.questItemA = questItemA;
      this.questItemB = questItemB;
      questItemA.ParentQuestItem = this;
      questItemB.ParentQuestItem = this;
      Description = questItemA.Description + " || " + questItemB.Description;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
    }

    float operator

    float operator

    private void OnAdd()
    {
      questItemA.OnAdd();
      questItemB.OnAdd();
      CheckChildStatus();
    }

    private void CheckChildStatus()
    {
      if (questItemA.Progress == QuestProgress.Complete || questItemB.Progress == QuestProgress.Complete)
      {
        Progress = QuestProgress.Complete;
        return;
      }

      if (questItemA.Progress == QuestProgress.Failed && questItemB.Progress == QuestProgress.Failed)
        Progress = QuestProgress.Failed;
    }

    public static void OnAnyQuestItemProgressChanged()
    {
      QuestItemData triggerQuestItemData = QuestItemData.TriggerQuestItemData;
      var i = 0;
      while (true)
      {
        if (i == thistype.count) break;
        if (triggerQuestItemData == thistype.byIndex[i].questItemA ||
            triggerQuestItemData == thistype.byIndex[i].questItemB) thistype.byIndex[i].CheckChildStatus();
        i = i + 1;
      }
    }


    public static void Setup()
    {
      trigger trig = CreateTrigger();
      ProgressChanged.register(trig);
      TriggerAddAction(trig, OnAnyQuestItemProgressChanged);
    }
  }
}