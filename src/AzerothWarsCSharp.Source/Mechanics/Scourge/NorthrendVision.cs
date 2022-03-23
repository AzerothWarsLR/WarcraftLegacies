//Scourge always has vision over Northrend.

using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Mechanics.Scourge
{
  public static class NorthrendVision
  {
    private static fogmodifier[] ScourgeFogModifiers;

    private static void Enable()
    {
      player whichPlayer = ScourgeSetup.FACTION_SCOURGE.Player;
      var i = 0;
      ScourgeFogModifiers[0] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.Storm_Peaks.Rect, true, true);
      ScourgeFogModifiers[1] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.Central_Northrend.Rect, true, true);
      ScourgeFogModifiers[2] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.The_Basin.Rect, true, true);
      ScourgeFogModifiers[3] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.Ice_Crown.Rect, true, true);
      ScourgeFogModifiers[4] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.Fjord.Rect, true, true);
      ScourgeFogModifiers[5] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.Eastern_Northrend.Rect, true, true);
      ScourgeFogModifiers[6] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.Far_Eastern_Northrend.Rect, true, true);
      ScourgeFogModifiers[7] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.Coldarra.Rect, true, true);
      ScourgeFogModifiers[8] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.Borean_Tundra.Rect, true, true);
      ScourgeFogModifiers[9] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.IcecrownShipyard.Rect, true, true);

      foreach (var modifier in ScourgeFogModifiers) FogModifierStart(modifier);
    }

    private static void Disable()
    {
      foreach (var modifier in ScourgeFogModifiers) DestroyFogModifier(modifier);
    }

    private static void PersonChangesFaction()
    {
      player triggerPlayer;
      var i = 0;
      if (GetTriggerPerson().Faction == FACTION_SCOURGE)
        Enable();
      else if (GetChangingPersonPrevFaction() == FACTION_SCOURGE) Disable();
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      OnPersonFactionChange.register(trig);
      TriggerAddCondition(trig, PersonChangesFaction);

      if (FACTION_SCOURGE.Person != 0) Enable();
    }
  }
}