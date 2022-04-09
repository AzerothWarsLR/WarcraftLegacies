using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemEitherOf : QuestItemData
  {
    private readonly QuestItemData _questItemA;
    private readonly QuestItemData _questItemB;

    public override Point Position => new(_questItemA.Position.X, _questItemB.Position.Y);
    
    public QuestItemEitherOf(QuestItemData questItemA, QuestItemData questItemB)
    {
      _questItemA = questItemA;
      _questItemB = questItemB;
      questItemA.ParentQuestItem = this;
      questItemB.ParentQuestItem = this;
      Description = questItemA.Description + " or " + questItemB.Description;
      questItemA.ProgressChanged += OnChildProgressChanged;
      questItemB.ProgressChanged += OnChildProgressChanged;
    }

    internal override void OnAdd()
    {
      _questItemA.OnAdd();
      _questItemB.OnAdd();
      Update();
    }

    private void Update()
    {
      if (_questItemA.Progress == QuestProgress.Complete || _questItemB.Progress == QuestProgress.Complete)
      {
        Progress = QuestProgress.Complete;
        return;
      }

      if (_questItemA.Progress == QuestProgress.Failed && _questItemB.Progress == QuestProgress.Failed)
        Progress = QuestProgress.Failed;
    }

    private void OnChildProgressChanged(object? sender, QuestItemData questItemData)
    {
      Update();
    }
  }
}