namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Changes the size of the vanilla Quest menu to fit more text in it.
/// </summary>
public static class QuestMenuSetup
{
  public static void Setup()
  {
    //Quest frames aren't rendered until the Quest menu is first accessed
    framehandle.Get("UpperButtonBarQuestsButton", 0).Click();
    framehandle.Get("QuestAcceptButton", 0).Click();

    var questDisplayBackdrop = framehandle.Get("QuestDisplayBackdrop", 0);
    var questBackdrop = framehandle.Get("QuestBackdrop", 0);
    var questAcceptButton = framehandle.Get("QuestAcceptButton", 0);
    var questItemListContainer = framehandle.Get("QuestItemListContainer", 0);

    // QuestDisplay
    var questDisplay = framehandle.Get("QuestDisplay", 0);
    questDisplay.ClearPoints();
    questDisplay.SetPoint(framepointtype.TopLeft, 0.003f, 0.002f, questItemListContainer, framepointtype.BottomLeft);
    questDisplay.SetPoint(framepointtype.BottomRight, -0.003f, 0, questDisplayBackdrop, framepointtype.BottomRight);

    // Relocate button
    questDisplayBackdrop.SetPoint(framepointtype.Bottom, 0f, 0.025f, questBackdrop, framepointtype.Bottom);
    questAcceptButton.ClearPoints();
    questAcceptButton.SetPoint(framepointtype.TopRight, -0.016f, -0.016f, questBackdrop, framepointtype.TopRight);
    questAcceptButton.Text = "×";
    questAcceptButton.SetSize(0.03f, 0.03f);
  }
}
