

namespace MacroTools
{
  /// <summary>
  /// Changes the size of the vanilla Quest menu to fit more text in it.
  /// </summary>
  public static class QuestMenuSetup
  {
    public static void Setup()
    {
      //Quest frames aren't rendered until the Quest menu is first accessed
      BlzFrameClick(BlzGetFrameByName("UpperButtonBarQuestsButton", 0));
      BlzFrameClick(BlzGetFrameByName("QuestAcceptButton", 0));
      
      var questDisplayBackdrop = BlzGetFrameByName("QuestDisplayBackdrop", 0);
      var questBackdrop = BlzGetFrameByName("QuestBackdrop", 0);
      var questAcceptButton = BlzGetFrameByName("QuestAcceptButton", 0);
      var questItemListContainer = BlzGetFrameByName("QuestItemListContainer", 0);

      // QuestDisplay
      var questDisplay = BlzGetFrameByName("QuestDisplay", 0);
      BlzFrameClearAllPoints(questDisplay);
      BlzFrameSetPoint(questDisplay, FRAMEPOINT_TOPLEFT, questItemListContainer, FRAMEPOINT_BOTTOMLEFT, 0.003f, 0.002f);
      BlzFrameSetPoint(questDisplay, FRAMEPOINT_BOTTOMRIGHT, questDisplayBackdrop, FRAMEPOINT_BOTTOMRIGHT, -0.003f, 0);
        
      // Relocate button
      BlzFrameSetPoint(questDisplayBackdrop, FRAMEPOINT_BOTTOM, questBackdrop, FRAMEPOINT_BOTTOM, 0f, 0.025f);
      BlzFrameClearAllPoints(questAcceptButton);
      BlzFrameSetPoint(questAcceptButton, FRAMEPOINT_TOPRIGHT, questBackdrop, FRAMEPOINT_TOPRIGHT, -0.016f, -0.016f);
      BlzFrameSetText(questAcceptButton, "×");
      BlzFrameSetSize(questAcceptButton, 0.03f, 0.03f);
    }
  }
}